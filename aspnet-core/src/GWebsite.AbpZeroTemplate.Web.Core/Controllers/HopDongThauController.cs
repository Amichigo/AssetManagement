using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HopDongThauController : GWebsiteControllerBase
    {
        private readonly IHopDongThauAppService hopdongthauAppService;

        public HopDongThauController(IHopDongThauAppService hopdongthauAppService)
        {
            this.hopdongthauAppService = hopdongthauAppService;
        }

        [HttpGet]
        public PagedResultDto<HopDongThauDto> GetHopDongThausByFilter(HopDongThauFilter hopdongthauFilter)
        {
            return hopdongthauAppService.GetHopDongThaus(hopdongthauFilter);
        }

        [HttpGet]
        public HopDongThauInput GetHopDongThauForEdit(int id)
        {
            return hopdongthauAppService.GetHopDongThauForEdit(id);
        }

        [HttpGet]
        public async Task<HoSoThauOutput> GetHoSoThauComboboxForEditAsync(int id)
        {
            return await hopdongthauAppService.GetHoSoThauComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpGet]
        public async Task<NhaCungCapOutput> GetNhaCungCapComboboxForEditAsync(int id)
        {
            return await hopdongthauAppService.GetNhaCungCapComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditHopDongThau([FromBody] HopDongThauInput input)
        {
            hopdongthauAppService.CreateOrEditHopDongThau(input);
        }

        [HttpDelete("{id}")]
        public void DeleteHopDongThau(int id)
        {
            hopdongthauAppService.DeleteHopDongThau(id);
        }

        [HttpGet]
        public HopDongThauForViewDto GetHopDongThauForView(int id)
        {
            return hopdongthauAppService.GetHopDongThauForView(id);
        }
    }
}
