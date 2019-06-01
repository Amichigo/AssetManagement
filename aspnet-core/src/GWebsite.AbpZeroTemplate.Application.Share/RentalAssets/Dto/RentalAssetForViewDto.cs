using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto
{
    /// <summary>
    /// <model cref="RentalAsset"></model>
    /// </summary>
    public class RentalAssetForViewDto
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
