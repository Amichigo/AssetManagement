using System;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto
{
    /// <summary>
    /// <model cref="FormOfRentingAsset"></model>
    /// </summary>
    public class FormOfRentingAssetInput : Entity<int>
    {
        public string FormOfRenting { get; set; }
    }
}
