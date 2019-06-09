using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlannedToSellAssetController : GWebsiteControllerBase
    {
        private readonly IPlannedToSellAssetAppService customerAppService;

        public PlannedToSellAssetController(IPlannedToSellAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<PlannedToSellAssetDto> GetDetailedData(PlannedToSellAssetFilter customerFilter)
        {
            return customerAppService.GetPlannedToSellAssets(customerFilter);
        }

        [HttpGet]
        public PlannedToSellAssetGeneralStatistics GetGeneralStatisticsData(PlannedToSellAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public PlannedToSellAssetInput GetPlannedToSellAssetForEdit(int id)
        //{
        //    return customerAppService.GetPlannedToSellAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditPlannedToSellAsset([FromBody] PlannedToSellAssetInput input)
        //{
        //    customerAppService.CreateOrEditPlannedToSellAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeletePlannedToSellAsset(int id)
        //{
        //    customerAppService.DeletePlannedToSellAsset(id);
        //}

        //[HttpGet]
        //public PlannedToSellAssetForViewDto GetPlannedToSellAssetForView(int id)
        //{
        //    return customerAppService.GetPlannedToSellAssetForView(id);
        //}
    }
}
