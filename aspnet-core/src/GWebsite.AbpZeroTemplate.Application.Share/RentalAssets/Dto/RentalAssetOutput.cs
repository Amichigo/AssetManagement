using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto
{
    public class RentalAssetOutput
    {
        public RentalAssetDto RentalAsset { get; set; }
        public List<ComboboxItemDto> RentalAssets { get; set; }

        public RentalAssetOutput()
        {
            RentalAssets = new List<ComboboxItemDto>();
        }
    }
}
