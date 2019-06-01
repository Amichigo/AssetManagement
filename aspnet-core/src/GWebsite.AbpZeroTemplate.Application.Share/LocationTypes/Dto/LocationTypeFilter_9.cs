using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.LocationTypes.Dto
{
    /// <summary>
    /// <model cref="LocationType_9"></model>
    /// </summary>
    public class LocationTypeFilter_9 : PagedAndSortedInputDto
    {
        public string MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }
    }
}
