using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HoSoThauController : GWebsiteControllerBase
    {
        private readonly IHoSoThauAppService hosothauAppService;

        public HoSoThauController(IHoSoThauAppService hosothauAppService)
        {
            this.hosothauAppService = hosothauAppService;
        }

        [HttpGet]
        public PagedResultDto<HoSoThauDto> GetHoSoThausByFilter(HoSoThauFilter hosothauFilter)
        {
            return hosothauAppService.GetHoSoThaus(hosothauFilter);
        }

        [HttpGet]
        public async Task<ListResultDto<DuAnDto>> GetDuAnLienQuanHoSos()
        {
            return await hosothauAppService.GetDuAnLienQuanHoSos();
        }

        [HttpGet]
        public HoSoThauInput GetHoSoThauForEdit(int id)
        {
            return hosothauAppService.GetHoSoThauForEdit(id);
        }

        //[HttpGet]
        //public async Task<HoSoThauOutput> GetHoSoThauForEditAsync(int id)
        //{
        //    return await hosothauAppService.GetHoSoThauForEditAsync(new NullableIdDto() { Id = id });
        //}

        [HttpGet]
        public async Task<DuAnOutput> GetDuAnComboboxForEditAsync(int id)
        {
            return await hosothauAppService.GetDuAnComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditHoSoThau([FromBody] HoSoThauInput input)
        {
            hosothauAppService.CreateOrEditHoSoThau(input);
        }

        [HttpDelete("{id}")]
        public void DeleteHoSoThau(int id)
        {
            hosothauAppService.DeleteHoSoThau(id);
        }

        [HttpGet]
        public HoSoThauForViewDto GetHoSoThauForView(int id)
        {
            return hosothauAppService.GetHoSoThauForView(id);
        }
    }
}
