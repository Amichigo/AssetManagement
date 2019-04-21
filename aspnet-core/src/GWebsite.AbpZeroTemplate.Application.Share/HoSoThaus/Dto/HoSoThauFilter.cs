using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto
{
    /// <summary>
    /// <model cref="HoSoThau"></model>
    /// </summary>
    public class HoSoThauFilter : PagedAndSortedInputDto
    {
        public string MaHoSo { get; set; }
    }
}
