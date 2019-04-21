using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto
{
    public class HopDongThauOutput
    {
        public HopDongThauDto HopDongThau { get; set; }
        public List<ComboboxItemDto> HopDongThaus { get; set; }

        public HopDongThauOutput()
        {
            HopDongThaus = new List<ComboboxItemDto>();
        }
    }
}
