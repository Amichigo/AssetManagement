using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto
{
    public class TypeOfRentalAssetOutput
    {
        public TypeOfRentalAssetDto TypeOfRentalAsset { get; set; }
        public List<ComboboxItemDto> TypeOfRentalAssets { get; set; }

        public TypeOfRentalAssetOutput()
        {
            TypeOfRentalAssets = new List<ComboboxItemDto>();
        }
    }
}
