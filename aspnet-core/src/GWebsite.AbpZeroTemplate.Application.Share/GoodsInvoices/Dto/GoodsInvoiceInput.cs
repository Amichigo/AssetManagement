using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto
{
    /// <summary>
    /// <model cref="GoodsInvoice"></model>
    /// </summary>
    public class GoodsInvoiceInput : Entity<int>
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
