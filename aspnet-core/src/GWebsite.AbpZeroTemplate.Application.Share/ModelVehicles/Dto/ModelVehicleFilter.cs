﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto
{
    public class ModelVehicleFilter : PagedAndSortedInputDto
    {
        public string IdModel { get; set; }

    }
}
