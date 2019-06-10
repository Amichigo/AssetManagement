using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlannedToPurchaseAssetController : GWebsiteControllerBase
    {
        private readonly IPlannedToPurchaseAssetAppService customerAppService;

        public PlannedToPurchaseAssetController(IPlannedToPurchaseAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<PlannedToPurchaseAssetDto> GetDetailedData(PlannedToPurchaseAssetFilter customerFilter)
        {
            return customerAppService.GetPlannedToPurchaseAssets(customerFilter);
        }

        [HttpGet]
        public PlannedToPurchaseAssetGeneralStatistics GetGeneralStatisticsData(PlannedToPurchaseAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public PlannedToPurchaseAssetInput GetPlannedToPurchaseAssetForEdit(int id)
        //{
        //    return customerAppService.GetPlannedToPurchaseAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditPlannedToPurchaseAsset([FromBody] PlannedToPurchaseAssetInput input)
        //{
        //    customerAppService.CreateOrEditPlannedToPurchaseAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeletePlannedToPurchaseAsset(int id)
        //{
        //    customerAppService.DeletePlannedToPurchaseAsset(id);
        //}

        //[HttpGet]
        //public PlannedToPurchaseAssetForViewDto GetPlannedToPurchaseAssetForView(int id)
        //{
        //    return customerAppService.GetPlannedToPurchaseAssetForView(id);
        //}
    }
}
