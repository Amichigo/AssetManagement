using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryTypeController : GWebsiteControllerBase
    {
        private readonly ICategoryTypeAppService categoryAppService;

        public CategoryTypeController(ICategoryTypeAppService categoryAppService)
        {
            this.categoryAppService = categoryAppService;
        }

        [HttpGet]
        public PagedResultDto<CategoryTypeDto> GetCategoryTypesByFilter(CategoryTypeFilter categoryFilter)
        {
            return categoryAppService.GetCategoryTypes(categoryFilter);
        }

        [HttpGet]
        public CategoryTypeInput GetCategoryTypeForEdit(int id)
        {
            return categoryAppService.GetCategoryTypeForEdit(id);
        }

        [HttpPost]
        public void CreateCategoryType([FromBody] CategoryTypeInput input)
        {
            categoryAppService.CreateCategoryType(input);
        }

        [HttpPut]
        public void EditCategoryType([FromBody] CategoryTypeInput input)
        {
            categoryAppService.EditCategoryType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCategoryType(int id)
        {
            categoryAppService.DeleteCategoryType(id);
        }

        [HttpGet]
        public CategoryTypeForViewDto GetCategoryTypeForView(int id)
        {
            return categoryAppService.GetCategoryTypeForView(id);
        }
    }
}
