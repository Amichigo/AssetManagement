using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13
{
    public class ThanhToan_N13 : FullAuditModel
    {
        public string NgayDuKienThanhToan { set; get; }
        public float SoTienThanhToan { set; get; }
        public float DaThanhToan { set; get; }
        public string NgayThanhToan { set; get; }
        public string NoiDungThanhToan { set; get; }
        public int? IdHopDong { set; get; }
    }
}
