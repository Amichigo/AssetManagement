using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Contract : FullAuditModel
    {
        public string ContractCode { get; set; }
        public string BidCode { get; set; }
        public string ContractName { get; set; }
        public string SupplierName { get; set; }
        public string ContractDayCreate { get; set; }
        public string ApprovalStatus { get; set; }
        public string UnitAcceptedCode { get; set; }
        public string GoodsName { get; set; }
    }
}
