using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets;
using GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.OperatingAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class OperatingAssetAppService : GWebsiteAppServiceBase, IOperatingAssetAppService
    {
        private readonly IRepository<OperatingAsset> operatingAssetRepository;

        public OperatingAssetAppService(IRepository<OperatingAsset> operatingAssetRepository)
        {
            this.operatingAssetRepository = operatingAssetRepository;
        }

        #region Public Method

        public void CreateOrEditOperatingAsset(OperatingAssetInput operatingAssetInput)
        {
            if (operatingAssetInput.Id == 0)
            {
                Create(operatingAssetInput);
            }
            else
            {
                Update(operatingAssetInput);
            }
        }

        public void DeleteOperatingAsset(int id)
        {
            var operatingAssetEntity = operatingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (operatingAssetEntity != null)
            {
                operatingAssetEntity.IsDelete = true;
                operatingAssetRepository.Update(operatingAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private bool isValidDouble(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public OperatingAssetGeneralStatistics GetGeneralStatistics(OperatingAssetFilter input)
        {
            var statistics = new OperatingAssetGeneralStatistics();
            double MIN_QUANTITY = 0;
            double MIN_AMOUNT = 100000;
            double MAX_QUANTITY = 100;
            double MAX_AMOUNT = 1000000;

            // ****** GIÁ TRỊ MẶC ĐỊNH ******
            // SỐ LƯỢNG
            // Tổng số lượng tài sản
            var previousQuantity = 0.0;
            var currentQuantity = 0.0;
            var quantityRatio = 0.0;

            // Tổng số lượng tài sản đang ở trong kho
            var previousInWareQuantity = 0.0;
            var currentInWareQuantity = 0.0;
            var inWareQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành nói chung
            var previousInOperationQuantity = 0.0;
            var currentInOperationQuantity = 0.0;
            var inOperationQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành, có tính khấu hao nói chung
            var previousInOperationDepreciatingQuantity = 0.0;
            var currentInOperationDepreciatingQuantity = 0.0;
            var inOperationDepreciatingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành, không tính khấu hao nói chung
            var previousInOperationNotDepreciatingQuantity = 0.0;
            var currentInOperationNotDepreciatingQuantity = 0.0;
            var inOperationNotDepreciatingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng
            var previousInOperationAndUsingQuantity = 0.0;
            var currentInOperationAndUsingQuantity = 0.0;
            var inOperationAndUsingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng, có tính khấu hao
            var previousInOperationAndUsingDepreciatingQuantity = 0.0;
            var currentInOperationAndUsingDepreciatingQuantity = 0.0;
            var inOperationAndUsingDepreciatingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng nhưng, không tính khấu hao
            var previousInOperationAndUsingNotDepreciatingQuantity = 0.0;
            var currentInOperationAndUsingNotDepreciatingQuantity = 0.0;
            var inOperationAndUsingNotDepreciatingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng
            var previousInOperationButNotUsingQuantity = 0.0;
            var currentInOperationButNotUsingQuantity = 0.0;
            var inOperationButNotUsingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            var previousInOperationButNotUsingDepreciatingQuantity = 0.0;
            var currentInOperationButNotUsingDepreciatingQuantity = 0.0;
            var inOperationButNotUsingDepreciatingQuantityRatio = 0.0;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
            var previousInOperationButNotUsingNotDepreciatingQuantity = 0.0;
            var currentInOperationButNotUsingNotDepreciatingQuantity = 0.0;
            var inOperationButNotUsingNotDepreciatingQuantityRatio = 0.0;

            // GIÁ TRỊ
            // Tổng giá trị đã đầu tư
            var previousAmount = 0.0;
            var currentAmount = 0.0;
            var amountRatio = 0.0;

            // Tổng giá trị nguyên giá của tài sản nói chung
            var previousOriginalAmount = 0.0;
            var currentOriginalAmount = 0.0;
            var originalAmountRatio = 0.0;

            // Tổng giá trị trích cho khấu hao
            var previousDepreciatedAmount = 0.0;
            var currentDepreciatedAmount = 0.0;
            var depreciatedAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang ở trong kho
            var previousInWareOriginalAmount = 0.0;
            var currentInWareOriginalAmount = 0.0;
            var inWareOriginalAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nói chung
            var previousInOperationOriginalAmount = 0.0;
            var currentInOperationOriginalAmount = 0.0;
            var inOperationOriginalAmountRatio = 0.0;

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nói chung
            var previousInOperationDepreciatingAmount = 0.0;
            var currentInOperationDepreciatingAmount = 0.0;
            var inOperationDepreciatingAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng
            var previousInOperationAndUsingOriginalAmount = 0.0;
            var currentInOperationAndUsingOriginalAmount = 0.0;
            var inOperationAndUsingOriginalAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
            var previousInOperationAndUsingDepreciatingOriginalAmount = 0.0;
            var currentInOperationAndUsingDepreciatingOriginalAmount = 0.0;
            var inOperationAndUsingDepreciatingOriginalAmountRatio = 0.0;

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
            var previousInOperationAndUsingDepreciatingAmount = 0.0;
            var currentInOperationAndUsingDepreciatingAmount = 0.0;
            var inOperationAndUsingDepreciatingAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, không tính khấu hao
            var previousInOperationAndUsingNotDepreciatingOriginalAmount = 0.0;
            var currentInOperationAndUsingNotDepreciatingOriginalAmount = 0.0;
            var inOperationAndUsingNotDepreciatingOriginalAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng
            var previousInOperationAndNotUsingOriginalAmount = 0.0;
            var currentInOperationAndNotUsingOriginalAmount = 0.0;
            var inOperationAndNotUsingOriginalAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            var previousInOperationAndNotUsingDepreciatingOriginalAmount = 0.0;
            var currentInOperationAndNotUsingDepreciatingOriginalAmount = 0.0;
            var inOperationAndNotUsingDepreciatingOriginalAmountRatio = 0.0;

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            var previousInOperationAndNotUsingDepreciatingAmount = 0.0;
            var currentInOperationAndNotUsingDepreciatingAmount = 0.0;
            var inOperationAndNotUsingDepreciatingAmountRatio = 0.0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
            var previousInOperationAndNotUsingNotDepreciatingOriginalAmount = 0.0;
            var currentInOperationAndNotUsingNotDepreciatingOriginalAmount = 0.0;
            var inOperationAndNotUsingNotDepreciatingOriginalAmountRatio = 0.0;

            // ****** GIÁ TRỊ TẠM ******
            // SỐ LƯỢNG 
            // Tổng số lượng tài sản
            previousQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            quantityRatio = Math.Round(((currentQuantity - previousQuantity) / previousQuantity) * 100, 2);

            // Tổng số lượng tài sản đang ở trong kho
            previousInWareQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInWareQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inWareQuantityRatio = Math.Round(((currentInWareQuantity - previousInWareQuantity) / previousInWareQuantity) * 100, 2);

            // Tổng số lượng tài sản đang được vận hành nói chung 
            previousInOperationQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationQuantityRatio = Math.Round(((currentInOperationQuantity - previousInOperationQuantity) / previousInOperationQuantity) * 100, 2);

            // Tổng số lượng tài sản đang được vận hành, có tính khấu hao nói chung
            previousInOperationDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationDepreciatingQuantityRatio = Math.Round(((currentInOperationDepreciatingQuantity - previousInOperationDepreciatingQuantity) / previousInOperationDepreciatingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành, không tính khấu hao nói chung
            previousInOperationNotDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationNotDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationNotDepreciatingQuantityRatio = Math.Round(((currentInOperationNotDepreciatingQuantity - previousInOperationNotDepreciatingQuantity) / previousInOperationNotDepreciatingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng
            previousInOperationAndUsingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationAndUsingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationAndUsingQuantityRatio = Math.Round(((currentInOperationAndUsingQuantity - previousInOperationAndUsingQuantity) / previousInOperationAndUsingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng, có tính khấu hao
            previousInOperationAndUsingDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationAndUsingDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationAndUsingDepreciatingQuantityRatio = Math.Round(((currentInOperationAndUsingDepreciatingQuantity - previousInOperationAndUsingDepreciatingQuantity) / previousInOperationAndUsingDepreciatingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng nhưng, không tính khấu hao
            previousInOperationAndUsingNotDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationAndUsingNotDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationAndUsingNotDepreciatingQuantityRatio = Math.Round(((currentInOperationAndUsingNotDepreciatingQuantity - previousInOperationAndUsingNotDepreciatingQuantity) / previousInOperationAndUsingNotDepreciatingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng
            previousInOperationButNotUsingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationButNotUsingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationButNotUsingQuantityRatio = Math.Round(((currentInOperationButNotUsingQuantity - previousInOperationButNotUsingQuantity) / previousInOperationButNotUsingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            previousInOperationButNotUsingDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationButNotUsingDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationButNotUsingDepreciatingQuantityRatio = Math.Round(((currentInOperationButNotUsingDepreciatingQuantity - previousInOperationButNotUsingDepreciatingQuantity) / previousInOperationButNotUsingDepreciatingQuantity) * 100, 2); ;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
            previousInOperationButNotUsingNotDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            currentInOperationButNotUsingNotDepreciatingQuantity = GetRandomNumber(MIN_QUANTITY, MAX_QUANTITY);
            inOperationButNotUsingNotDepreciatingQuantityRatio = Math.Round(((currentInOperationButNotUsingNotDepreciatingQuantity - previousInOperationButNotUsingNotDepreciatingQuantity) / previousInOperationButNotUsingNotDepreciatingQuantity) * 100, 2); ;

            // GIÁ TRỊ
            // Tổng giá trị đã đầu tư
            previousAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            amountRatio = Math.Round(((currentAmount - previousAmount) / previousAmount) * 100, 2);

            // Tổng giá trị nguyên giá của tài sản nói chung
            previousOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            originalAmountRatio = Math.Round(((currentOriginalAmount - previousOriginalAmount) / previousOriginalAmount) * 100, 2);

            // Tổng giá trị trích cho khấu hao
            previousDepreciatedAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentDepreciatedAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            depreciatedAmountRatio = Math.Round(((currentDepreciatedAmount - previousDepreciatedAmount) / previousDepreciatedAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang ở trong kho
            previousInWareOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInWareOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inWareOriginalAmountRatio = Math.Round(((currentInWareOriginalAmount - previousInWareOriginalAmount) / previousInWareOriginalAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nói chung
            previousInOperationOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationOriginalAmountRatio = Math.Round(((currentInOperationOriginalAmount - previousInOperationOriginalAmount) / previousInOperationOriginalAmount) * 100, 2);

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nói chung            
            previousInOperationDepreciatingAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationDepreciatingAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationDepreciatingAmountRatio = Math.Round(((currentInOperationDepreciatingAmount - previousInOperationDepreciatingAmount) / previousInOperationDepreciatingAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng
            previousInOperationAndUsingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndUsingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndUsingOriginalAmountRatio = Math.Round(((currentInOperationAndUsingOriginalAmount - previousInOperationAndUsingOriginalAmount) / previousInOperationAndUsingOriginalAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
            previousInOperationAndUsingDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndUsingDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndUsingDepreciatingOriginalAmountRatio = Math.Round(((currentInOperationAndUsingDepreciatingOriginalAmount - previousInOperationAndUsingDepreciatingOriginalAmount) / previousInOperationAndUsingDepreciatingOriginalAmount) * 100, 2);

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
            previousInOperationAndUsingDepreciatingAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndUsingDepreciatingAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndUsingDepreciatingAmountRatio = Math.Round(((currentInOperationAndUsingDepreciatingAmount - previousInOperationAndUsingDepreciatingAmount) / previousInOperationAndUsingDepreciatingAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, không tính khấu hao
            previousInOperationAndUsingNotDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndUsingNotDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndUsingNotDepreciatingOriginalAmountRatio = Math.Round(((currentInOperationAndUsingNotDepreciatingOriginalAmount - previousInOperationAndUsingNotDepreciatingOriginalAmount) / previousInOperationAndUsingNotDepreciatingOriginalAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng
            previousInOperationAndNotUsingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndNotUsingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndNotUsingOriginalAmountRatio = Math.Round(((currentInOperationAndNotUsingOriginalAmount - previousInOperationAndNotUsingOriginalAmount) / previousInOperationAndNotUsingOriginalAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            previousInOperationAndNotUsingDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndNotUsingDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndNotUsingDepreciatingOriginalAmountRatio = Math.Round(((currentInOperationAndNotUsingDepreciatingOriginalAmount - previousInOperationAndNotUsingDepreciatingOriginalAmount) / previousInOperationAndNotUsingDepreciatingOriginalAmount) * 100, 2);

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            previousInOperationAndNotUsingDepreciatingAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndNotUsingDepreciatingAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndNotUsingDepreciatingAmountRatio = Math.Round(((currentInOperationAndNotUsingDepreciatingAmount - previousInOperationAndNotUsingDepreciatingAmount) / previousInOperationAndNotUsingDepreciatingAmount) * 100, 2);

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
            previousInOperationAndNotUsingNotDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            currentInOperationAndNotUsingNotDepreciatingOriginalAmount = GetRandomNumber(MIN_AMOUNT, MAX_AMOUNT);
            inOperationAndNotUsingNotDepreciatingOriginalAmountRatio = Math.Round(((currentInOperationAndNotUsingNotDepreciatingOriginalAmount - previousInOperationAndNotUsingNotDepreciatingOriginalAmount) / previousInOperationAndNotUsingNotDepreciatingOriginalAmount) * 100, 2);


            // ****** GIÁ TRỊ TRẢ VỀ ******
            // SỐ LƯỢNG
            // Tổng số lượng tài sản
            statistics.PreviousQuantity = isValidDouble(previousQuantity) ? previousQuantity : 0;
            statistics.CurrentQuantity = isValidDouble(currentQuantity) ? currentQuantity : 0;
            statistics.QuantityRatio = isValidDouble(quantityRatio) ? quantityRatio : 0;

            // Tổng số lượng tài sản đang ở trong kho
            statistics.PreviousInWareQuantity = isValidDouble(previousInWareQuantity) ? previousInWareQuantity : 0;
            statistics.CurrentInWareQuantity = isValidDouble(currentInWareQuantity) ? currentInWareQuantity : 0;
            statistics.InWareQuantityRatio = isValidDouble(inWareQuantityRatio) ? inWareQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành nói chung
            statistics.PreviousInOperationQuantity = isValidDouble(previousInOperationQuantity) ? previousInOperationQuantity : 0;
            statistics.CurrentInOperationQuantity = isValidDouble(currentInOperationQuantity) ? currentInOperationQuantity : 0;
            statistics.InOperationQuantityRatio = isValidDouble(inOperationQuantityRatio) ? inOperationQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành, có tính khấu hao nói chung
            statistics.PreviousInOperationDepreciatingQuantity = isValidDouble(previousInOperationDepreciatingQuantity) ? previousInOperationDepreciatingQuantity : 0;
            statistics.CurrentInOperationDepreciatingQuantity = isValidDouble(currentInOperationDepreciatingQuantity) ? currentInOperationDepreciatingQuantity : 0;
            statistics.InOperationDepreciatingQuantityRatio = isValidDouble(inOperationDepreciatingQuantityRatio) ? inOperationDepreciatingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành, không tính khấu hao nói chung
            statistics.PreviousInOperationNotDepreciatingQuantity = isValidDouble(previousInOperationNotDepreciatingQuantity) ? previousInOperationNotDepreciatingQuantity : 0;
            statistics.CurrentInOperationNotDepreciatingQuantity = isValidDouble(currentInOperationNotDepreciatingQuantity) ? currentInOperationNotDepreciatingQuantity : 0;
            statistics.InOperationNotDepreciatingQuantityRatio = isValidDouble(inOperationNotDepreciatingQuantityRatio) ? inOperationNotDepreciatingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng
            statistics.PreviousInOperationAndUsingQuantity = isValidDouble(previousInOperationAndUsingQuantity) ? previousInOperationAndUsingQuantity : 0;
            statistics.CurrentInOperationAndUsingQuantity = isValidDouble(currentInOperationAndUsingQuantity) ? currentInOperationAndUsingQuantity : 0;
            statistics.InOperationAndUsingQuantityRatio = isValidDouble(inOperationAndUsingQuantityRatio) ? inOperationAndUsingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng, có tính khấu hao
            statistics.PreviousInOperationAndUsingDepreciatingQuantity = isValidDouble(previousInOperationAndUsingDepreciatingQuantity) ? previousInOperationAndUsingDepreciatingQuantity : 0;
            statistics.CurrentInOperationAndUsingDepreciatingQuantity = isValidDouble(currentInOperationAndUsingDepreciatingQuantity) ? currentInOperationAndUsingDepreciatingQuantity : 0;
            statistics.InOperationAndUsingDepreciatingQuantityRatio = isValidDouble(inOperationAndUsingDepreciatingQuantityRatio) ? inOperationAndUsingDepreciatingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành và được sử dụng, không tính khấu hao
            statistics.PreviousInOperationAndUsingNotDepreciatingQuantity = isValidDouble(previousInOperationAndUsingNotDepreciatingQuantity) ? previousInOperationAndUsingNotDepreciatingQuantity : 0;
            statistics.CurrentInOperationAndUsingNotDepreciatingQuantity = isValidDouble(currentInOperationAndUsingNotDepreciatingQuantity) ? currentInOperationAndUsingNotDepreciatingQuantity : 0;
            statistics.InOperationAndUsingNotDepreciatingQuantityRatio = isValidDouble(inOperationAndUsingNotDepreciatingQuantityRatio) ? inOperationAndUsingNotDepreciatingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng
            statistics.PreviousInOperationButNotUsingQuantity = isValidDouble(previousInOperationButNotUsingQuantity) ? previousInOperationButNotUsingQuantity : 0;
            statistics.CurrentInOperationButNotUsingQuantity = isValidDouble(currentInOperationButNotUsingQuantity) ? currentInOperationButNotUsingQuantity : 0;
            statistics.InOperationButNotUsingQuantityRatio = isValidDouble(inOperationButNotUsingQuantityRatio) ? inOperationButNotUsingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng có tính khấu hao
            statistics.PreviousInOperationButNotUsingDepreciatingQuantity = isValidDouble(previousInOperationButNotUsingDepreciatingQuantity) ? previousInOperationButNotUsingDepreciatingQuantity : 0;
            statistics.CurrentInOperationButNotUsingDepreciatingQuantity = isValidDouble(currentInOperationButNotUsingDepreciatingQuantity) ? currentInOperationButNotUsingDepreciatingQuantity : 0;
            statistics.InOperationButNotUsingDepreciatingQuantityRatio = isValidDouble(inOperationButNotUsingDepreciatingQuantityRatio) ? inOperationButNotUsingDepreciatingQuantityRatio : 0;

            // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
            statistics.PreviousInOperationButNotUsingNotDepreciatingQuantity = isValidDouble(previousInOperationButNotUsingNotDepreciatingQuantity) ? previousInOperationButNotUsingNotDepreciatingQuantity : 0;
            statistics.CurrentInOperationButNotUsingNotDepreciatingQuantity = isValidDouble(currentInOperationButNotUsingNotDepreciatingQuantity) ? currentInOperationButNotUsingNotDepreciatingQuantity : 0;
            statistics.InOperationButNotUsingNotDepreciatingQuantityRatio = isValidDouble(inOperationButNotUsingNotDepreciatingQuantityRatio) ? inOperationButNotUsingNotDepreciatingQuantityRatio : 0;

            // GIÁ TRỊ
            // Tổng giá trị đã đầu tư
            statistics.PreviousAmount = isValidDouble(previousAmount) ? previousAmount : 0;
            statistics.CurrentAmount = isValidDouble(currentAmount) ? currentAmount : 0;
            statistics.AmountRatio = isValidDouble(amountRatio) ? amountRatio : 0;

            // Tổng giá trị nguyên giá của tài sản nói chung
            statistics.PreviousOriginalAmount = isValidDouble(previousOriginalAmount) ? previousOriginalAmount : 0;
            statistics.CurrentOriginalAmount = isValidDouble(currentOriginalAmount) ? currentOriginalAmount : 0;
            statistics.OriginalAmountRatio = isValidDouble(originalAmountRatio) ? originalAmountRatio : 0;

            // Tổng giá trị trích cho khấu hao
            statistics.PreviousDepreciatedAmount = isValidDouble(previousDepreciatedAmount) ? previousDepreciatedAmount : 0;
            statistics.CurrentDepreciatedAmount = isValidDouble(currentDepreciatedAmount) ? currentDepreciatedAmount : 0;
            statistics.DepreciatedAmountRatio = isValidDouble(depreciatedAmountRatio) ? depreciatedAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang ở trong kho
            statistics.PreviousInWareOriginalAmount = isValidDouble(previousInWareOriginalAmount) ? previousInWareOriginalAmount : 0;
            statistics.CurrentInWareOriginalAmount = isValidDouble(currentInWareOriginalAmount) ? currentInWareOriginalAmount : 0;
            statistics.InWareOriginalAmountRatio = isValidDouble(inWareOriginalAmountRatio) ? inWareOriginalAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nói chung
            statistics.PreviousInOperationOriginalAmount = isValidDouble(previousInOperationOriginalAmount) ? previousInOperationOriginalAmount : 0;
            statistics.CurrentInOperationOriginalAmount = isValidDouble(currentInOperationOriginalAmount) ? currentInOperationOriginalAmount : 0;
            statistics.InOperationOriginalAmountRatio = isValidDouble(inOperationOriginalAmountRatio) ? inOperationOriginalAmountRatio : 0;

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nói chung
            statistics.PreviousInOperationDepreciatingAmount = isValidDouble(previousInOperationDepreciatingAmount) ? previousInOperationDepreciatingAmount : 0;
            statistics.CurrentInOperationDepreciatingAmount = isValidDouble(currentInOperationDepreciatingAmount) ? currentInOperationDepreciatingAmount : 0;
            statistics.InOperationDepreciatingAmountRatio = isValidDouble(inOperationDepreciatingAmountRatio) ? inOperationDepreciatingAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng
            statistics.PreviousInOperationAndUsingOriginalAmount = isValidDouble(previousInOperationAndUsingOriginalAmount) ? previousInOperationAndUsingOriginalAmount : 0;
            statistics.CurrentInOperationAndUsingOriginalAmount = isValidDouble(currentInOperationAndUsingOriginalAmount) ? currentInOperationAndUsingOriginalAmount : 0;
            statistics.InOperationAndUsingOriginalAmountRatio = isValidDouble(inOperationAndUsingOriginalAmountRatio) ? inOperationAndUsingOriginalAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
            statistics.PreviousInOperationAndUsingDepreciatingOriginalAmount = isValidDouble(previousInOperationAndUsingDepreciatingOriginalAmount) ? previousInOperationAndUsingDepreciatingOriginalAmount : 0;
            statistics.CurrentInOperationAndUsingDepreciatingOriginalAmount = isValidDouble(currentInOperationAndUsingDepreciatingOriginalAmount) ? currentInOperationAndUsingDepreciatingOriginalAmount : 0;
            statistics.InOperationAndUsingDepreciatingOriginalAmountRatio = isValidDouble(inOperationAndUsingDepreciatingOriginalAmountRatio) ? inOperationAndUsingDepreciatingOriginalAmountRatio : 0;

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
            statistics.PreviousInOperationAndUsingDepreciatingAmount = isValidDouble(previousInOperationAndUsingDepreciatingAmount) ? previousInOperationAndUsingDepreciatingAmount : 0;
            statistics.CurrentInOperationAndUsingDepreciatingAmount = isValidDouble(currentInOperationAndUsingDepreciatingAmount) ? currentInOperationAndUsingDepreciatingAmount : 0;
            statistics.InOperationAndUsingDepreciatingAmountRatio = isValidDouble(inOperationAndUsingDepreciatingAmountRatio) ? inOperationAndUsingDepreciatingAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, không tính khấu hao
            statistics.PreviousInOperationAndUsingNotDepreciatingOriginalAmount = isValidDouble(previousInOperationAndUsingNotDepreciatingOriginalAmount) ? previousInOperationAndUsingNotDepreciatingOriginalAmount : 0;
            statistics.CurrentInOperationAndUsingNotDepreciatingOriginalAmount = isValidDouble(currentInOperationAndUsingNotDepreciatingOriginalAmount) ? currentInOperationAndUsingNotDepreciatingOriginalAmount : 0;
            statistics.InOperationAndUsingNotDepreciatingOriginalAmountRatio = isValidDouble(inOperationAndUsingNotDepreciatingOriginalAmountRatio) ? inOperationAndUsingNotDepreciatingOriginalAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng
            statistics.PreviousInOperationAndNotUsingOriginalAmount = isValidDouble(previousInOperationAndNotUsingOriginalAmount) ? previousInOperationAndNotUsingOriginalAmount : 0;
            statistics.CurrentInOperationAndNotUsingOriginalAmount = isValidDouble(currentInOperationAndNotUsingOriginalAmount) ? currentInOperationAndNotUsingOriginalAmount : 0;
            statistics.InOperationAndNotUsingOriginalAmountRatio = isValidDouble(inOperationAndNotUsingOriginalAmountRatio) ? inOperationAndNotUsingOriginalAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            statistics.PreviousInOperationAndNotUsingDepreciatingOriginalAmount = isValidDouble(previousInOperationAndNotUsingDepreciatingOriginalAmount) ? previousInOperationAndNotUsingDepreciatingOriginalAmount : 0;
            statistics.CurrentInOperationAndNotUsingDepreciatingOriginalAmount = isValidDouble(currentInOperationAndNotUsingDepreciatingOriginalAmount) ? currentInOperationAndNotUsingDepreciatingOriginalAmount : 0;
            statistics.InOperationAndNotUsingDepreciatingOriginalAmountRatio = isValidDouble(inOperationAndNotUsingDepreciatingOriginalAmountRatio) ? inOperationAndNotUsingDepreciatingOriginalAmountRatio : 0;

            // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
            statistics.PreviousInOperationAndNotUsingDepreciatingAmount = isValidDouble(previousInOperationAndNotUsingDepreciatingAmount) ? previousInOperationAndNotUsingDepreciatingAmount : 0;
            statistics.CurrentInOperationAndNotUsingDepreciatingAmount = isValidDouble(currentInOperationAndNotUsingDepreciatingAmount) ? currentInOperationAndNotUsingDepreciatingAmount : 0;
            statistics.InOperationAndNotUsingDepreciatingAmountRatio = isValidDouble(inOperationAndNotUsingDepreciatingAmountRatio) ? inOperationAndNotUsingDepreciatingAmountRatio : 0;

            // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
            statistics.PreviousInOperationAndNotUsingNotDepreciatingOriginalAmount = isValidDouble(previousInOperationAndNotUsingNotDepreciatingOriginalAmount) ? previousInOperationAndNotUsingNotDepreciatingOriginalAmount : 0;
            statistics.CurrentInOperationAndNotUsingNotDepreciatingOriginalAmount = isValidDouble(currentInOperationAndNotUsingNotDepreciatingOriginalAmount) ? currentInOperationAndNotUsingNotDepreciatingOriginalAmount : 0;
            statistics.InOperationAndNotUsingNotDepreciatingOriginalAmountRatio = isValidDouble(inOperationAndNotUsingNotDepreciatingOriginalAmountRatio) ? inOperationAndNotUsingNotDepreciatingOriginalAmountRatio : 0;

            return statistics;
        }

        public OperatingAssetInput GetOperatingAssetForEdit(int id)
        {
            var operatingAssetEntity = operatingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (operatingAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<OperatingAssetInput>(operatingAssetEntity);
        }

        public OperatingAssetForViewDto GetOperatingAssetForView(int id)
        {
            var operatingAssetEntity = operatingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (operatingAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<OperatingAssetForViewDto>(operatingAssetEntity);
        }

        public PagedResultDto<OperatingAssetDto> GetOperatingAssets(OperatingAssetFilter input)
        {
            var query = operatingAssetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.PreviousStartingDate.HasValue && input.CurrentEndingDate.HasValue)
            {
                query = query.Where(x => x.RecordedDate >= input.PreviousStartingDate && x.RecordedDate <= input.CurrentEndingDate);
                //query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }

            // filter by value
            //if (input.OperatingAssetType != null)
            //{
            //    query = query.Where(x => x.OperatingAssetType.ToLower().Equals(input.OperatingAssetType));
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
            return new PagedResultDto<OperatingAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<OperatingAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(OperatingAssetInput operatingAssetInput)
        {
            var operatingAssetEntity = ObjectMapper.Map<OperatingAsset>(operatingAssetInput);
            SetAuditInsert(operatingAssetEntity);
            operatingAssetRepository.Insert(operatingAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(OperatingAssetInput operatingAssetInput)
        {
            var operatingAssetEntity = operatingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == operatingAssetInput.Id);
            if (operatingAssetEntity == null)
            {
            }
            ObjectMapper.Map(operatingAssetInput, operatingAssetEntity);
            SetAuditEdit(operatingAssetEntity);
            operatingAssetRepository.Update(operatingAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
