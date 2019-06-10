using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SoldAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.SoldAssets
{
    public interface ISoldAssetAppService
    {
        void CreateOrEditSoldAsset(SoldAssetInput soldAssetInput);
        SoldAssetInput GetSoldAssetForEdit(int id);
        void DeleteSoldAsset(int id);
        PagedResultDto<SoldAssetDto> GetSoldAssets(SoldAssetFilter input);
        SoldAssetForViewDto GetSoldAssetForView(int id);
        SoldAssetGeneralStatistics GetGeneralStatistics(SoldAssetFilter soldAssetInput);
    }
}
