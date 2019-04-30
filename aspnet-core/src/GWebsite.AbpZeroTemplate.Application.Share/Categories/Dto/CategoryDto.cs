﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    /// <summary>
    /// <model cref="Category"></model>
    /// </summary>
    public class CategoryDto : Entity<int>
    {
        public string CategoryType { get; set; }
        public string CategoryId { get; set; }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
    }
}