using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto
{
    public class AssetGroupOutput
    {
        public AssetGroupDto AssetGroup { get; set; }
        public List<ComboboxItemDto> AssetGroups { get; set; }

        public AssetGroupOutput()
        {
            AssetGroups = new List<ComboboxItemDto>();
        }
    }
}
