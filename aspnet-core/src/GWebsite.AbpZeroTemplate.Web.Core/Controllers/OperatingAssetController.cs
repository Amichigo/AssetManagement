using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets;
using GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OperatingAssetController : GWebsiteControllerBase
    {
        private readonly IOperatingAssetAppService customerAppService;

        public OperatingAssetController(IOperatingAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<OperatingAssetDto> GetDetailedData(OperatingAssetFilter customerFilter)
        {
            return customerAppService.GetOperatingAssets(customerFilter);
        }

        [HttpGet]
        public OperatingAssetGeneralStatistics GetGeneralStatisticsData(OperatingAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public OperatingAssetInput GetOperatingAssetForEdit(int id)
        //{
        //    return customerAppService.GetOperatingAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditOperatingAsset([FromBody] OperatingAssetInput input)
        //{
        //    customerAppService.CreateOrEditOperatingAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeleteOperatingAsset(int id)
        //{
        //    customerAppService.DeleteOperatingAsset(id);
        //}

        //[HttpGet]
        //public OperatingAssetForViewDto GetOperatingAssetForView(int id)
        //{
        //    return customerAppService.GetOperatingAssetForView(id);
        //}
    }
}
