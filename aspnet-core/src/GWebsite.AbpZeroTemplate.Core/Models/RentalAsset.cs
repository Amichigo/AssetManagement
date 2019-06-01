using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class RentalAsset : FullAuditModel
    {
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string Description { get; set; }
        public string TypeOfAsset { get; set; }
        public float AssetValue { get; set; }
        public int Quantity { get; set; }
        public DateTime RentalDate { get; set; }
        public bool IsActive { get; set; }
        public string LinkofImage { get; set; }
    }
}
