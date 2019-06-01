using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto;
using System.Threading.Tasks;
using System;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts
{
    public interface IAssetRentingContractAppService
    {

        void CreateOrEditAssetRentingContract(AssetRentingContractInput assetRentingContractInput);
        AssetRentingContractInput GetAssetRentingContractForEdit(int id);
        void DeleteAssetRentingContract(int id);
        PagedResultDto<AssetRentingContractDto> GetAssetRentingContracts(AssetRentingContractFilter input);
        AssetRentingContractForViewDto GetAssetRentingContractForView(int id);
        Task<AssetRentingFileOutput> GetAssetRentingFileComboboxForEditAsync(NullableIdDto input);
    }
}
