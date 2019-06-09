using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SoldAssets;
using GWebsite.AbpZeroTemplate.Application.Share.SoldAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SoldAssetController : GWebsiteControllerBase
    {
        private readonly ISoldAssetAppService customerAppService;

        public SoldAssetController(ISoldAssetAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<SoldAssetDto> GetDetailedData(SoldAssetFilter customerFilter)
        {
            return customerAppService.GetSoldAssets(customerFilter);
        }

        [HttpGet]
        public SoldAssetGeneralStatistics GetGeneralStatisticsData(SoldAssetFilter customerFilter)
        {
            return customerAppService.GetGeneralStatistics(customerFilter);
        }

        //[HttpGet]
        //public SoldAssetInput GetSoldAssetForEdit(int id)
        //{
        //    return customerAppService.GetSoldAssetForEdit(id);
        //}

        //[HttpPost]
        //public void CreateOrEditSoldAsset([FromBody] SoldAssetInput input)
        //{
        //    customerAppService.CreateOrEditSoldAsset(input);
        //}

        //[HttpDelete("{id}")]
        //public void DeleteSoldAsset(int id)
        //{
        //    customerAppService.DeleteSoldAsset(id);
        //}

        //[HttpGet]
        //public SoldAssetForViewDto GetSoldAssetForView(int id)
        //{
        //    return customerAppService.GetSoldAssetForView(id);
        //}
    }
}
