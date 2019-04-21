using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Revokes.Dto
{
    /// <summary>
    /// <model cref="Revoke"></model>
    /// </summary>
    public class RevokeFilter : PagedAndSortedInputDto
    {
        public string MaPhieuThu { get; set; }
        public string MaBatDongSan { get; set; }
        public string LoaiBatDongSan { get; set; }
        public string TinhTrangBatDongSan { get; set; }

    }
}
