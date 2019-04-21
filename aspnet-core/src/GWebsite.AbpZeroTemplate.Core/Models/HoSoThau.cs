using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class HoSoThau : FullAuditModel
    {
        public string MaHoSo { get; set; }
        public string HangMucThau { get; set; }
        public string HinhThucThau { get; set; }
        public string SoTienBaoLanh { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string NgayBatDauHoSo { get; set; }
        public string NgayKetThucHoSo { get; set; }
    }
}
