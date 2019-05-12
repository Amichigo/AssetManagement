using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CongTrinhDoDangController : GWebsiteControllerBase
    {
        private readonly ICongTrinhDoDangAppService congtrinhdodangAppService;
        public CongTrinhDoDangController(ICongTrinhDoDangAppService congtrinhdodangAppService)
        {
            this.congtrinhdodangAppService = congtrinhdodangAppService;
        }

        [HttpGet]
        public PagedResultDto<CongTrinhDoDangDto> GetCongTrinhDoDangsByFilter(CongTrinhDoDangFilter congtrinhdodangFilter)
        {
                return congtrinhdodangAppService.GetCongTrinhDoDang(congtrinhdodangFilter);
        }

        [HttpGet]
        public CongTrinhDoDangInput GetCongTrinhDoDangForEdit(int id)
        {
            return congtrinhdodangAppService.GetCongTrinhDoDangForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditCongTrinhDoDang([FromBody] CongTrinhDoDangInput input)
        {
            congtrinhdodangAppService.CreateOrEditCongTrinhDoDang(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCongTrinhDoDang(int id)
        {
            congtrinhdodangAppService.DeleteCongTrinhDoDang(id);
        }

        [HttpGet]
        public CongTrinhDoDangForViewDto GetCongTrinhDoDangForView(int id)
        {
            return congtrinhdodangAppService.GetCongTrinhDoDangForView(id);
        }
    }
}
