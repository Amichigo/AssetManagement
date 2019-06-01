using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto
{
    public class FormOfRentingAssetOutput
    {
        public FormOfRentingAssetDto FormOfRentingAsset { get; set; }
        public List<ComboboxItemDto> FormOfRentingAssets { get; set; }

        public FormOfRentingAssetOutput()
        {
            FormOfRentingAssets = new List<ComboboxItemDto>();
        }
    }
}
