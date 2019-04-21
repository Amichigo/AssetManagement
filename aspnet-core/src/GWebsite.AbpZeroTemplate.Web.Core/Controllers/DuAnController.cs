using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DuAnController : GWebsiteControllerBase
    {
        private readonly IDuAnAppService duanAppService;

        public DuAnController(IDuAnAppService duanAppService)
        {
            this.duanAppService = duanAppService;
        }

        [HttpGet]
        public PagedResultDto<DuAnDto> GetDuAnsByFilter(DuAnFilter duanFilter)
        {
            return duanAppService.GetDuAns(duanFilter);
        }

        [HttpGet]
        public DuAnInput GetDuAnForEdit(int id)
        {
            return duanAppService.GetDuAnForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDuAn([FromBody] DuAnInput input)
        {
            duanAppService.CreateOrEditDuAn(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDuAn(int id)
        {
            duanAppService.DeleteDuAn(id);
        }

        [HttpGet]
        public DuAnForViewDto GetDuAnForView(int id)
        {
            return duanAppService.GetDuAnForView(id);
        }
    }
}
