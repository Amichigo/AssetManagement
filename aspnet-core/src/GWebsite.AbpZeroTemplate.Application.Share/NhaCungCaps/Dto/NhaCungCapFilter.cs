using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto
{
    /// <summary>
    /// <model cref="NhaCungCap"></model>
    /// </summary>
    public class NhaCungCapFilter : PagedAndSortedInputDto
    {
        public string TenNhaCungCap { get; set; }
    }
}
