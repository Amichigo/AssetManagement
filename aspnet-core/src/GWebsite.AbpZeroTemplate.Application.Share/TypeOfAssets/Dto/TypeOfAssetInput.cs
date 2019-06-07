using System;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto
{
    /// <summary>
    /// <model cref="TypeOfAsset"></model>
    /// </summary>
    public class TypeOfAssetInput : Entity<int>
    {
        public string AssetType { get; set; }
    }
}
