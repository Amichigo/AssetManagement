using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class NhaCungCap : FullAuditModel
    {
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }
}
