using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13.Dto
{
    public class ThanhToanN13Input : Entity<int>
    {
        public string NgayDuKienThanhToan { set; get; }
        public float SoTienThanhToan { set; get; }
        public float DaThanhToan { set; get; }
        public string NgayThanhToan { set; get; }
        public string NoiDungThanhToan { set; get; }
        public int? IdHopDong { set; get; }
    }
}
