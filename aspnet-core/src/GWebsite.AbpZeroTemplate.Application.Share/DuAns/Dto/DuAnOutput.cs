using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto
{
    public class DuAnOutput
    {
        public DuAnDto DuAn { get; set; }
        public List<ComboboxItemDto> DuAns { get; set; }

        public DuAnOutput()
        {
            DuAns = new List<ComboboxItemDto>();
        }
    }
}
