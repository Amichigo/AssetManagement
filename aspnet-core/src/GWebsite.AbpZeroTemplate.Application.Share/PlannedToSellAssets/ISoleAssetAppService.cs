using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets
{
    public interface IPlannedToSellAssetAppService
    {
        void CreateOrEditPlannedToSellAsset(PlannedToSellAssetInput plannedToSellAssetInput);
        PlannedToSellAssetInput GetPlannedToSellAssetForEdit(int id);
        void DeletePlannedToSellAsset(int id);
        PagedResultDto<PlannedToSellAssetDto> GetPlannedToSellAssets(PlannedToSellAssetFilter input);
        PlannedToSellAssetForViewDto GetPlannedToSellAssetForView(int id);
        PlannedToSellAssetGeneralStatistics GetGeneralStatistics(PlannedToSellAssetFilter plannedToSellAssetInput);
    }
}
