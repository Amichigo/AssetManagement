using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets
{
    public interface IOperatingAssetAppService
    {
        void CreateOrEditOperatingAsset(OperatingAssetInput operatingAssetInput);
        OperatingAssetInput GetOperatingAssetForEdit(int id);
        void DeleteOperatingAsset(int id);
        PagedResultDto<OperatingAssetDto> GetOperatingAssets(OperatingAssetFilter input);
        OperatingAssetForViewDto GetOperatingAssetForView(int id);
        OperatingAssetGeneralStatistics GetGeneralStatistics(OperatingAssetFilter operatingAssetInput);
    }
}
