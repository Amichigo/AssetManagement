using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BuildingController : GWebsiteControllerBase
    {
        private readonly IBuildingAppService BuildingAppService;

        public BuildingController(IBuildingAppService BuildingAppService)
        {
            this.BuildingAppService = BuildingAppService;
        }

        [HttpGet]
        public PagedResultDto<BuildingDto> GetBuildingsByFilter(BuildingFilter BuildingFilter)
        {
            return BuildingAppService.GetBuildings(BuildingFilter);
        }

        [HttpGet]
        public BuildingInput GetBuildingForEdit(int id)
        {
            return BuildingAppService.GetBuildingForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBuilding([FromBody] BuildingInput input)
        {
            BuildingAppService.CreateOrEditBuilding(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBuilding(int id)
        {
            BuildingAppService.DeleteBuilding(id);
        }

        [HttpGet]
        public BuildingForViewDto GetBuildingForView(int id)
        {
            return BuildingAppService.GetBuildingForView(id);
        }
    }
}
