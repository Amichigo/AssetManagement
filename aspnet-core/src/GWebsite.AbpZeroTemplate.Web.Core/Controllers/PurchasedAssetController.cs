using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PurchasedAssetController : GWebsiteControllerBase
    {
        private readonly IPurchasedAssetAppService customerAppService;

        public PurchasedAssetController(IPurchasedAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<PurchasedAssetDto> GetDetailedData(PurchasedAssetFilter customerFilter)
        {
            return customerAppService.GetPurchasedAssets(customerFilter);
        }

        [HttpGet]
        public PurchasedAssetGeneralStatistics GetGeneralStatisticsData(PurchasedAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public PurchasedAssetInput GetPurchasedAssetForEdit(int id)
        //{
        //    return customerAppService.GetPurchasedAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditPurchasedAsset([FromBody] PurchasedAssetInput input)
        //{
        //    customerAppService.CreateOrEditPurchasedAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeletePurchasedAsset(int id)
        //{
        //    customerAppService.DeletePurchasedAsset(id);
        //}

        //[HttpGet]
        //public PurchasedAssetForViewDto GetPurchasedAssetForView(int id)
        //{
        //    return customerAppService.GetPurchasedAssetForView(id);
        //}
    }
}
