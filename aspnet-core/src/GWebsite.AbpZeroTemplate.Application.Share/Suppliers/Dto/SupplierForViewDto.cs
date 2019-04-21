using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto
{
    /// <summary>
    /// <model cref="Supplier"></model>
    /// </summary>
    public class SupplierForViewDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
