using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class BatDongSan : FullAuditModel
    {

        public string MaTaiSan { set; get; }
        public string HienTrangBDS { set; get; }

        public int MaLoaiBDS { set; get; }

        public float ChieuDai { set; get; }

        public float ChieuRong { set; get; }

        public float DienTichDatNen { set; get; }

        public float DienTichXayDung { set; get; }

        public float MaTinhTrangSuDungDat { set; get; }
        public float MaTinhTrangXayDung { set; get; }
        public string CongNangSuDung { set; get; }

        public string KetCauNha { set; get; }

        public string RanhGioi { set; get; }

        public int MaHienTrangPhapLy { set; get; }

        public int MaLoaiSoHuu { set; get; }

        public string ChuSoHuu { set; get; }

        public string GhiChu { set; get; }

        public string FileDinhKem { set; get; }





   
    }
}
