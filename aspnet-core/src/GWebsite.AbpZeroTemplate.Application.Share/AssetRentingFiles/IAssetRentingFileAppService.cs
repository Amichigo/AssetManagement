using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;
using System.Threading.Tasks;
using System;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles
{
    public interface IAssetRentingFileAppService
    {

        void CreateOrEditAssetRentingFile(AssetRentingFileInput assetRentingFileInput);
        AssetRentingFileInput GetAssetRentingFileForEdit(int id);
        void DeleteAssetRentingFile(int id);
        PagedResultDto<AssetRentingFileDto> GetAssetRentingFiles(AssetRentingFileFilter input);
        AssetRentingFileForViewDto GetAssetRentingFileForView(int id);
        Task<RentalAssetOutput> GetRentalAssetComboboxForEditAsync(NullableIdDto input);
        Task<FormOfRentingAssetOutput> GetFormOfRentingAssetComboboxForEditAsync(NullableIdDto input);
    }
}
