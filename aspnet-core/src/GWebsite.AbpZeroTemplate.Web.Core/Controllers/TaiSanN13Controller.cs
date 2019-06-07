using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class TaiSanN13Controller : GWebsiteControllerBase
    {
        private readonly ITaiSanN13AppService taiSanAppService;

        public TaiSanN13Controller(ITaiSanN13AppService taiSanAppService)
        {
            this.taiSanAppService = taiSanAppService;
        }

        [HttpGet]
        public PagedResultDto<TaiSanDto> GetTaiSansByFilter(TaiSanN13Filter taiSanFilter)
        {
            return taiSanAppService.GetTaiSans(taiSanFilter);
        }

        [HttpGet]
        public TaiSanN13Input GetTaiSanForEdit(int id)
        {
            return taiSanAppService.GetTaiSanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTaiSan([FromBody] TaiSanN13Input input)
        {
            taiSanAppService.CreateOrEditTaiSan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTaiSan(int id)
        {
            taiSanAppService.DeleteTaiSan(id);
        }

        [HttpGet]
        public TaiSanN13ForViewDto GetTaiSanForView(int id)
        {
            return taiSanAppService.GetTaiSanForView(id);
        }
    }

}
