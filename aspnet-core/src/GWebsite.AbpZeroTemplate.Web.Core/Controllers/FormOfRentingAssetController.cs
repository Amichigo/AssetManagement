using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FormOfRentingAssetController : GWebsiteControllerBase
    {
        private readonly IFormOfRentingAssetAppService formOfRentingAssetAppService;

        public FormOfRentingAssetController(IFormOfRentingAssetAppService formOfRentingAssetAppService)
        {
            this.formOfRentingAssetAppService = formOfRentingAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<FormOfRentingAssetDto> GetFormOfRentingAssetsByFilter(FormOfRentingAssetFilter formOfRentingAssetFilter)
        {
            return formOfRentingAssetAppService.GetFormOfRentingAssets(formOfRentingAssetFilter);
        }

        [HttpGet]
        public FormOfRentingAssetInput GetFormOfRentingAssetForEdit(int id)
        {
            return formOfRentingAssetAppService.GetFormOfRentingAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditFormOfRentingAsset([FromBody] FormOfRentingAssetInput input)
        {
            formOfRentingAssetAppService.CreateOrEditFormOfRentingAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteFormOfRentingAsset(int id)
        {
            formOfRentingAssetAppService.DeleteFormOfRentingAsset(id);
        }

        [HttpGet]
        public FormOfRentingAssetForViewDto GetFormOfRentingAssetForView(int id)
        {
            return formOfRentingAssetAppService.GetFormOfRentingAssetForView(id);
        }
    }
}

