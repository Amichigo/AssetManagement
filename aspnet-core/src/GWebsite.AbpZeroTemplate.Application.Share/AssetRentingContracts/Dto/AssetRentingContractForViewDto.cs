using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto
{
    /// <summary>
    /// <model cref="AssetRentingContract"></model>
    /// </summary>
    public class AssetRentingContractForViewDto
    {
        public string ContractName { get; set; }
        public string ContractCode { get; set; }
        public string FileCode { get; set; }
        public string RentalPartner { get; set; }
        public DateTime SignDate { get; set; }
        public string LinkofImage { get; set; }
    }
}
