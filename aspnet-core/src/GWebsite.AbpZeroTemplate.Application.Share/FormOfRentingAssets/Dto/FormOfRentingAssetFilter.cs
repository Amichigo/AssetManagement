using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto
{
    /// <summary>
    /// <model cref="FormOfRentingAsset"></model>
    /// </summary>
    public class FormOfRentingAssetFilter : PagedAndSortedInputDto
    {
        public string FormOfRenting { get; set; }
    }
}
