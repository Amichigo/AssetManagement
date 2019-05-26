using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetGroupController_05 : GWebsiteControllerBase
    {
        private readonly IAssetGroupAppService_05 assetGroupAppService;

        public AssetGroupController_05(IAssetGroupAppService_05 assetGroupAppService)
        {
            this.assetGroupAppService = assetGroupAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetGroupDto_05> GetAssetGroupByFilter(AssetGroupFilter_05 assetGroupFilter)
        {
            return assetGroupAppService.GetAssetGroups(assetGroupFilter);
        }

        [HttpGet]
        public AssetGroupOutput_05 GetAssetGroupForEdit(string id)
        {
            return assetGroupAppService.GetAssetGroupForEdit(id);
        }

        [HttpPost]
        public void CreateAssetGroup([FromBody] AssetGroupInput_05 input)
        {
            assetGroupAppService.CreateGroupAsset(input);
        }

        [HttpPost]
        public void UpdateAssetGroup([FromBody] AssetGroupUpdate_05 input)
        {
            assetGroupAppService.UpdateGroupAsset(input);
        }

        [HttpDelete("{id}")]        
        public void DeleteAssetGroup(string id)
        {
            assetGroupAppService.DeleteAssetGroup(id);
        }

        [HttpGet]
        public AssetGroupForViewDto_05 GetAssetGroupForView(string id)
        {
            return assetGroupAppService.GetAssetGroupForView(id);
        }


    }
}
