using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlannedToMaintainAssetController : GWebsiteControllerBase
    {
        private readonly IPlannedToMaintainAssetAppService customerAppService;

        public PlannedToMaintainAssetController(IPlannedToMaintainAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<PlannedToMaintainAssetDto> GetDetailedData(PlannedToMaintainAssetFilter customerFilter)
        {
            return customerAppService.GetPlannedToMaintainAssets(customerFilter);
        }

        [HttpGet]
        public PlannedToMaintainAssetGeneralStatistics GetGeneralStatisticsData(PlannedToMaintainAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public PlannedToMaintainAssetInput GetPlannedToMaintainAssetForEdit(int id)
        //{
        //    return customerAppService.GetPlannedToMaintainAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditPlannedToMaintainAsset([FromBody] PlannedToMaintainAssetInput input)
        //{
        //    customerAppService.CreateOrEditPlannedToMaintainAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeletePlannedToMaintainAsset(int id)
        //{
        //    customerAppService.DeletePlannedToMaintainAsset(id);
        //}

        //[HttpGet]
        //public PlannedToMaintainAssetForViewDto GetPlannedToMaintainAssetForView(int id)
        //{
        //    return customerAppService.GetPlannedToMaintainAssetForView(id);
        //}
    }
}
