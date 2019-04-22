using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSans;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSans.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TaiSanController : GWebsiteControllerBase
    {
        private readonly ITaiSanAppService taisanAppService;

        public TaiSanController(ITaiSanAppService taisanAppService)
        {
            this.taisanAppService = taisanAppService;
        }

        [HttpGet]
        public PagedResultDto<TaiSanDto> GetTaiSansByFilter(TaiSanFilter taisanFilter)
        {
            return taisanAppService.GetTaiSans(taisanFilter);
        }

        [HttpGet]
        public TaiSanInput GetTaiSanForEdit(int id)
        {
            return taisanAppService.GetTaiSanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTaiSan([FromBody] TaiSanInput input)
        {
            taisanAppService.CreateOrEditTaiSan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTaiSan(int id)
        {
            taisanAppService.DeleteTaiSan(id);
        }

        [HttpGet]
        public TaiSanForViewDto GetTaiSanForView(int id)
        {
            return taisanAppService.GetTaiSanForView(id);
        }
    }
}
