using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto
{
    /// <summary>
    /// <model cref="AssetGroup"></model>
    /// </summary>
    public class AssetGroupForViewDto
    {
        public string AssetGroupName { get; set; }
        public string AssetGroupCode { get; set; }
        public string AssetType { get; set; }
    }
}
