using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto
{
    /// <summary>
    /// <model cref="FormOfRentingAsset"></model>
    /// </summary>
    public class FormOfRentingAssetDto : Entity<int>
    {
        public string FormOfRenting { get; set; }
    }
}
