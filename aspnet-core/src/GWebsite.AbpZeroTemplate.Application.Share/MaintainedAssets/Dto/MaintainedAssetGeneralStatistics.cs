using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets.Dto
{
    public class MaintainedAssetGeneralStatistics : Entity<int>
    {
        public double PreviousTotalAmount { get; set; }
        public double PreviousTotalQuantity { get; set; }
        public double CurrentTotalAmount { get; set; }
        public double CurrentTotalQuantity { get; set; }
        public double AmountRatio { get; set; }
        public double QuantityRatio { get; set; }
    }
}
