using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets
{
    public interface ITypeOfAssetAppService
    {

        void CreateOrEditTypeOfAsset(TypeOfAssetInput typeOfAssetInput);
        TypeOfAssetInput GetTypeOfAssetForEdit(int id);
        void DeleteTypeOfAsset(int id);
        PagedResultDto<TypeOfAssetDto> GetTypeOfAssets(TypeOfAssetFilter input);
        TypeOfAssetForViewDto GetTypeOfAssetForView(int id);
    }
}
