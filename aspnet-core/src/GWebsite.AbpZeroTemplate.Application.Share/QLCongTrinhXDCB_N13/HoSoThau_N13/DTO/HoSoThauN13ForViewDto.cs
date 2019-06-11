using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO
{
    public class HoSoThauN13ForViewDto
    {
        public int Id { set; get; }
        public string MaHoSoThau { set; get; }
        public int? IdCongTrinh { set; get; }
        public string TenHoSoThau { set; get; }
        public string HangMucThau { set; get; }
        public string NgayNhapHoSoThau { set; get; }
        public string NgayHetHanNopHoSoThau { set; get; }
        public string NgayThiCong { set; get; }
        public string NgayMoThau { set; get; }

        public string MaHinhThucThau { set; get; }

        public float BaoLanhDuThauBD { set; get; }
        public float BaoLanhDuThauKT { set; get; }

        public string NgayHetHanBaoLanh { set; get; }



        public string FileDinhKem { set; get; }
    }
}
