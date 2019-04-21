using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Handovers;
using GWebsite.AbpZeroTemplate.Application.Share.Handovers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HandoverController : GWebsiteControllerBase
    {
        private readonly IHandoverAppService HandoverAppService;

        public HandoverController(IHandoverAppService HandoverAppService)
        {
            this.HandoverAppService = HandoverAppService;
        }

        [HttpGet]
        public PagedResultDto<HandoverDto> GetHandoversByFilter(HandoverFilter HandoverFilter)
        {
            return HandoverAppService.GetHandovers(HandoverFilter);
        }

        [HttpGet]
        public HandoverInput GetHandoverForEdit(int id)
        {
            return HandoverAppService.GetHandoverForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditHandover([FromBody] HandoverInput input)
        {
            HandoverAppService.CreateOrEditHandover(input);
        }

        [HttpDelete("{id}")]
        public void DeleteHandover(int id)
        {
            HandoverAppService.DeleteHandover(id);
        }

        [HttpGet]
        public HandoverForViewDto GetHandoverForView(int id)
        {
            return HandoverAppService.GetHandoverForView(id);
        }
    }
}
