using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetRentingFile : FullAuditModel
    {
        public string FileName { get; set; }
        public string FileCode { get; set; }
        public string AssetCode { get; set; }
        public string FormOfRenting { get; set; }
        public DateTime FileCreatedDate { get; set; }
        public string LinkofImage { get; set; }
    }
}
