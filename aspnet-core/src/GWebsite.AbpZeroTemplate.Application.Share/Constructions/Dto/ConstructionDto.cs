using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto
{
    /// <summary>
    /// <model cref="Construction_9"></model>
    /// </summary>
    public class ConstructionDto : Entity <int>
    {
        public string MaCongTrinh { get; set; }
        public string TenCongTrinh { get; set; }
        public string MaLoaiCongTrinh { get; set; }
        public string MaKeHoach { get; set; }
        public string DienTichCongTrinh { get; set; }
        public string ChiPhiCongTrinh { get; set; }
        public string NgayDuKienThucHien { get; set; }
        public string ThoiGianDuKienHT { get; set; }
        public string MoTaCongTrinh { get; set; }

        public string ChiPhiDaThucHien { get; set; }
        public string NgayThucThiThucTe { get; set; }
        public string NgayHoanThanh { get; set; }
        public string TienDo { get; set; }

        public string TrangThaiDuyet { get; set; }
        public string DonViLapKeHoach { get; set; }
    }
}
