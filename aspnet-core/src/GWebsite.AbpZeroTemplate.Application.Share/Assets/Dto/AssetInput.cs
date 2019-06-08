using System;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset"></model>
    /// </summary>
    public class AssetInput : Entity<int>
    {
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string AssetType { get; set; }
        public string AssetGroupName { get; set; }
        public string RentalAssetCode { get; set; }
        public string Description { get; set; }
        public string AssetStatus { get; set; }
        public float AssetValue { get; set; }
        public string Supplier { get; set; }
        public DateTime AddDate { get; set; }
        public string Note { get; set; }
        public string LinkofImage { get; set; }
    }
}
