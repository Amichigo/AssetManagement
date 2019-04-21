
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Revoke : FullAuditModel
    {
        public string MaPhieuThu { get; set; }
        public string NgayThuHoi { get; set; }
        public string BoPhanThuHoi { get; set; }
        public string NhanVienThuHoi { get; set; }
        public string BoPhanBiThuHoi { get; set; }
        public string LyDoThuBDS { get; set; }
        public string MaBatDongSan { get; set; }
        public string LoaiBatDongSan { get; set; }
        public string TinhTrangBatDongSan { get; set; }
    }
}
