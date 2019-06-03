using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset
{
    public interface IAssetAppService
    {
        void CreateOrEditAsset(AssetInput assetInput);

        AssetInput GetAssetForEdit(int id);
        void DeleteAsset(int id);
        PagedResultDto<AssetDto> GetAssets(AssetFilter input);
        AssetForViewDto GetAssetForView(int id);
    }
}
