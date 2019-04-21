using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BatDongSanController : GWebsiteControllerBase
    {
        private readonly IBatDongSanAppService batdongsanAppService;

        public BatDongSanController(IBatDongSanAppService batdongsanAppService)
        {
            this.batdongsanAppService = batdongsanAppService;
        }

        [HttpGet]
        public PagedResultDto<BatDongSanDto> GetBatDongSansByFilter(BatDongSanFilter batdongsanFilter)
        {
            return batdongsanAppService.GetBatDongSans(batdongsanFilter);
        }

        [HttpGet]
        public BatDongSanInput GetBatDongSanForEdit(int id)
        {
            return batdongsanAppService.GetBatDongSanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBatDongSan([FromBody] BatDongSanInput input)
        {
            batdongsanAppService.CreateOrEditBatDongSan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBatDongSan(int id)
        {
            batdongsanAppService.DeleteBatDongSan(id);
        }

        [HttpGet]
        public BatDongSanForViewDto GetBatDongSanForView(int id)
        {
            return batdongsanAppService.GetBatDongSanForView(id);
        }
    }
}

