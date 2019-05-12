using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class CongTrinhDoDang : FullAuditModel
    {
        public string ConstructionID { set; get; }
        public string Address { set; get; }
        public string Nation { set; get; }
        public string Province { set; get; }
        public string District { set; get; }
        public string Ward { set; get; }
        public float Width { get; set; }
        public float Length { get; set; }
        public string File { set; get; }
    }
}
