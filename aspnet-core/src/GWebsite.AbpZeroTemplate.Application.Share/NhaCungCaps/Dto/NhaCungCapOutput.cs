using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto
{
    public class NhaCungCapOutput
    {
        public NhaCungCapDto NhaCungCap { get; set; }
        public List<ComboboxItemDto> NhaCungCaps { get; set; }

        public NhaCungCapOutput()
        {
            NhaCungCaps = new List<ComboboxItemDto>();
        }
    }
}
