using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto
{
    /// <summary>
    /// <model cref="RealEstate"></model>
    /// </summary>
    public class RealEstateFilter : PagedAndSortedInputDto
    {
        public string MaBatDongSan { get; set; }
        public string LoaiBatDongSan { get; set; }
        public string DiaChi { get; set; }
        public string LoaiSoHuu { get; set; }
    }
}
