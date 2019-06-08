using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets
{
    public interface IRentalAssetAppService
    {
        void CreateOrEditRentalAsset(RentalAssetInput RentalAssetInput,int idAsset=0);

        RentalAssetInput GetRentalAssetForEdit(int id);
        void DeleteRentalAsset(int id);
        PagedResultDto<RentalAssetDto> GetRentalAssets(RentalAssetFilter input);
        RentalAssetForViewDto GetRentalAssetForView(int id);
    }
}
