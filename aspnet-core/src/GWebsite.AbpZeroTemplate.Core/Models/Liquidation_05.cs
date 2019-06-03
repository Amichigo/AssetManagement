    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Base;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Liquidation_05 : Entity<int>
    {
        public int LiquidationDetailId { get; set; }
    }
}
