using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets;
using GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MaintainedAssetController : GWebsiteControllerBase
    {
        private readonly IMaintainedAssetAppService customerAppService;

        public MaintainedAssetController(IMaintainedAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<MaintainedAssetDto> GetDetailedData(MaintainedAssetFilter customerFilter)
        {
            return customerAppService.GetMaintainedAssets(customerFilter);
        }

        [HttpGet]
        public MaintainedAssetGeneralStatistics GetGeneralStatisticsData(MaintainedAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public MaintainedAssetInput GetMaintainedAssetForEdit(int id)
        //{
        //    return customerAppService.GetMaintainedAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditMaintainedAsset([FromBody] MaintainedAssetInput input)
        //{
        //    customerAppService.CreateOrEditMaintainedAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeleteMaintainedAsset(int id)
        //{
        //    customerAppService.DeleteMaintainedAsset(id);
        //}

        //[HttpGet]
        //public MaintainedAssetForViewDto GetMaintainedAssetForView(int id)
        //{
        //    return customerAppService.GetMaintainedAssetForView(id);
        //}
    }
}
