using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Base;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Depreciation_05 :Entity<int>
    {
        public int TotalMonthDepreciation { get; set; }//Số tháng khấu hao
        public float DepreciationValue { get; set; }//giá trị khấu hao
        public float DepreciationRate { get; set; }//Tỉ lệ khấu hao
        public int RemainingDepMonths { get; set; }//Số tháng khấu hao còn lại
        public string DepreciationStatus { get; set; }//Tình trạng khấu hao
        public float RemainingDepValue { get; set; }//Giá trị khấu hao còn lại
        public int DepreciationDetailId { get; set; }
    }
}
