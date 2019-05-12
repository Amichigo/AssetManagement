using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.NhomTaiSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_QuanLyBatDongSan_NhomTaiSan)]
    public class CongTrinhDoDangAppService : GWebsiteAppServiceBase, IPropertyGroupAppService
    {
        private readonly IRepository<NhomTaiSan> nhomTaiSanRepository;

        public CongTrinhDoDangAppService(IRepository<NhomTaiSan> nhomTaiSanRepository)
        {
            this.nhomTaiSanRepository = nhomTaiSanRepository;
        }

        #region Public Method

        public void CreateOrEditPropertyGroup(NhomTaiSanInput nhomTaiSanInput)
        {
            if (nhomTaiSanInput.Id == 0)
            {
                Create(nhomTaiSanInput);
            }
            else
            {
                Update(nhomTaiSanInput);
            }
        }

        public void DeletePropertyGroup(int id)
        {
            var nhomTaiSanEntity = nhomTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (nhomTaiSanEntity != null)
            {
                nhomTaiSanEntity.IsDelete = true;
                nhomTaiSanRepository.Update(nhomTaiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public NhomTaiSanInput GetPropertyGroupForEdit(int id)
        {
            var nhomTaiSanEntity = nhomTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (nhomTaiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhomTaiSanInput>(nhomTaiSanEntity);
        }

        public NhomTaiSanForViewDto GetPropertyGroupForView(int id)
        {
            var nhomTaiSanEntity = nhomTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (nhomTaiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhomTaiSanForViewDto>(nhomTaiSanEntity);
        }

        public PagedResultDto<NhomTaiSanDto> GetPropertyGroups(NhomTaiSanFilter input)
        {
            var query = nhomTaiSanRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<NhomTaiSanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<NhomTaiSanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyBatDongSan_NhomTaiSan_Create)]
        private void Create(NhomTaiSanInput nhomTaiSanInput)
        {
            var nhomTaiSanEntity = ObjectMapper.Map<NhomTaiSan>(nhomTaiSanInput);
            SetAuditInsert(nhomTaiSanEntity);
            nhomTaiSanRepository.Insert(nhomTaiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyBatDongSan_NhomTaiSan_Edit)]
        private void Update(NhomTaiSanInput nhomTaiSanInput)
        {
            var nhomTaiSanEntity = nhomTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == nhomTaiSanInput.Id);
            if (nhomTaiSanEntity == null)
            {
            }
            ObjectMapper.Map(nhomTaiSanInput, nhomTaiSanEntity);
            SetAuditEdit(nhomTaiSanEntity);
            nhomTaiSanRepository.Update(nhomTaiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
