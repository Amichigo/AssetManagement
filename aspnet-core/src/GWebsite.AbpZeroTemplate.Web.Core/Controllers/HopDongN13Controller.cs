using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HopDongN13Controller : GWebsiteControllerBase
    {
        private readonly IHopDongN13AppService HopDongAppService;

        public HopDongN13Controller(IHopDongN13AppService hopDongFilter)
        {
            this.HopDongAppService = hopDongFilter;
        }

        [HttpGet]
        public PagedResultDto<HopDongN13Dto> GetHopDongsByFilter(HopDongN13Filter hopDongFilter)
        {
            return HopDongAppService.GetHopDongs(hopDongFilter);
        }

        [HttpGet]
        public HopDongN13Input GetHopDongForEdit(int id)
        {
            return HopDongAppService.GetHopDongForEdit(id);
        }

        [HttpPost]
        public int CreateOrEditHopDong([FromBody] HopDongN13Input input, int idGoiThau)
        {
          return  HopDongAppService.CreateOrEditHopDong(input, idGoiThau);
        }

        [HttpDelete("{id}")]
        public void DeleteHopDong(int id)
        {
            HopDongAppService.DeleteHopDong(id);
        }

        [HttpGet]
        public HopDongN13ForViewDto GetHopDongForView(int id)
        {
            return HopDongAppService.GetHopDongForView(id);
        }
    }
}
