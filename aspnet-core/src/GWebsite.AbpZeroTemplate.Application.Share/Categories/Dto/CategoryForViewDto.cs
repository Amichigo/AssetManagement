using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    public class CategoryForViewDto
    {
        public string CategoryType { get; set; }
        public string CategoryId { get; set; }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
    }
}
