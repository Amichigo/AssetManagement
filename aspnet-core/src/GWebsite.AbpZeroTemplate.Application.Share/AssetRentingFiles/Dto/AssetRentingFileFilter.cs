using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto
{
    /// <summary>
    /// <model cref="AssetRentingFile"></model>
    /// </summary>
    public class AssetRentingFileFilter : PagedAndSortedInputDto
    {
        public string FileName { get; set; }
    }
}
