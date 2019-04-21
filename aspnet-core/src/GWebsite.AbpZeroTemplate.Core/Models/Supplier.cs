namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Supplier : FullAuditModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}