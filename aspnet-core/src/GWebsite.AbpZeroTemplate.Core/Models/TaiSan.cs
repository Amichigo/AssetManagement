using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class TaiSan : FullAuditModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Info { get; set; }

    }
}
