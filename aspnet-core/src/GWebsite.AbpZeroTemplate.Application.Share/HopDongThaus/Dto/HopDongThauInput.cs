using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto
{
    /// <summary>
    /// <model cref="HopDongThau"></model>
    /// </summary>
    public class HopDongThauInput : Entity<int>
    {
        public string MaHopDong { get; set; }
        public string MaHoSo { get; set; }
        public string TenHopDong { get; set; }
        public string TenNhaCungCap { get; set; }
        public string NgayTaoHopDong { get; set; }
        public string TrangThaiDuyet { get; set; }
    }
}
