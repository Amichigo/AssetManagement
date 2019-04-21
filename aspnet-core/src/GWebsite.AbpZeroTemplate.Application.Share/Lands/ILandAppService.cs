using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lands
{
    public interface ILandAppService
    {
        void CreateOrEditLand(LandInput landInput);
        LandInput GetLandForEdit(int id);
        void DeleteLand(int id);
        PagedResultDto<LandDto> GetLands(LandFilter input);
        LandForViewDto GetLandForView(int id);
    }
}
