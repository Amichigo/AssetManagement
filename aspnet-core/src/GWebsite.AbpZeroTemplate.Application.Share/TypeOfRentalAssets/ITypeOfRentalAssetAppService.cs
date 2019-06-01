using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets
{
    public interface ITypeOfRentalAssetAppService
    {

        void CreateOrEditTypeOfRentalAsset(TypeOfRentalAssetInput typeOfRentalAssetInput);
        TypeOfRentalAssetInput GetTypeOfRentalAssetForEdit(int id);
        void DeleteTypeOfRentalAsset(int id);
        PagedResultDto<TypeOfRentalAssetDto> GetTypeOfRentalAssets(TypeOfRentalAssetFilter input);
        TypeOfRentalAssetForViewDto GetTypeOfRentalAssetForView(int id);
    }
}
