using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto
{
    /// <summary>
    /// <model cref="DuAn"></model>
    /// </summary>
    public class DuAnInput : Entity<int>
    {
        public string MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public string NgayTaoDuAn { get; set; }
    }
}
