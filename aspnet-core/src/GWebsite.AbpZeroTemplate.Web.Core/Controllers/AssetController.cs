using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetController : GWebsiteControllerBase
    {
        private readonly IAssetAppService AssetAppService;

        public AssetController(IAssetAppService AssetAppService)
        {
            this.AssetAppService = AssetAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter AssetFilter)
        {
            return AssetAppService.GetAssets(AssetFilter);
        }

        [HttpGet]
        public AssetInput GetAssetForEdit(int id)
        {
            return AssetAppService.GetAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAsset([FromBody] AssetInput input)
        {
            AssetAppService.CreateOrEditAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAsset(int id)
        {
            AssetAppService.DeleteAsset(id);
        }

        [HttpGet]
        public AssetForViewDto GetAssetForView(int id)
        {
            return AssetAppService.GetAssetForView(id);
        }
    }
}
