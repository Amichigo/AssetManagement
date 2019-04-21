using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs.Dto
{
    /// <summary>
    /// <model cref="PhieuGoiHang"></model>
    /// </summary>
    public class PhieuGoiHangInput : Entity<int>
    {
        public string MaKeHoach { get; set; }
        public string TenKeHoach { get; set; }
        public string TenHopDong { get; set; }
        public string TenDonVi { get; set; }
        public string TenHangHoa { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public string QuaTrinhThanhToan { get; set; }
        public string TienDoGiaoHang { get; set; }
        public string TinhTrangHoaDon { get; set; }
    }
}
