using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto
{
    /// <summary>
    /// <model cref="HoSoThau"></model>
    /// </summary>
    public class HoSoThauForViewDto
    {
        public string MaHoSo { get; set; }
        public string HangMucThau { get; set; }
        public string HinhThucThau { get; set; }
        public string SoTienBaoLanh { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string NgayBatDauHoSo { get; set; }
        public string NgayKetThucHoSo { get; set; }
    }
}
