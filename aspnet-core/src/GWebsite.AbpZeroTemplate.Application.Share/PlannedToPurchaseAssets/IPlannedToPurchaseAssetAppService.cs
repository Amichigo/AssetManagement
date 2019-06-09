using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets
{
    public interface IPlannedToPurchaseAssetAppService
    {
        void CreateOrEditPlannedToPurchaseAsset(PlannedToPurchaseAssetInput plannedToPurchaseAssetInput);
        PlannedToPurchaseAssetInput GetPlannedToPurchaseAssetForEdit(int id);
        void DeletePlannedToPurchaseAsset(int id);
        PagedResultDto<PlannedToPurchaseAssetDto> GetPlannedToPurchaseAssets(PlannedToPurchaseAssetFilter input);
        PlannedToPurchaseAssetForViewDto GetPlannedToPurchaseAssetForView(int id);
        PlannedToPurchaseAssetGeneralStatistics GetGeneralStatistics(PlannedToPurchaseAssetFilter plannedToPurchaseAssetInput);
    }
}
