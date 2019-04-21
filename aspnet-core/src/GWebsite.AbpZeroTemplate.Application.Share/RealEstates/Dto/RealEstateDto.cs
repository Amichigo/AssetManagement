using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto
{
    /// <summary>
    /// <model cref="RealEstate"></model>
    /// </summary>
    public class RealEstateDto : Entity<int>
    {
        public string MaBatDongSan { get; set; }
        public string LoaiBatDongSan { get; set; }
        public int NguyenGia { get; set; }
        public string TenDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public int ChieuDai { get; set; }
        public int ChieuRong { get; set; }
        public int DienTichDat { get; set; }
        public string TinhTrangSuDung { get; set; }
        public string LoaiSoHuu { get; set; }
        public string GhiChu { get; set; }
    }
}
