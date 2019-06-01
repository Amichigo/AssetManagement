using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LocationTypes;
using GWebsite.AbpZeroTemplate.Application.Share.LocationTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LocationTypeController : GWebsiteControllerBase
    {
        private readonly ILocationTypeAppService LocationTypeAppService;

        public LocationTypeController(ILocationTypeAppService LocationTypeAppService)
        {
            this.LocationTypeAppService = LocationTypeAppService;
        }

        [HttpGet]
        public PagedResultDto<LocationTypeDto_9> GetLocationTypesByFilter(LocationTypeFilter_9 LocationTypeFilter)
        {
            return LocationTypeAppService.GetLocationTypes(LocationTypeFilter);
        }

        [HttpGet]
        public LocationTypeInput_9 GetLocationTypeForEdit(int id)
        {
            return LocationTypeAppService.GetLocationTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditLocationType([FromBody] LocationTypeInput_9 input)
        {
            this.LocationTypeAppService.CreateOrEditLocationType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteLocationType(int id)
        {
            this.LocationTypeAppService.DeleteLocationType(id);
        }

        [HttpGet]
        public LocationTypeForViewDto_9 GetLocationTypeForView(int id)
        {
            return LocationTypeAppService.GetLocationTypeForView(id);
        }
    }
}
