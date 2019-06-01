using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Buildings
{
    public interface IBuildingAppService
    {
        void CreateOrEditBuilding(BuildingInput_9 buildingInput);
        BuildingInput_9 GetBuildingForEdit(int id);
        void DeleteBuilding(int id);
        PagedResultDto<BuildingDto_9> GetBuildings(BuildingFilter_9 input);
        BuildingForViewDto_9 GetBuildingForView(int id);
    }
}
