using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Base;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Depreciation_05 :Entity<int>
    {
       
        public int DepreciationDetailId { get; set; }
    }
}
