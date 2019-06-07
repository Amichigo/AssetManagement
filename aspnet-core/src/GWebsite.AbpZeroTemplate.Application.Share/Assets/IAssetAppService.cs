using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using System.Threading.Tasks;
using System;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets
{
    public interface IAssetAppService
    {

        void CreateOrEditAsset(AssetInput assetInput);
        AssetInput GetAssetForEdit(int id);
        void DeleteAsset(int id);
        PagedResultDto<AssetDto> GetAssets(AssetFilter input);
        AssetForViewDto GetAssetForView(int id);
        Task<TypeOfAssetOutput> GetTypeOfAssetComboboxForEditAsync(NullableIdDto input);
        Task<AssetGroupOutput> GetAssetGroupComboboxForEditAsync(NullableIdDto input);
    }
}
