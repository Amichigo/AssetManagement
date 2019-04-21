using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes.Dto;
using Microsoft.AspNetCore.Mvc;


namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RevokeController : GWebsiteControllerBase
    {
        private readonly IRevokeAppService RevokeAppService;

        public RevokeController(IRevokeAppService RevokeAppService)
        {
            this.RevokeAppService = RevokeAppService;
        }

        [HttpGet]
        public PagedResultDto<RevokeDto> GetRevokesByFilter(RevokeFilter RevokeFilter)
        {
            return RevokeAppService.GetRevokes(RevokeFilter);
        }

        [HttpGet]
        public RevokeInput GetRevokeForEdit(int id)
        {
            return RevokeAppService.GetRevokeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRevoke([FromBody] RevokeInput input)
        {
            RevokeAppService.CreateOrEditRevoke(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRevoke(int id)
        {
            RevokeAppService.DeleteRevoke(id);
        }

        [HttpGet]
        public RevokeForViewDto GetRevokeForView(int id)
        {
            return RevokeAppService.GetRevokeForView(id);
        }
    }
}
