using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets.Dto
{
    public class OperatingAssetForViewDto
    {
        public string AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public double Amount { get; set; }
        public double Quantity { get; set; }
        public double DepreciatedAmount { get; set; }
        public double DepreciatedQuantity { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
