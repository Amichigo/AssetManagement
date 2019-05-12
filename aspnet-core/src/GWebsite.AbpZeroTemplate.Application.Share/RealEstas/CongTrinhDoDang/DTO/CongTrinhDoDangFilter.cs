using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang.DTO
{
    public class CongTrinhDoDangFilter : PagedAndSortedInputDto
    {
        public string ConstructionID { set; get; }
    }
}
