using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto
{
    /// <summary>
    /// <model cref="TypeOfRentalAsset"></model>
    /// </summary>
    public class TypeOfRentalAssetFilter : PagedAndSortedInputDto
    {
        public string TypeOfAsset { get; set; }
    }
}
