using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    /// <summary>
    /// <model cref="Contract"></model>
    /// </summary>
    public class ContractInput : Entity<int>
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
