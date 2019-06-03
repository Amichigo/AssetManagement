using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset;
using GWebsite.AbpZeroTemplate.Application.Share.Asset.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class AssetController : GWebsiteControllerBase
    {
        private readonly IAssetAppService assetAppService;

        public AssetController(IAssetAppService assetAppService)
        {
            this.assetAppService = assetAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter assetFilter)
        {
            return assetAppService.GetAssets(assetFilter);
        }

        [HttpGet]
        public AssetInput GetAssetForEdit(int id)
        {
            return assetAppService.GetAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAsset([FromBody] AssetInput input)
        {
            assetAppService.CreateOrEditAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAsset(int id)
        {
            assetAppService.DeleteAsset(id);
        }

        [HttpGet]
        public AssetForViewDto GetAssetForView(int id)
        {
            return assetAppService.GetAssetForView(id);
        }
    }

}
