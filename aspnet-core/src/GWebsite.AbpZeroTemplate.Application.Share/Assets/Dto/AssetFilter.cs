using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset"></model>
    /// </summary>
    public class AssetFilter : PagedAndSortedInputDto
    {
        public string MaTaiSan { get; set; }
        public string LoaiTaiSan { get; set; }
    }
}
