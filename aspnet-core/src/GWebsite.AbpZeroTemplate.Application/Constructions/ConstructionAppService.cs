using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Constructions
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ConstructionAppService : GWebsiteAppServiceBase, IConstructionAppService
    {
        private readonly IRepository<Construction> ConstructionRepository;

        public ConstructionAppService(IRepository<Construction> ConstructionRepository)
        {
            this.ConstructionRepository = ConstructionRepository;
        }

        #region Public Method

        public void CreateOrEditConstruction(ConstructionInput ConstructionInput)
        {
            if (ConstructionInput.Id == 0)
            {
                Create(ConstructionInput);
            }
            else
            {
                Update(ConstructionInput);
            }
        }

        public void DeleteConstruction(int id)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ConstructionEntity != null)
            {
                ConstructionEntity.IsDelete = true;
                ConstructionRepository.Update(ConstructionEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ConstructionInput GetConstructionForEdit(int id)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ConstructionEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionInput>(ConstructionEntity);
        }

        public ConstructionForViewDto GetConstructionForView(int id)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ConstructionEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionForViewDto>(ConstructionEntity);
        }

        public PagedResultDto<ConstructionDto> GetConstructions(ConstructionFilter input)
        {
            var query = ConstructionRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            //if (input.Name != null)
            //{
            //    query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            //}

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ConstructionDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ConstructionDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ConstructionInput ConstructionInput)
        {
            var ConstructionEntity = ObjectMapper.Map<Construction>(ConstructionInput);
            SetAuditInsert(ConstructionEntity);
            ConstructionRepository.Insert(ConstructionEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ConstructionInput ConstructionInput)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ConstructionInput.Id);
            if (ConstructionEntity == null)
            {
            }
            ObjectMapper.Map(ConstructionInput, ConstructionEntity);
            SetAuditEdit(ConstructionEntity);
            ConstructionRepository.Update(ConstructionEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
