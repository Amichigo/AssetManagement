using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset"></model>
    /// </summary>
    public class AssetFilter : PagedAndSortedInputDto
    {
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string AssetType { get; set; }
        public string AssetGroupName { get; set; }
    }
}
