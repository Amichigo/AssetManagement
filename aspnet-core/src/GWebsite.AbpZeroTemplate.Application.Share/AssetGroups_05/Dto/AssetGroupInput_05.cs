﻿using System;
using System.Collections.Generic;
using System.Linq;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto
{
    /// <summary>
    /// <model cref="AssetGroup_05"></model>
    /// </summary>
    public class AssetGroupInput_05 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string AssetTypeId { get; set; }
        public int Level { get; set; }
        public string FatherAssetGroup { get; set; }
        public int MonthsDepreciation { get; set; }
        public float DepreciationRates { get; set; }
        public string AssetAccount { get; set; }
        public string DepreciationAccount { get; set; }
        public string CostAccount { get; set; }
        public string IncomeAccount { get; set; }
        public string LiquidationCostAccount { get; set; }
    }
}
    