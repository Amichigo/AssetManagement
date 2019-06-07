using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TypeOfAssetController : GWebsiteControllerBase
    {
        private readonly ITypeOfAssetAppService typeOfAssetAppService;

        public TypeOfAssetController(ITypeOfAssetAppService typeOfAssetAppService)
        {
            this.typeOfAssetAppService = typeOfAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<TypeOfAssetDto> GetTypeOfAssetsByFilter(TypeOfAssetFilter typeOfAssetFilter)
        {
            return typeOfAssetAppService.GetTypeOfAssets(typeOfAssetFilter);
        }

        [HttpGet]
        public TypeOfAssetInput GetTypeOfAssetForEdit(int id)
        {
            return typeOfAssetAppService.GetTypeOfAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTypeOfAsset([FromBody] TypeOfAssetInput input)
        {
            typeOfAssetAppService.CreateOrEditTypeOfAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTypeOfAsset(int id)
        {
            typeOfAssetAppService.DeleteTypeOfAsset(id);
        }

        [HttpGet]
        public TypeOfAssetForViewDto GetTypeOfAssetForView(int id)
        {
            return typeOfAssetAppService.GetTypeOfAssetForView(id);
        }
    }
}

