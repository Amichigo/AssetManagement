using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13
{
   public  class HopDong_N13 : FullAuditModel
    {
        public string MaHopDong { set; get; }
        public string SoHopDong { set; get; }
        public string NoiDungHopDong { set; get; }
        public float TongGiaTriHopDong { set; get; }
        public string MaHinhThucBaoLanhBH { set; get; }
        public string SoChungTuBaoLanhBH { set; get; }
        public string NganHangBaoLanhBH { set; get; }
        public float SoTienBaoLanhBH { set; get; }
        public string NgayHetHanChungTuBH { set; get; }
        public string FileDinhKemBH { set; get; }
        public string MaHinhThucBaoLanhHD { set; get; }
        public string SoChungTuBaoLanhHD { set; get; }
        public string NganHangBaoLanhHD { set; get; }
        public float SoTienBaoLanhHD { set; get; }
        public string NgayHetHanChungTuHD { set; get; }
        public string FileDinhKemHD { set; get; }
        public string SoToTrinh { set; get; }
        public string NoiDungToTrinh { set; get; }
        public string NgayKyTT { set; get; }
        public string ChiPhiDuyetTT { set; get; }
        public string FileDinhKemTT { set; get; }
    }
}
