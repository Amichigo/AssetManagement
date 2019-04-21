using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto
{
    public class HoSoThauOutput
    {
        public HoSoThauDto HoSoThau { get; set; }
        public List<ComboboxItemDto> HoSoThaus { get; set; }

        public HoSoThauOutput()
        {
            HoSoThaus = new List<ComboboxItemDto>();
        }
    }
}
