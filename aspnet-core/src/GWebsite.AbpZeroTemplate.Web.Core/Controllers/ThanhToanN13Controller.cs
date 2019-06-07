using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ThanhToanN13Controller : GWebsiteControllerBase
    {
        private readonly IThanhToanN13AppService taiSanAppService;

        public ThanhToanN13Controller(IThanhToanN13AppService taiSanAppService)
        {
            this.taiSanAppService = taiSanAppService;
        }

        [HttpGet]
        public PagedResultDto<ThanhToanN13Dto> GetThanhToanN13sByFilter(ThanhToanN13Filter taiSanFilter)
        {
            return taiSanAppService.GetThanhToanN13s(taiSanFilter);
        }

        [HttpGet]
        public ThanhToanN13Input GetThanhToanN13ForEdit(int id)
        {
            return taiSanAppService.GetThanhToanN13ForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditThanhToanN13([FromBody] ThanhToanN13Input input)
        {
            taiSanAppService.CreateOrEditThanhToanN13(input);
        }

        [HttpDelete("{id}")]
        public void DeleteThanhToanN13(int id)
        {
            taiSanAppService.DeleteThanhToanN13(id);
        }

        [HttpGet]
        public ThanhToanN13ForViewDto GetThanhToanN13ForView(int id)
        {
            return taiSanAppService.GetThanhToanN13ForView(id);
        }
    }

}
