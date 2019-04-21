using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstates
{
    public interface IRealEstateAppService
    {
        void CreateOrEditRealEstate(RealEstateInput realEstateInput);
        RealEstateInput GetRealEstateForEdit(int id);
        void DeleteRealEstate(int id);
        PagedResultDto<RealEstateDto> GetRealEstates(RealEstateFilter input);
        RealEstateForViewDto GetRealEstateForView(int id);
    }
}
