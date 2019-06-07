using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto
{
    public class TypeOfAssetOutput
    {
        public TypeOfAssetDto TypeOfAsset { get; set; }
        public List<ComboboxItemDto> TypeOfAssets { get; set; }

        public TypeOfAssetOutput()
        {
            TypeOfAssets = new List<ComboboxItemDto>();
        }
    }
}
