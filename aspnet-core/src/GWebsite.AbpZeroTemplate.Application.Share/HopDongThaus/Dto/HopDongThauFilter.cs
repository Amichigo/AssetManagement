using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto
{
    /// <summary>
    /// <model cref="HopDongThau"></model>
    /// </summary>
    public class HopDongThauFilter : PagedAndSortedInputDto
    {
        public string TenHopDong { get; set; }
    }
}
