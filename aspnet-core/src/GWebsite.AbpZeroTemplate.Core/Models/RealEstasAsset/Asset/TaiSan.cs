using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class TaiSan : FullAuditModel
    {
        public string MaTaiSan { set; get; }
        public string Name { set; get; }
        public string DiaChi { set; get; }
        public string ThongTinMoTa { set; get; }
        public string MaLoaiTaiSan { set; get; }

        public string MaNhomTaiSan { set; get; }

        public long NguyenGiaTaiSan { set; get; }

        public string NguoiSuDung { set; get; }

        public string DonViSuDung { set; get; }

    }
}
