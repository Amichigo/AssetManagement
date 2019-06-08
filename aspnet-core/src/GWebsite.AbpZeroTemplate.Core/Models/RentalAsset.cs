using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class RentalAsset : FullAuditModel
    {
        public string RentalAssetCode { set; get; }
        public string AssetCode { set; get; }
        public float DepreciationValue { get; set; }
        public float DepreciationRate { get; set; }
        public float RentalValue { get; set; }
        public string Note { set; get; }
    }
}
