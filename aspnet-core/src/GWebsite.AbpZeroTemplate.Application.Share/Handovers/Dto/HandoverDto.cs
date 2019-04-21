using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
namespace GWebsite.AbpZeroTemplate.Application.Share.Handovers.Dto
{
    /// <summary>
    /// <model cref="Handover"></model>
    /// </summary>
    public class HandoverDto : Entity<int>
    {
        public string MaPhieuNhan { get; set; }
        public string NgayBanGiao { get; set; }
        public string BoPhanBanGiao { get; set; }
        public string NhanVienBanGiao { get; set; }
        public string BoPhanNhanBanGiao { get; set; }
        public string LyDoNhanBDS { get; set; }
        public string MaBatDongSan { get; set; }
        public string LoaiBatDongSan { get; set; }
        public string TinhTrangBatDongSan { get; set; }
    }
}
