using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.LocationTypes.Dto
{
    /// <summary>
    /// <model cref="LocationType_9"></model>
    /// </summary>
    public class LocationTypeDto_9 : Entity<int>
    {
        public string MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }
    }
}
