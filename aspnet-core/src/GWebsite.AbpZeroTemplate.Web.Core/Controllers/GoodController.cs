using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Goods;
using GWebsite.AbpZeroTemplate.Application.Share.Goods.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GoodController : GWebsiteControllerBase
    {
        private readonly IGoodAppService GoodService;

        public GoodController(IGoodAppService GoodService)
        {
            this.GoodService = GoodService;
        }

        [HttpGet]
        public PagedResultDto<GoodDto> GetGoodsByFilter(GoodFilter goodFilter)
        {
            return GoodService.GetGoods(goodFilter);
        }
    }
}
