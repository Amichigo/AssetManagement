using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs;
using GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PhieuGoiHangController : GWebsiteControllerBase
    {
        private readonly IPhieuGoiHangAppService phieugoihangAppService;

        public PhieuGoiHangController(IPhieuGoiHangAppService phieugoihangAppService)
        {
            this.phieugoihangAppService = phieugoihangAppService;
        }

        [HttpGet]
        public PagedResultDto<PhieuGoiHangDto> GetPhieuGoiHangsByFilter(PhieuGoiHangFilter phieugoihangFilter)
        {
            return phieugoihangAppService.GetPhieuGoiHangs(phieugoihangFilter);
        }

        [HttpGet]
        public PhieuGoiHangInput GetPhieuGoiHangForEdit(int id)
        {
            return phieugoihangAppService.GetPhieuGoiHangForEdit(id);
        }

        [HttpGet]
        public async Task<HopDongThauOutput> GetHopDongThauComboboxForEditAsync(int id)
        {
            return await phieugoihangAppService.GetHopDongThauComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditPhieuGoiHang([FromBody] PhieuGoiHangInput input)
        {
            phieugoihangAppService.CreateOrEditPhieuGoiHang(input);
        }

        [HttpDelete("{id}")]
        public void DeletePhieuGoiHang(int id)
        {
            phieugoihangAppService.DeletePhieuGoiHang(id);
        }

        [HttpGet]
        public PhieuGoiHangForViewDto GetPhieuGoiHangForView(int id)
        {
            return phieugoihangAppService.GetPhieuGoiHangForView(id);
        }
    }
}
