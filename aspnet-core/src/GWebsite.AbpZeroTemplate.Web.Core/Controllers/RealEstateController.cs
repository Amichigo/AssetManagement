using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RealEstateController : GWebsiteControllerBase
    {
        private readonly IRealEstateAppService RealEstateAppService;

        public RealEstateController(IRealEstateAppService RealEstateAppService)
        {
            this.RealEstateAppService = RealEstateAppService;
        }

        [HttpGet]
        public PagedResultDto<RealEstateDto> GetRealEstatesByFilter(RealEstateFilter RealEstateFilter)
        {
            return RealEstateAppService.GetRealEstates(RealEstateFilter);
        }

        [HttpGet]
        public RealEstateInput GetRealEstateForEdit(int id)
        {
            return RealEstateAppService.GetRealEstateForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRealEstate([FromBody] RealEstateInput input)
        {
            RealEstateAppService.CreateOrEditRealEstate(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRealEstate(int id)
        {
            RealEstateAppService.DeleteRealEstate(id);
        }

        [HttpGet]
        public RealEstateForViewDto GetRealEstateForView(int id)
        {
            return RealEstateAppService.GetRealEstateForView(id);
        }
    }
}
