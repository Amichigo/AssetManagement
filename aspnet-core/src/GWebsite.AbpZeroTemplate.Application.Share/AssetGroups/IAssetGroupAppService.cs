using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto;
using System.Threading.Tasks;
using System;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups
{
    public interface IAssetGroupAppService
    {

        void CreateOrEditAssetGroup(AssetGroupInput assetGroupInput);
        AssetGroupInput GetAssetGroupForEdit(int id);
        void DeleteAssetGroup(int id);
        PagedResultDto<AssetGroupDto> GetAssetGroups(AssetGroupFilter input);
        AssetGroupForViewDto GetAssetGroupForView(int id);
        Task<TypeOfAssetOutput> GetTypeOfAssetComboboxForEditAsync(NullableIdDto input);
        AssetGroupOutput GetAssetGroupsById(string assetTypeId);
    }
}
