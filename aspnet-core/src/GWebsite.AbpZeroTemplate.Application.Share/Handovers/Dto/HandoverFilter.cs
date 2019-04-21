using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Handovers.Dto
{
    /// <summary>
    /// <model cref="Handover"></model>
    /// </summary>
    public class HandoverFilter : PagedAndSortedInputDto
    {
        public string MaPhieuNhan { get; set; }
        public string MaBatDongSan { get; set; }
        public string LoaiBatDongSan { get; set; }
        public string TinhTrangBatDongSan { get; set; }
    }
}
