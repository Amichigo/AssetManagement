using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class PlannedToPurchaseAsset : FullAuditModel
    {
        public string AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public DateTime RecordedDate { get; set; }
        public double Amount { get; set; }
        public double Quantity { get; set; }
    }
}
