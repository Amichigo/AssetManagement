using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.CongTrinhDoDangs
{
    [AbpAuthorize(GWebsitePermissions.Pages_QuanLyCongTrinhDoDang_CongTrinhDoDang)]
    public class CongTrinhDoDanggAppService : GWebsiteAppServiceBase, ICongTrinhDoDangAppService
    {
        private readonly IRepository<CongTrinhDoDang> congTrinhDoDangRepository;

        public CongTrinhDoDanggAppService(IRepository<CongTrinhDoDang> congTrinhDoDangRepository)
        {
            this.congTrinhDoDangRepository = congTrinhDoDangRepository;
        }

        #region Public Method

        public void CreateOrEditCongTrinhDoDang(CongTrinhDoDangInput congTrinhDoDangInput)
        {
            if (congTrinhDoDangInput.Id == 0)
            {
                Create(congTrinhDoDangInput);
            }
            else
            {
                Update(congTrinhDoDangInput);
            }
        }

        public void DeleteCongTrinhDoDang(int id)
        {
            var congTrinhDoDangEntity = congTrinhDoDangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (congTrinhDoDangEntity != null)
            {
                congTrinhDoDangEntity.IsDelete = true;
                congTrinhDoDangRepository.Update(congTrinhDoDangEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CongTrinhDoDangInput GetCongTrinhDoDangForEdit(int id)
        {
            var congTrinhDoDangEntity = congTrinhDoDangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (congTrinhDoDangEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CongTrinhDoDangInput>(congTrinhDoDangEntity);
        }

        public CongTrinhDoDangForViewDto GetCongTrinhDoDangForView(int id)
        {
            var congTrinhDoDangEntity = congTrinhDoDangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (congTrinhDoDangEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CongTrinhDoDangForViewDto>(congTrinhDoDangEntity);
        }

        public PagedResultDto<CongTrinhDoDangDto> GetCongTrinhDoDang(CongTrinhDoDangFilter input)
        {
            var query = congTrinhDoDangRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.ConstructionID != null)
            {
                query = query.Where(x => x.ConstructionID.ToLower().Equals(input.ConstructionID));
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
            return new PagedResultDto<CongTrinhDoDangDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CongTrinhDoDangDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyCongTrinhDoDang_CongTrinhDoDang_Create)]
        private void Create(CongTrinhDoDangInput congTrinhDoDangInput)
        {
            var congTrinhDoDangEntity = ObjectMapper.Map<CongTrinhDoDang>(congTrinhDoDangInput);
            SetAuditInsert(congTrinhDoDangEntity);
            congTrinhDoDangRepository.Insert(congTrinhDoDangEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyCongTrinhDoDang_CongTrinhDoDang_Edit)]
        private void Update(CongTrinhDoDangInput congTrinhDoDangInput)
        {
            var congTrinhDoDangEntity = congTrinhDoDangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == congTrinhDoDangInput.Id);
            if (congTrinhDoDangEntity == null)
            {
            }
            ObjectMapper.Map(congTrinhDoDangInput, congTrinhDoDangEntity);
            SetAuditEdit(congTrinhDoDangEntity);
            congTrinhDoDangRepository.Update(congTrinhDoDangEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
