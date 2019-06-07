using System;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto
{
    /// <summary>
    /// <model cref="AssetGroup"></model>
    /// </summary>
    public class AssetGroupInput : Entity<int>
    {
        public string AssetGroupName { get; set; }
        public string AssetGroupCode { get; set; }
        public string AssetType { get; set; }
    }
}
