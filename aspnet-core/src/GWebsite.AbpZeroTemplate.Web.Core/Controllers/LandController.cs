using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lands;
using GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LandController : GWebsiteControllerBase
    {
        private readonly ILandAppService LandAppService;

        public LandController(ILandAppService LandAppService)
        {
            this.LandAppService = LandAppService;
        }

        [HttpGet]
        public PagedResultDto<LandDto_9> GetLandsByFilter(LandFilter_9 LandFilter)
        {
            return LandAppService.GetLands(LandFilter);
        }

        [HttpGet]
        public LandInput_9 GetLandForEdit(int id)
        {
            return LandAppService.GetLandForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditLand([FromBody] LandInput_9 input)
        {
            LandAppService.CreateOrEditLand(input);
        }

        [HttpDelete("{id}")]
        public void DeleteLand(int id)
        {
            LandAppService.DeleteLand(id);
        }

        [HttpGet]
        public LandForViewDto_9 GetLandForView(int id)
        {
            return LandAppService.GetLandForView(id);
        }
    }
}
