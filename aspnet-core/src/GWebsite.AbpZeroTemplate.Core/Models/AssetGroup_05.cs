using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetGroup_05 :Entity
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
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
    }
}
