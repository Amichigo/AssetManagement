using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto
{
    /// <summary>
    /// <model cref="TypeOfAsset"></model>
    /// </summary>
    public class TypeOfAssetDto : Entity<int>
    {
        public string AssetType { get; set; }
    }
}
