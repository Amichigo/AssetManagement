using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto
{
    /// <summary>
    /// <model cref="RentalAsset"></model>
    /// </summary>
    public class RentalAssetDto : Entity<int>
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
