using System;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto
{
    /// <summary>
    /// <model cref="TypeOfRentalAsset"></model>
    /// </summary>
    public class TypeOfRentalAssetInput : Entity<int>
    {
        public string TypeOfAsset { get; set; }
    }
}
