using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Goods.Dto
{
     public class GoodFilter: PagedAndSortedInputDto
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Gia { get; set; }
    }
}
