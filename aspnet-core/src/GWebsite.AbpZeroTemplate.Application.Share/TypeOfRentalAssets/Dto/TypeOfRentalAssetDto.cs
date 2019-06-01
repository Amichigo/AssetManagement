using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto
{
    /// <summary>
    /// <model cref="TypeOfRentalAsset"></model>
    /// </summary>
    public class TypeOfRentalAssetDto : Entity<int>
    {
        public string TypeOfAsset { get; set; }
    }
}
