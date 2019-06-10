using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.PlannedToPurchaseAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class PlannedToPurchaseAssetAppService : GWebsiteAppServiceBase, IPlannedToPurchaseAssetAppService
    {
        private readonly IRepository<PlannedToPurchaseAsset> plannedToPurchaseAssetRepository;

        public PlannedToPurchaseAssetAppService(IRepository<PlannedToPurchaseAsset> plannedToPurchaseAssetRepository)
        {
            this.plannedToPurchaseAssetRepository = plannedToPurchaseAssetRepository;
        }

        #region Public Method

        public void CreateOrEditPlannedToPurchaseAsset(PlannedToPurchaseAssetInput plannedToPurchaseAssetInput)
        {
            if (plannedToPurchaseAssetInput.Id == 0)
            {
                Create(plannedToPurchaseAssetInput);
            }
            else
            {
                Update(plannedToPurchaseAssetInput);
            }
        }

        public void DeletePlannedToPurchaseAsset(int id)
        {
            var plannedToPurchaseAssetEntity = plannedToPurchaseAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToPurchaseAssetEntity != null)
            {
                plannedToPurchaseAssetEntity.IsDelete = true;
                plannedToPurchaseAssetRepository.Update(plannedToPurchaseAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        public PlannedToPurchaseAssetGeneralStatistics GetGeneralStatistics(PlannedToPurchaseAssetFilter input)
        {
            var statistics = new PlannedToPurchaseAssetGeneralStatistics();
            var previousTotalAmount = 0.0;
            var previousTotalQuantity = 0.0;
            var currentTotalAmount = 0.0;
            var currentTotalQuantity = 0.0;
            var amountRatio = 0.0;
            var quantityRatio = 0.0;

            var query = plannedToPurchaseAssetRepository.GetAll().Where(x => !x.IsDelete && x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);

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

        public PlannedToPurchaseAssetInput GetPlannedToPurchaseAssetForEdit(int id)
        {
            var plannedToPurchaseAssetEntity = plannedToPurchaseAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToPurchaseAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlannedToPurchaseAssetInput>(plannedToPurchaseAssetEntity);
        }

        public PlannedToPurchaseAssetForViewDto GetPlannedToPurchaseAssetForView(int id)
        {
            var plannedToPurchaseAssetEntity = plannedToPurchaseAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToPurchaseAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlannedToPurchaseAssetForViewDto>(plannedToPurchaseAssetEntity);
        }

        public PagedResultDto<PlannedToPurchaseAssetDto> GetPlannedToPurchaseAssets(PlannedToPurchaseAssetFilter input)
        {
            var query = plannedToPurchaseAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.PlannedToPurchaseAssetType != null)
            //{
            //    query = query.Where(x => x.PlannedToPurchaseAssetType.ToLower().Equals(input.PlannedToPurchaseAssetType));
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
            return new PagedResultDto<PlannedToPurchaseAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PlannedToPurchaseAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(PlannedToPurchaseAssetInput plannedToPurchaseAssetInput)
        {
            var plannedToPurchaseAssetEntity = ObjectMapper.Map<PlannedToPurchaseAsset>(plannedToPurchaseAssetInput);
            SetAuditInsert(plannedToPurchaseAssetEntity);
            plannedToPurchaseAssetRepository.Insert(plannedToPurchaseAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(PlannedToPurchaseAssetInput plannedToPurchaseAssetInput)
        {
            var plannedToPurchaseAssetEntity = plannedToPurchaseAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == plannedToPurchaseAssetInput.Id);
            if (plannedToPurchaseAssetEntity == null)
            {
            }
            ObjectMapper.Map(plannedToPurchaseAssetInput, plannedToPurchaseAssetEntity);
            SetAuditEdit(plannedToPurchaseAssetEntity);
            plannedToPurchaseAssetRepository.Update(plannedToPurchaseAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
