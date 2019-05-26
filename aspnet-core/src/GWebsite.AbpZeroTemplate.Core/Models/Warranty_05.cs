using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Warranty_05 : Entity<int>
    {
        public int WarrantyDetailId { get; set; }
    }
}
