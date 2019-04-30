using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Categories;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Categories
{
    [AbpAuthorize(GWebsitePermissions.Pages_Categories_General)]
    public class CategoryAppService : GWebsiteAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #region Public Method

        public void CreateCategory(CategoryInput input)
        {
            Create(input);
        }

        public void EditCategory(CategoryInput input)
        {
            Update(input);
        }

        public void DeleteCategory(int id)
        {
            var categoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (categoryEntity != null)
            {
                categoryEntity.IsDelete = true;
                categoryRepository.Update(categoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CategoryInput GetCategoryForEdit(int id)
        {
            var categoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryInput>(categoryEntity);
        }

        public CategoryForViewDto GetCategoryForView(int id)
        {
            var categoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryForViewDto>(categoryEntity);
        }

        public PagedResultDto<CategoryDto> GetCategories(CategoryFilter input)
        {
            var query = categoryRepository.GetAll().Where(x => !x.IsDelete);

            // filter by type
            if (input.CategoryType != null)
            {
                query = query.Where(x => x.CategoryType.ToLower().Equals(input.CategoryType));
            }

            // filter by id
            if (input.CategoryId != null)
            {
                query = query.Where(x => x.CategoryId.ToLower().Contains(input.CategoryId));
            }

            // filter by Name
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name));
            }

            // filter by Symbol
            if (input.Symbol != null)
            {
                query = query.Where(x => x.Symbol.ToLower().Contains(input.Symbol));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<CategoryDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CategoryDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Categories_General_Create)]
        private void Create(CategoryInput input)
        {
            input.CategoryId = input.CategoryId + DateTime.Now.ToString("yyyyMMddHHmmss");

            var categoryEntity = ObjectMapper.Map<Category>(input);
            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.CreatedBy = GetCurrentUser().Name;
            categoryEntity.IsDelete = false;
            categoryRepository.Insert(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Categories_General_Edit)]
        private void Update(CategoryInput categoryInput)
        {
            var categoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == categoryInput.Id);
            if (categoryEntity == null)
            {
            }
            ObjectMapper.Map(categoryInput, categoryEntity);
            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.CreatedBy = GetCurrentUser().Name;
            categoryEntity.IsDelete = false;
            categoryRepository.Update(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
