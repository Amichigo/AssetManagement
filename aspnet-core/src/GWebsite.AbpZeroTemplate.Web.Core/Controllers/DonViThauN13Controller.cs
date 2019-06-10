using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DonViThauN13Controller : GWebsiteControllerBase
    {
        private readonly IDonViThauN13AppService donViThauAppService;

        public DonViThauN13Controller(IDonViThauN13AppService donViThauAppService)
        {
            this.donViThauAppService = donViThauAppService;
        }

        [HttpGet]
        public PagedResultDto<DonViThauN13Dto> GetDonViThausByFilter(DonViThauN13Filter donViThauFilter)
        {
            return donViThauAppService.GetDonViThaus(donViThauFilter);
        }

        [HttpGet]
        public DonViThauN13Input GetDonViThauForEdit(int id)
        {
            return donViThauAppService.GetDonViThauForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDonViThau([FromBody] DonViThauN13Input input)
        {
            donViThauAppService.CreateOrEditDonViThau(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDonViThau(int id)
        {
            donViThauAppService.DeleteDonViThau(id);
        }
        [HttpGet]
        public DonViThauN13ForViewDto GetDonViThauByIdGoiThauForView(int id)
        {
            return donViThauAppService.GetDonViThauByIdGoiThauForView(id);
        }
        [HttpGet]
        public DonViThauN13ForViewDto GetDonViThauForView(int id)
        {
            return donViThauAppService.GetDonViThauForView(id);
        }
    }

}
