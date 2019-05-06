using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Application.CategoryTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General)]
    public class CategoryTypeAppService : GWebsiteAppServiceBase, ICategoryTypeAppService
    {
        private readonly IRepository<CategoryType> categoryRepository;

        public CategoryTypeAppService(IRepository<CategoryType> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #region Public Method

        public void CreateCategoryType(CategoryTypeInput input)
        {
            Create(input);
        }

        public void EditCategoryType(CategoryTypeInput input)
        {
            Update(input);
        }

        public void DeleteCategoryType(int id)
        {
            var categoryEntity = categoryRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity != null)
            {
                categoryEntity.IsDelete = true;
                categoryRepository.Update(categoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CategoryTypeInput GetCategoryTypeForEdit(int id)
        {
            var categoryEntity = categoryRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryTypeInput>(categoryEntity);
        }

        public CategoryTypeForViewDto GetCategoryTypeForView(int id)
        {
            var categoryEntity = categoryRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryTypeForViewDto>(categoryEntity);
        }

        public PagedResultDto<CategoryTypeDto> GetCategoryTypes(CategoryTypeFilter input)
        {
            var query = categoryRepository.GetAll();

            // filter by Name
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name));
            }

            // filter by PrefixWord
            if (input.PrefixWord != null)
            {
                query = query.Where(x => x.PrefixWord.ToLower().Contains(input.PrefixWord));
            }

            // filter by Status
            if (input.Status == "Active")
            {
                query = query.Where(x => x.IsDelete == false);
            }
            else if (input.Status == "Inactive")
            {
                query = query.Where(x => x.IsDelete == true);
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();
            var resultItems = items.Select(item => ObjectMapper.Map<CategoryTypeDto>(item)).ToList();

            for (int i = 0; i < resultItems.Count(); i++)
            {
                resultItems.ElementAt(i).Status = !items.ElementAt(i).IsDelete;
            }

            return new PagedResultDto<CategoryTypeDto>(
                totalCount,
                resultItems);
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General_Create)]
        private void Create(CategoryTypeInput categoryInput)
        {
            var categoryEntity = ObjectMapper.Map<CategoryType>(categoryInput);
            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.CreatedBy = GetCurrentUser().Name;
            categoryEntity.IsDelete = false;
            categoryRepository.Insert(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General_Edit)]
        private void Update(CategoryTypeInput categoryInput)
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
