using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    public class AssetOutput
    {
        public AssetDto Asset { get; set; }
        public List<ComboboxItemDto> Assets { get; set; }

        public AssetOutput()
        {
            Assets = new List<ComboboxItemDto>();
        }
    }
}
