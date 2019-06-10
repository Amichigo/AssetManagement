using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.PlannedToSellAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class PlannedToSellAssetAppService : GWebsiteAppServiceBase, IPlannedToSellAssetAppService
    {
        private readonly IRepository<PlannedToSellAsset> plannedToSellAssetRepository;

        public PlannedToSellAssetAppService(IRepository<PlannedToSellAsset> plannedToSellAssetRepository)
        {
            this.plannedToSellAssetRepository = plannedToSellAssetRepository;
        }

        #region Public Method

        public void CreateOrEditPlannedToSellAsset(PlannedToSellAssetInput plannedToSellAssetInput)
        {
            if (plannedToSellAssetInput.Id == 0)
            {
                Create(plannedToSellAssetInput);
            }
            else
            {
                Update(plannedToSellAssetInput);
            }
        }

        public void DeletePlannedToSellAsset(int id)
        {
            var plannedToSellAssetEntity = plannedToSellAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToSellAssetEntity != null)
            {
                plannedToSellAssetEntity.IsDelete = true;
                plannedToSellAssetRepository.Update(plannedToSellAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        public PlannedToSellAssetGeneralStatistics GetGeneralStatistics(PlannedToSellAssetFilter input)
        {
            var statistics = new PlannedToSellAssetGeneralStatistics();
            var previousTotalAmount = 0.0;
            var previousTotalQuantity = 0.0;
            var currentTotalAmount = 0.0;
            var currentTotalQuantity = 0.0;
            var amountRatio = 0.0;
            var quantityRatio = 0.0;

            var query = plannedToSellAssetRepository.GetAll().Where(x => !x.IsDelete && x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);

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

        public PlannedToSellAssetInput GetPlannedToSellAssetForEdit(int id)
        {
            var plannedToSellAssetEntity = plannedToSellAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToSellAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlannedToSellAssetInput>(plannedToSellAssetEntity);
        }

        public PlannedToSellAssetForViewDto GetPlannedToSellAssetForView(int id)
        {
            var plannedToSellAssetEntity = plannedToSellAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (plannedToSellAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlannedToSellAssetForViewDto>(plannedToSellAssetEntity);
        }

        public PagedResultDto<PlannedToSellAssetDto> GetPlannedToSellAssets(PlannedToSellAssetFilter input)
        {
            var query = plannedToSellAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.PlannedToSellAssetType != null)
            //{
            //    query = query.Where(x => x.PlannedToSellAssetType.ToLower().Equals(input.PlannedToSellAssetType));
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
            return new PagedResultDto<PlannedToSellAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PlannedToSellAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(PlannedToSellAssetInput plannedToSellAssetInput)
        {
            var plannedToSellAssetEntity = ObjectMapper.Map<PlannedToSellAsset>(plannedToSellAssetInput);
            SetAuditInsert(plannedToSellAssetEntity);
            plannedToSellAssetRepository.Insert(plannedToSellAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(PlannedToSellAssetInput plannedToSellAssetInput)
        {
            var plannedToSellAssetEntity = plannedToSellAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == plannedToSellAssetInput.Id);
            if (plannedToSellAssetEntity == null)
            {
            }
            ObjectMapper.Map(plannedToSellAssetInput, plannedToSellAssetEntity);
            SetAuditEdit(plannedToSellAssetEntity);
            plannedToSellAssetRepository.Update(plannedToSellAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
