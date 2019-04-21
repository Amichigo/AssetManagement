using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Buildings
{
    public interface IBuildingAppService
    {
        void CreateOrEditBuilding(BuildingInput buildingInput);
        BuildingInput GetBuildingForEdit(int id);
        void DeleteBuilding(int id);
        PagedResultDto<BuildingDto> GetBuildings(BuildingFilter input);
        BuildingForViewDto GetBuildingForView(int id);
    }
}
