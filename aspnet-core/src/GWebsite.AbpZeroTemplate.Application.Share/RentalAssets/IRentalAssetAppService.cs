using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using System.Threading.Tasks;
using System;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets
{
    public interface IRentalAssetAppService
    {

        void CreateOrEditRentalAsset(RentalAssetInput rentalAssetInput);
        RentalAssetInput GetRentalAssetForEdit(int id);
        void DeleteRentalAsset(int id);
        PagedResultDto<RentalAssetDto> GetRentalAssets(RentalAssetFilter input);
        RentalAssetForViewDto GetRentalAssetForView(int id);
        Task<TypeOfRentalAssetOutput> GetTypeOfRentalAssetComboboxForEditAsync(NullableIdDto input);
    }
}
