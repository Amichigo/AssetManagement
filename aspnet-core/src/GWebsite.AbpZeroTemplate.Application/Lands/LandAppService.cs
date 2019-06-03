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
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Land9)]
    public class LandAppService : GWebsiteAppServiceBase, ILandAppService
    {
        private readonly IRepository<Land_9> LandRepository;

        public LandAppService(IRepository<Land_9> LandRepository)
        {
            this.LandRepository = LandRepository;
        }

        #region Public Method

        public void CreateOrEditLand(LandInput_9 LandInput)
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

        public LandInput_9 GetLandForEdit(int id)
        {
            var LandEntity = LandRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LandEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LandInput_9>(LandEntity);
        }

        public LandForViewDto_9 GetLandForView(int id)
        {
            var LandEntity = LandRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LandEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LandForViewDto_9>(LandEntity);
        }

        public PagedResultDto<LandDto_9> GetLands(LandFilter_9 input)
        {
            var query = LandRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MucDichSuDung != null)
            {
                query = query.Where(x => x.MucDichSuDung.ToLower().Equals(input.MucDichSuDung));
            }
            if (input.TinhTrangXayDung != null)
            {
                query = query.Where(x => x.TinhTrangXayDung.ToLower().Equals(input.TinhTrangXayDung));
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
            return new PagedResultDto<LandDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LandDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Land9_Create)]
        private void Create(LandInput_9 LandInput)
        {
            var LandEntity = ObjectMapper.Map<Land_9>(LandInput);
            SetAuditInsert(LandEntity);
            LandRepository.Insert(LandEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Land9_Edit)]
        private void Update(LandInput_9 LandInput)
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
