using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets
{
    public interface IPlannedToMaintainAssetAppService
    {
        void CreateOrEditPlannedToMaintainAsset(PlannedToMaintainAssetInput plannedToMaintainAssetInput);
        PlannedToMaintainAssetInput GetPlannedToMaintainAssetForEdit(int id);
        void DeletePlannedToMaintainAsset(int id);
        PagedResultDto<PlannedToMaintainAssetDto> GetPlannedToMaintainAssets(PlannedToMaintainAssetFilter input);
        PlannedToMaintainAssetForViewDto GetPlannedToMaintainAssetForView(int id);
        PlannedToMaintainAssetGeneralStatistics GetGeneralStatistics(PlannedToMaintainAssetFilter plannedToMaintainAssetInput);
    }
}
