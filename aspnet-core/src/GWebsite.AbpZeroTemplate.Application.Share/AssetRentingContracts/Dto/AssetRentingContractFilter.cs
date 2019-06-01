using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto
{
    /// <summary>
    /// <model cref="AssetRentingContract"></model>
    /// </summary>
    public class AssetRentingContractFilter : PagedAndSortedInputDto
    {
        public string ContractName { get; set; }
    }
}
