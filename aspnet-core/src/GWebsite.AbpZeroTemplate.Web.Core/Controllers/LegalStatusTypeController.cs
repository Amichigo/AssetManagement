using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes;
using GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LegalStatusTypeController : GWebsiteControllerBase
    {
        private readonly ILegalStatusTypeAppService LegalStatusTypeAppService;

        public LegalStatusTypeController(ILegalStatusTypeAppService LegalStatusTypeAppService)
        {
            this.LegalStatusTypeAppService = LegalStatusTypeAppService;
        }

        [HttpGet]
        public PagedResultDto<LegalStatusTypeDto_9> GetLegalStatusTypesByFilter(LegalStatusTypeFilter_9 LegalStatusTypeFilter)
        {
            return LegalStatusTypeAppService.GetLegalStatusTypes(LegalStatusTypeFilter);
        }

        [HttpGet]
        public LegalStatusTypeInput_9 GetLegalStatusTypeForEdit(int id)
        {
            return LegalStatusTypeAppService.GetLegalStatusTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditLegalStatusType([FromBody] LegalStatusTypeInput_9 input)
        {
            this.LegalStatusTypeAppService.CreateOrEditLegalStatusType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteLegalStatusType(int id)
        {
            this.LegalStatusTypeAppService.DeleteLegalStatusType(id);
        }

        [HttpGet]
        public LegalStatusTypeForViewDto_9 GetLegalStatusTypeForView(int id)
        {
            return LegalStatusTypeAppService.GetLegalStatusTypeForView(id);
        }
    }
}
