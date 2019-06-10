using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Goods.Dto
{
    public class GoodDto: Entity<int>
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Gia { get; set; }
    }
}
