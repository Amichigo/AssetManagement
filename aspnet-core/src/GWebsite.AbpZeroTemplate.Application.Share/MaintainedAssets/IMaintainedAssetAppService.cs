using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets
{
    public interface IMaintainedAssetAppService
    {
        void CreateOrEditMaintainedAsset(MaintainedAssetInput maintainedAssetInput);
        MaintainedAssetInput GetMaintainedAssetForEdit(int id);
        void DeleteMaintainedAsset(int id);
        PagedResultDto<MaintainedAssetDto> GetMaintainedAssets(MaintainedAssetFilter input);
        MaintainedAssetForViewDto GetMaintainedAssetForView(int id);
        MaintainedAssetGeneralStatistics GetGeneralStatistics(MaintainedAssetFilter maintainedAssetInput);
    }
}
