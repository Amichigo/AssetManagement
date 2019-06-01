using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto
{
    /// <summary>
    /// <model cref="RentalAsset"></model>
    /// </summary>
    public class RentalAssetFilter : PagedAndSortedInputDto
    {
        public string AssetName { get; set; }
    }
}
