using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Good: FullAuditModel
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Gia { get; set; }
    }
}
