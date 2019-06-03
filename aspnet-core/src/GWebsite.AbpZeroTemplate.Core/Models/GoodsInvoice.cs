using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class GoodsInvoice : FullAuditModel
    {
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public string ContractName { get; set; }
        public string UnitName { get; set; }
        public string GoodsName { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string PaymentProcess { get; set; }
        public string ShippingProcess { get; set; }
        public string BillStatus { get; set; }
    }
}
