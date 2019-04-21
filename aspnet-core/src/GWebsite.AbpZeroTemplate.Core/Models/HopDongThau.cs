using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class HopDongThau : FullAuditModel
    {
        public string MaHopDong { get; set; }
        public string MaHoSo { get; set; }
        public string TenHopDong { get; set; }
        public string TenNhaCungCap { get; set; }
        public string NgayTaoHopDong { get; set; }
        public string TrangThaiDuyet { get; set; }
    }
}
