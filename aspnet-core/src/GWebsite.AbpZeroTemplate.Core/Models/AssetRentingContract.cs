using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetRentingContract : FullAuditModel
    {
        public string ContractName { get; set; }
        public string ContractCode { get; set; }
        public string FileCode { get; set; }
        public string RentalPartner { get; set; }
        public DateTime SignDate { get; set; }
        public string LinkofImage { get; set; }
    }
}
