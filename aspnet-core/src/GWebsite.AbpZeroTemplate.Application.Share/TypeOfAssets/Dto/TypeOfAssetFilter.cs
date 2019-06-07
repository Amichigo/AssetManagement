using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto
{
    /// <summary>
    /// <model cref="TypeOfAsset"></model>
    /// </summary>
    public class TypeOfAssetFilter : PagedAndSortedInputDto
    {
        public string AssetType { get; set; }
    }
}
