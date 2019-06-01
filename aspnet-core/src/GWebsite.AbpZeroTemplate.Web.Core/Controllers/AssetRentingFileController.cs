using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetRentingFileController : GWebsiteControllerBase
    {
        private readonly IAssetRentingFileAppService assetRentingFileAppService;

        public AssetRentingFileController(IAssetRentingFileAppService assetRentingFileAppService)
        {
            this.assetRentingFileAppService = assetRentingFileAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetRentingFileDto> GetAssetRentingFilesByFilter(AssetRentingFileFilter assetRentingFileFilter)
        {
            return assetRentingFileAppService.GetAssetRentingFiles(assetRentingFileFilter);
        }

        [HttpGet]
        public AssetRentingFileInput GetAssetRentingFileForEdit(int id)
        {
            return assetRentingFileAppService.GetAssetRentingFileForEdit(id);
        }

        [HttpGet]
        public async Task<RentalAssetOutput> GetRentalAssetComboboxForEditAsync(int id)
        {
            return await assetRentingFileAppService.GetRentalAssetComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpGet]
        public async Task<FormOfRentingAssetOutput> GetFormOfRentingAssetComboboxForEditAsync(int id)
        {
            return await assetRentingFileAppService.GetFormOfRentingAssetComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditAssetRentingFile([FromBody] AssetRentingFileInput input)
        {
            assetRentingFileAppService.CreateOrEditAssetRentingFile(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssetRentingFile(int id)
        {
            assetRentingFileAppService.DeleteAssetRentingFile(id);
        }

        [HttpGet]
        public AssetRentingFileForViewDto GetAssetRentingFileForView(int id)
        {
            return assetRentingFileAppService.GetAssetRentingFileForView(id);
        }
    }
}

