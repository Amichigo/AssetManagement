using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetGroupController : GWebsiteControllerBase
    {
        private readonly IAssetGroupAppService assetGroupAppService;

        public AssetGroupController(IAssetGroupAppService assetGroupAppService)
        {
            this.assetGroupAppService = assetGroupAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetGroupDto> GetAssetGroupsByFilter(AssetGroupFilter assetGroupFilter)
        {
            return assetGroupAppService.GetAssetGroups(assetGroupFilter);
        }

        [HttpGet]
        public AssetGroupOutput GetAssetGroupsByFilterId(string assetTypeId)
        {
            return assetGroupAppService.GetAssetGroupsById(assetTypeId);
        }

        [HttpGet]
        public AssetGroupInput GetAssetGroupForEdit(int id)
        {
            return assetGroupAppService.GetAssetGroupForEdit(id);
        }

        [HttpGet]
        public async Task<TypeOfAssetOutput> GetTypeOfAssetComboboxForEditAsync(int id)
        {
            return await assetGroupAppService.GetTypeOfAssetComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditAssetGroup([FromBody] AssetGroupInput input)
        {
            assetGroupAppService.CreateOrEditAssetGroup(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssetGroup(int id)
        {
            assetGroupAppService.DeleteAssetGroup(id);
        }

        [HttpGet]
        public AssetGroupForViewDto GetAssetGroupForView(int id)
        {
            return assetGroupAppService.GetAssetGroupForView(id);
        }
    }
}

