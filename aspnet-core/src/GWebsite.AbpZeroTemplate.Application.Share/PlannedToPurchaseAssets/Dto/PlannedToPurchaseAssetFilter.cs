using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets.Dto
{
    public class PlannedToPurchaseAssetFilter : PagedAndSortedInputDto
    {
        public DateTime? CurrentStartingDate { get; set; }
        public DateTime? CurrentEndingDate { get; set; }
        public DateTime? PreviousStartingDate { get; set; }
        public DateTime? PreviousEndingDate { get; set; }
    }
}
