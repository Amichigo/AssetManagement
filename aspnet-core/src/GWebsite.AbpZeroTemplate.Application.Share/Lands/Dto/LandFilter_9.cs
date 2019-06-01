using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto
{
    /// <summary>
    /// <model cref="Land_9"></model>
    /// </summary>
    public class LandFilter_9 : PagedAndSortedInputDto
    {
        public string TinhTrangXayDung { get; set; }
        public string MucDichSuDung { get; set; }
    }
}
