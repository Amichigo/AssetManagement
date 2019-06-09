using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets;
using GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.MaintainedAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class MaintainedAssetAppService : GWebsiteAppServiceBase, IMaintainedAssetAppService
    {
        private readonly IRepository<MaintainedAsset> maintainedAssetRepository;

        public MaintainedAssetAppService(IRepository<MaintainedAsset> maintainedAssetRepository)
        {
            this.maintainedAssetRepository = maintainedAssetRepository;
        }

        #region Public Method

        public void CreateOrEditMaintainedAsset(MaintainedAssetInput maintainedAssetInput)
        {
            if (maintainedAssetInput.Id == 0)
            {
                Create(maintainedAssetInput);
            }
            else
            {
                Update(maintainedAssetInput);
            }
        }

        public void DeleteMaintainedAsset(int id)
        {
            var maintainedAssetEntity = maintainedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (maintainedAssetEntity != null)
            {
                maintainedAssetEntity.IsDelete = true;
                maintainedAssetRepository.Update(maintainedAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        public MaintainedAssetGeneralStatistics GetGeneralStatistics(MaintainedAssetFilter input)
        {
            var statistics = new MaintainedAssetGeneralStatistics();
            var previousTotalAmount = 0.0;
            var previousTotalQuantity = 0.0;
            var currentTotalAmount = 0.0;
            var currentTotalQuantity = 0.0;
            var amountRatio = 0.0;
            var quantityRatio = 0.0;

            var query = maintainedAssetRepository.GetAll().Where(x => !x.IsDelete && x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);

            foreach (var record in query.ToList())
            {
                if (record.RecordedDate >= input.PreviousStartingDate && record.RecordedDate <= input.PreviousEndingDate)
                {
                    previousTotalAmount += record.Amount;
                    previousTotalQuantity += record.Quantity;
                }
                else
                {
                    currentTotalAmount += record.Amount;
                    currentTotalQuantity += record.Quantity;
                }

            }

            amountRatio = Math.Round(((currentTotalAmount - previousTotalAmount) / previousTotalAmount) * 100, 2);
            quantityRatio = Math.Round(((currentTotalQuantity - previousTotalQuantity) / previousTotalQuantity) * 100, 2);

            statistics.CurrentTotalAmount = isValidDouble(currentTotalAmount) ? currentTotalAmount : 0;
            statistics.CurrentTotalQuantity = isValidDouble(currentTotalQuantity) ? currentTotalQuantity : 0;
            statistics.PreviousTotalAmount = isValidDouble(previousTotalAmount) ? previousTotalAmount : 0;
            statistics.PreviousTotalQuantity = isValidDouble(previousTotalQuantity) ? previousTotalQuantity : 0;
            statistics.AmountRatio = isValidDouble(amountRatio) ? amountRatio : 0;
            statistics.QuantityRatio = isValidDouble(quantityRatio) ? quantityRatio : 0;

            return statistics;
        }

        public MaintainedAssetInput GetMaintainedAssetForEdit(int id)
        {
            var maintainedAssetEntity = maintainedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (maintainedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<MaintainedAssetInput>(maintainedAssetEntity);
        }

        public MaintainedAssetForViewDto GetMaintainedAssetForView(int id)
        {
            var maintainedAssetEntity = maintainedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (maintainedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<MaintainedAssetForViewDto>(maintainedAssetEntity);
        }

        public PagedResultDto<MaintainedAssetDto> GetMaintainedAssets(MaintainedAssetFilter input)
        {
            var query = maintainedAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.MaintainedAssetType != null)
            //{
            //    query = query.Where(x => x.MaintainedAssetType.ToLower().Equals(input.MaintainedAssetType));
            //}

            //if (input.InvestmentType != null)
            //{
            //    query = query.Where(x => x.InvestmentType.ToLower().Equals(input.InvestmentType));
            //}

            //if (input.AssetId != null)
            //{
            //    query = query.Where(x => x.AssetId.ToLower().Equals(input.AssetId));
            //}

            /*
            if (input.StartingExecutionTime && input.EndingExecutionTime)
            {
                query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }
            */

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            // var items = query.PageBy(input).ToList();
            var items = query.ToList();

            // result
            return new PagedResultDto<MaintainedAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<MaintainedAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(MaintainedAssetInput maintainedAssetInput)
        {
            var maintainedAssetEntity = ObjectMapper.Map<MaintainedAsset>(maintainedAssetInput);
            SetAuditInsert(maintainedAssetEntity);
            maintainedAssetRepository.Insert(maintainedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(MaintainedAssetInput maintainedAssetInput)
        {
            var maintainedAssetEntity = maintainedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == maintainedAssetInput.Id);
            if (maintainedAssetEntity == null)
            {
            }
            ObjectMapper.Map(maintainedAssetInput, maintainedAssetEntity);
            SetAuditEdit(maintainedAssetEntity);
            maintainedAssetRepository.Update(maintainedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
