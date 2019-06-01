using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto
{
    /// <summary>
    /// <model cref="AssetRentingContract"></model>
    /// </summary>
    public class AssetRentingContractDto : Entity<int>
    {
        public string ContractName { get; set; }
        public string ContractCode { get; set; }
        public string FileCode { get; set; }
        public string RentalPartner { get; set; }
        public DateTime SignDate { get; set; }
        public string LinkofImage { get; set; }
    }
}
