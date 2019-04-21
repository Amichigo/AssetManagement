using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Lands;
using GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Lands
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class LandAppService : GWebsiteAppServiceBase, ILandAppService
    {
        private readonly IRepository<Land> LandRepository;

        public LandAppService(IRepository<Land> LandRepository)
        {
            this.LandRepository = LandRepository;
        }

        #region Public Method

        public void CreateOrEditLand(LandInput LandInput)
        {
            if (LandInput.Id == 0)
            {
                Create(LandInput);
            }
            else
            {
                Update(LandInput);
            }
        }

        public void DeleteLand(int id)
        {
            var LandEntity = LandRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LandEntity != null)
            {
                LandEntity.IsDelete = true;
                LandRepository.Update(LandEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LandInput GetLandForEdit(int id)
        {
            var LandEntity = LandRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LandEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LandInput>(LandEntity);
        }

        public LandForViewDto GetLandForView(int id)
        {
            var LandEntity = LandRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LandEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LandForViewDto>(LandEntity);
        }

        public PagedResultDto<LandDto> GetLands(LandFilter input)
        {
            var query = LandRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<LandDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LandDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(LandInput LandInput)
        {
            var LandEntity = ObjectMapper.Map<Land>(LandInput);
            SetAuditInsert(LandEntity);
            LandRepository.Insert(LandEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(LandInput LandInput)
        {
            var LandEntity = LandRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == LandInput.Id);
            if (LandEntity == null)
            {
            }
            ObjectMapper.Map(LandInput, LandEntity);
            SetAuditEdit(LandEntity);
            LandRepository.Update(LandEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
