﻿using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories
{
    public interface ICategoryAppService
    {
        void CreateCategory(CategoryInput input);
        void EditCategory(CategoryInput input);
        CategoryInput GetCategoryForEdit(int id);
        void DeleteCategory(int id);
        PagedResultDto<CategoryDto> GetCategories(CategoryFilter input);
        CategoryForViewDto GetCategoryForView(int id);

    }
}