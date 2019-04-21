using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs.Dto
{
    /// <summary>
    /// <model cref="PhieuGoiHang"></model>
    /// </summary>
    public class PhieuGoiHangFilter : PagedAndSortedInputDto
    {
        public string TenKeHoach { get; set; }
    }
}
