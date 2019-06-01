using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetRentingContractController : GWebsiteControllerBase
    {
        private readonly IAssetRentingContractAppService rssetRentingContractAppService;

        public AssetRentingContractController(IAssetRentingContractAppService rssetRentingContractAppService)
        {
            this.rssetRentingContractAppService = rssetRentingContractAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetRentingContractDto> GetAssetRentingContractsByFilter(AssetRentingContractFilter rssetRentingContractFilter)
        {
            return rssetRentingContractAppService.GetAssetRentingContracts(rssetRentingContractFilter);
        }

        [HttpGet]
        public AssetRentingContractInput GetAssetRentingContractForEdit(int id)
        {
            return rssetRentingContractAppService.GetAssetRentingContractForEdit(id);
        }

        [HttpGet]
        public async Task<AssetRentingFileOutput> GetAssetRentingFileComboboxForEditAsync(int id)
        {
            return await rssetRentingContractAppService.GetAssetRentingFileComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditAssetRentingContract([FromBody] AssetRentingContractInput input)
        {
            rssetRentingContractAppService.CreateOrEditAssetRentingContract(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssetRentingContract(int id)
        {
            rssetRentingContractAppService.DeleteAssetRentingContract(id);
        }

        [HttpGet]
        public AssetRentingContractForViewDto GetAssetRentingContractForView(int id)
        {
            return rssetRentingContractAppService.GetAssetRentingContractForView(id);
        }
    }
}

