using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSans;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSans.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.TaiSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class TaiSanAppService : GWebsiteAppServiceBase, ITaiSanAppService
    {
        private readonly IRepository<TaiSan> taisanRepository;

        public TaiSanAppService(IRepository<TaiSan> taisanRepository)
        {
            this.taisanRepository = taisanRepository;
        }

        #region Public Method

        public void CreateOrEditTaiSan(TaiSanInput taisanInput)
        {
            if (taisanInput.Id == 0)
            {
                Create(taisanInput);
            }
            else
            {
                Update(taisanInput);
            }
        }

        public void DeleteTaiSan(int id)
        {
            var taisanEntity = taisanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taisanEntity != null)
            {
                taisanEntity.IsDelete = true;
                taisanRepository.Update(taisanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TaiSanInput GetTaiSanForEdit(int id)
        {
            var taisanEntity = taisanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taisanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TaiSanInput>(taisanEntity);
        }

        public TaiSanForViewDto GetTaiSanForView(int id)
        {
            var taisanEntity = taisanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taisanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TaiSanForViewDto>(taisanEntity);
        }

        public PagedResultDto<TaiSanDto> GetTaiSans(TaiSanFilter input)
        {
            var query = taisanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
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
            return new PagedResultDto<TaiSanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TaiSanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(TaiSanInput taisanInput)
        {
            var taisanEntity = ObjectMapper.Map<TaiSan>(taisanInput);
            SetAuditInsert(taisanEntity);
            taisanRepository.Insert(taisanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(TaiSanInput taisanInput)
        {
            var taisanEntity = taisanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == taisanInput.Id);
            if (taisanEntity == null)
            {
            }
            ObjectMapper.Map(taisanInput, taisanEntity);
            SetAuditEdit(taisanEntity);
            taisanRepository.Update(taisanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
