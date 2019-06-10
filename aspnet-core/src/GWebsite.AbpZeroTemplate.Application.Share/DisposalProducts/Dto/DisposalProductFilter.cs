using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts.Dto
{
    public class DisposalProductFilter: PagedAndSortedInputDto
    {
        public string MaTS{ get; set; }
    }
}
