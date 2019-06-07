using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13
{
    public class BaoLanhHopDong_N13:FullAuditModel
    {
        public string MaHinhThucBaoLanh { set; get; }
        public string SoChungTuBaoLanh { set; get; }
        public string NganHangBaoLanh { set; get; }
        public float SoTienBaoLanh { set; get; }
        public string NgayHetHanChungTu { set; get; }
        public string MaHopDong { set; get; }
        public string FileDinhKem { set; get; }

    }
}
