using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto
{
    public class AssetRentingFileOutput
    {
        public AssetRentingFileDto AssetRentingFile { get; set; }
        public List<ComboboxItemDto> AssetRentingFiles { get; set; }

        public AssetRentingFileOutput()
        {
            AssetRentingFiles = new List<ComboboxItemDto>();
        }
    }
}
