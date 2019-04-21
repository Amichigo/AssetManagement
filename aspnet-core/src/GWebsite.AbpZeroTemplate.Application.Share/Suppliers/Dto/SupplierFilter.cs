using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto
{
    /// <summary>
    /// <model cref="Supplier"></model>
    /// </summary>
    public class SupplierFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
