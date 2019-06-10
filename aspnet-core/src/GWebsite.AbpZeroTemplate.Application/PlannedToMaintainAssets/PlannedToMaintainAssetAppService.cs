using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.PlannedToMaintainAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class PlannedToMaintainAssetAppService : GWebsiteAppServiceBase, IPlannedToMaintainAssetAppService
    {
        private readonly IRepository<PlannedToMaintainAsset> plannedToMaintainAssetRepository;

        public PlannedToMaintainAssetAppService(IRepository<PlannedToMaintainAsset> plannedToMaintainAssetRepository)
        {
            this.plannedToMaintainAssetRepository = plannedToMaintainAssetRepository;
        }

        #region Public Method

        public void CreateOrEditPlannedToMaintainAsset(PlannedToMaintainAssetInput plannedToMaintainAssetInput)
        {
            if (plannedToMaintainAssetInput.Id == 0)
            {
                Create(plannedToMaintainAssetInput);
            }
            else
            {
                Update(plannedToMaintainAssetInput);
            }
        }

        public void DeletePlannedToMaintainAsset(int id)
        {
            var plannedToMaintainAssetEntity = plannedToMaintainAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToMaintainAssetEntity != null)
            {
                plannedToMaintainAssetEntity.IsDelete = true;
                plannedToMaintainAssetRepository.Update(plannedToMaintainAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        public PlannedToMaintainAssetGeneralStatistics GetGeneralStatistics(PlannedToMaintainAssetFilter input)
        {
            var statistics = new PlannedToMaintainAssetGeneralStatistics();
            var previousTotalAmount = 0.0;
            var previousTotalQuantity = 0.0;
            var currentTotalAmount = 0.0;
            var currentTotalQuantity = 0.0;
            var amountRatio = 0.0;
            var quantityRatio = 0.0;

            var query = plannedToMaintainAssetRepository.GetAll().Where(x => !x.IsDelete);

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

        public PlannedToMaintainAssetInput GetPlannedToMaintainAssetForEdit(int id)
        {
            var plannedToMaintainAssetEntity = plannedToMaintainAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToMaintainAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlannedToMaintainAssetInput>(plannedToMaintainAssetEntity);
        }

        public PlannedToMaintainAssetForViewDto GetPlannedToMaintainAssetForView(int id)
        {
            var plannedToMaintainAssetEntity = plannedToMaintainAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToMaintainAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlannedToMaintainAssetForViewDto>(plannedToMaintainAssetEntity);
        }

        public PagedResultDto<PlannedToMaintainAssetDto> GetPlannedToMaintainAssets(PlannedToMaintainAssetFilter input)
        {
            var query = plannedToMaintainAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.PlannedToMaintainAssetType != null)
            //{
            //    query = query.Where(x => x.PlannedToMaintainAssetType.ToLower().Equals(input.PlannedToMaintainAssetType));
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
            return new PagedResultDto<PlannedToMaintainAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PlannedToMaintainAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(PlannedToMaintainAssetInput plannedToMaintainAssetInput)
        {
            var plannedToMaintainAssetEntity = ObjectMapper.Map<PlannedToMaintainAsset>(plannedToMaintainAssetInput);
            SetAuditInsert(plannedToMaintainAssetEntity);
            plannedToMaintainAssetRepository.Insert(plannedToMaintainAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(PlannedToMaintainAssetInput plannedToMaintainAssetInput)
        {
            var plannedToMaintainAssetEntity = plannedToMaintainAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == plannedToMaintainAssetInput.Id);
            if (plannedToMaintainAssetEntity == null)
            {
            }
            ObjectMapper.Map(plannedToMaintainAssetInput, plannedToMaintainAssetEntity);
            SetAuditEdit(plannedToMaintainAssetEntity);
            plannedToMaintainAssetRepository.Update(plannedToMaintainAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
