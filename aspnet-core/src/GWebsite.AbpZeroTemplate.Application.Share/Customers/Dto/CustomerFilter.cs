using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class CustomerFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
