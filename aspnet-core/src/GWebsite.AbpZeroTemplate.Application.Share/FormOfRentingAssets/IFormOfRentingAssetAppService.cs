using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets
{
    public interface IFormOfRentingAssetAppService
    {

        void CreateOrEditFormOfRentingAsset(FormOfRentingAssetInput formOfRentingAssetInput);
        FormOfRentingAssetInput GetFormOfRentingAssetForEdit(int id);
        void DeleteFormOfRentingAsset(int id);
        PagedResultDto<FormOfRentingAssetDto> GetFormOfRentingAssets(FormOfRentingAssetFilter input);
        FormOfRentingAssetForViewDto GetFormOfRentingAssetForView(int id);
    }
}
