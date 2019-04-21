using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class CustomerDto : Entity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
    }
}
