using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto
{
    public class RentalAssetFilter : PagedAndSortedInputDto
    {
        public string RentalAssetCode { set; get; }
        public string AssetCode { set; get; }
    }
}
