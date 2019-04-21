using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto
{
    /// <summary>
    /// <model cref="DuAn"></model>
    /// </summary>
    public class DuAnFilter : PagedAndSortedInputDto
    {
        public string TenDuAn { get; set; }
    }
}
