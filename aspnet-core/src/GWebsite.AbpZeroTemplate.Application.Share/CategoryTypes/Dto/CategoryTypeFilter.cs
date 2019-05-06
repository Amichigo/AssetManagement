using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto
{
    /// <summary>
    /// <model cref="CategoryType"></model>
    /// </summary>
    public class CategoryTypeFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
        public string PrefixWord { get; set; }
        public string Status { get; set; }
    }
}
