using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TypeOfRentalAssetController : GWebsiteControllerBase
    {
        private readonly ITypeOfRentalAssetAppService typeOfRentalAssetAppService;

        public TypeOfRentalAssetController(ITypeOfRentalAssetAppService typeOfRentalAssetAppService)
        {
            this.typeOfRentalAssetAppService = typeOfRentalAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<TypeOfRentalAssetDto> GetTypeOfRentalAssetsByFilter(TypeOfRentalAssetFilter typeOfRentalAssetFilter)
        {
            return typeOfRentalAssetAppService.GetTypeOfRentalAssets(typeOfRentalAssetFilter);
        }

        [HttpGet]
        public TypeOfRentalAssetInput GetTypeOfRentalAssetForEdit(int id)
        {
            return typeOfRentalAssetAppService.GetTypeOfRentalAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTypeOfRentalAsset([FromBody] TypeOfRentalAssetInput input)
        {
            typeOfRentalAssetAppService.CreateOrEditTypeOfRentalAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTypeOfRentalAsset(int id)
        {
            typeOfRentalAssetAppService.DeleteTypeOfRentalAsset(id);
        }

        [HttpGet]
        public TypeOfRentalAssetForViewDto GetTypeOfRentalAssetForView(int id)
        {
            return typeOfRentalAssetAppService.GetTypeOfRentalAssetForView(id);
        }
    }
}

