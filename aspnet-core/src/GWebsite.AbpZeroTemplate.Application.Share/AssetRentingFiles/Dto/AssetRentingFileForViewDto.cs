using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto
{
    /// <summary>
    /// <model cref="AssetRentingFile"></model>
    /// </summary>
    public class AssetRentingFileForViewDto
    {
        public string FileName { get; set; }
        public string FileCode { get; set; }
        public string AssetCode { get; set; }
        public string FormOfRenting { get; set; }
        public DateTime FileCreatedDate { get; set; }
        public string LinkofImage { get; set; }
    }
}
