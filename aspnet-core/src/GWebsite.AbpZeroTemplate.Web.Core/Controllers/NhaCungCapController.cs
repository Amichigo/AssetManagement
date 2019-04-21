using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NhaCungCapController : GWebsiteControllerBase
    {
        private readonly INhaCungCapAppService nhacungcapAppService;

        public NhaCungCapController(INhaCungCapAppService nhacungcapAppService)
        {
            this.nhacungcapAppService = nhacungcapAppService;
        }

        [HttpGet]
        public PagedResultDto<NhaCungCapDto> GetNhaCungCapsByFilter(NhaCungCapFilter nhacungcapFilter)
        {
            return nhacungcapAppService.GetNhaCungCaps(nhacungcapFilter);
        }

        [HttpGet]
        public NhaCungCapInput GetNhaCungCapForEdit(int id)
        {
            return nhacungcapAppService.GetNhaCungCapForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditNhaCungCap([FromBody] NhaCungCapInput input)
        {
            nhacungcapAppService.CreateOrEditNhaCungCap(input);
        }

        [HttpDelete("{id}")]
        public void DeleteNhaCungCap(int id)
        {
            nhacungcapAppService.DeleteNhaCungCap(id);
        }

        [HttpGet]
        public NhaCungCapForViewDto GetNhaCungCapForView(int id)
        {
            return nhacungcapAppService.GetNhaCungCapForView(id);
        }
    }
}
