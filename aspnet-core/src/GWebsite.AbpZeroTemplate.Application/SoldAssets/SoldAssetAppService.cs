using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SoldAssets;
using GWebsite.AbpZeroTemplate.Application.Share.SoldAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.SoldAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class SoldAssetAppService : GWebsiteAppServiceBase, ISoldAssetAppService
    {
        private readonly IRepository<SoldAsset> soldAssetRepository;

        public SoldAssetAppService(IRepository<SoldAsset> soldAssetRepository)
        {
            this.soldAssetRepository = soldAssetRepository;
        }

        #region Public Method

        public void CreateOrEditSoldAsset(SoldAssetInput soldAssetInput)
        {
            if (soldAssetInput.Id == 0)
            {
                Create(soldAssetInput);
            }
            else
            {
                Update(soldAssetInput);
            }
        }

        public void DeleteSoldAsset(int id)
        {
            var soldAssetEntity = soldAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (soldAssetEntity != null)
            {
                soldAssetEntity.IsDelete = true;
                soldAssetRepository.Update(soldAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        public SoldAssetGeneralStatistics GetGeneralStatistics(SoldAssetFilter input)
        {
            var statistics = new SoldAssetGeneralStatistics();
            var previousTotalAmount = 0.0;
            var previousTotalQuantity = 0.0;
            var currentTotalAmount = 0.0;
            var currentTotalQuantity = 0.0;
            var amountRatio = 0.0;
            var quantityRatio = 0.0;

            var query = soldAssetRepository.GetAll().Where(x => !x.IsDelete);

            query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);

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

        public SoldAssetInput GetSoldAssetForEdit(int id)
        {
            var soldAssetEntity = soldAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (soldAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SoldAssetInput>(soldAssetEntity);
        }

        public SoldAssetForViewDto GetSoldAssetForView(int id)
        {
            var soldAssetEntity = soldAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (soldAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SoldAssetForViewDto>(soldAssetEntity);
        }

        public PagedResultDto<SoldAssetDto> GetSoldAssets(SoldAssetFilter input)
        {
            var query = soldAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.SoldAssetType != null)
            //{
            //    query = query.Where(x => x.SoldAssetType.ToLower().Equals(input.SoldAssetType));
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
            return new PagedResultDto<SoldAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SoldAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(SoldAssetInput soldAssetInput)
        {
            var soldAssetEntity = ObjectMapper.Map<SoldAsset>(soldAssetInput);
            SetAuditInsert(soldAssetEntity);
            soldAssetRepository.Insert(soldAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(SoldAssetInput soldAssetInput)
        {
            var soldAssetEntity = soldAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == soldAssetInput.Id);
            if (soldAssetEntity == null)
            {
            }
            ObjectMapper.Map(soldAssetInput, soldAssetEntity);
            SetAuditEdit(soldAssetEntity);
            soldAssetRepository.Update(soldAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
