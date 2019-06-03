using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Base;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
   public class Repair_05 : Entity<int>
    {
        public int AssetDetailId { get; set; }

        public RepairDetail_05 RepairDetail_05 { get; set; }
    }
}
