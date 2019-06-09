using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets.Dto
{
    public class PlannedToSellAssetDto : Entity<int>
    {
        public string AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public DateTime RecordedDate { get; set; }
        public double Amount { get; set; }
        public double Quantity { get; set; }
    }
}
