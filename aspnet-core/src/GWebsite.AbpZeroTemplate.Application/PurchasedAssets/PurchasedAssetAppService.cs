using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.PurchasedAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class PurchasedAssetAppService : GWebsiteAppServiceBase, IPurchasedAssetAppService
    {
        private readonly IRepository<PurchasedAsset> purchasedAssetRepository;

        public PurchasedAssetAppService(IRepository<PurchasedAsset> purchasedAssetRepository)
        {
            this.purchasedAssetRepository = purchasedAssetRepository;
        }

        #region Public Method

        public void CreateOrEditPurchasedAsset(PurchasedAssetInput purchasedAssetInput)
        {
            if (purchasedAssetInput.Id == 0)
            {
                Create(purchasedAssetInput);
            }
            else
            {
                Update(purchasedAssetInput);
            }
        }

        public void DeletePurchasedAsset(int id)
        {
            var purchasedAssetEntity = purchasedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (purchasedAssetEntity != null)
            {
                purchasedAssetEntity.IsDelete = true;
                purchasedAssetRepository.Update(purchasedAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        public PurchasedAssetGeneralStatistics GetGeneralStatistics(PurchasedAssetFilter input)
        {
            var statistics = new PurchasedAssetGeneralStatistics();
            var previousTotalAmount = 0.0;
            var previousTotalQuantity = 0.0;
            var currentTotalAmount = 0.0;
            var currentTotalQuantity = 0.0;
            var amountRatio = 0.0;
            var quantityRatio = 0.0;

            var query = purchasedAssetRepository.GetAll().Where(x => !x.IsDelete && x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);

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

        public PurchasedAssetInput GetPurchasedAssetForEdit(int id)
        {
            var purchasedAssetEntity = purchasedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (purchasedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PurchasedAssetInput>(purchasedAssetEntity);
        }

        public PurchasedAssetForViewDto GetPurchasedAssetForView(int id)
        {
            var purchasedAssetEntity = purchasedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (purchasedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PurchasedAssetForViewDto>(purchasedAssetEntity);
        }

        public PagedResultDto<PurchasedAssetDto> GetPurchasedAssets(PurchasedAssetFilter input)
        {
            var query = purchasedAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.PurchasedAssetType != null)
            //{
            //    query = query.Where(x => x.PurchasedAssetType.ToLower().Equals(input.PurchasedAssetType));
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
            return new PagedResultDto<PurchasedAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PurchasedAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(PurchasedAssetInput purchasedAssetInput)
        {
            var purchasedAssetEntity = ObjectMapper.Map<PurchasedAsset>(purchasedAssetInput);
            SetAuditInsert(purchasedAssetEntity);
            purchasedAssetRepository.Insert(purchasedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(PurchasedAssetInput purchasedAssetInput)
        {
            var purchasedAssetEntity = purchasedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == purchasedAssetInput.Id);
            if (purchasedAssetEntity == null)
            {
            }
            ObjectMapper.Map(purchasedAssetInput, purchasedAssetEntity);
            SetAuditEdit(purchasedAssetEntity);
            purchasedAssetRepository.Update(purchasedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
