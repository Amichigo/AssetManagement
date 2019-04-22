using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSans.Dto
{
    /// <summary>
    /// <model cref="TaiSan"></model>
    /// </summary>
    public class TaiSanFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }

    }
}
