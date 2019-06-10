using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Goods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Goods
{
    public interface IGoodAppService
    {
        PagedResultDto<GoodDto> GetGoods(GoodFilter input);
    }
}
