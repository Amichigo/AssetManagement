using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class DuAn : FullAuditModel
    {
        public string MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public string NgayTaoDuAn { get; set; }
    }
}
