using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.LoaiTaiSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class LoaiTaiSanAppService : GWebsiteAppServiceBase, IPropertyTypeAppService
    {
        private readonly IRepository<LoaiTaiSan> loaiTaiSanRepository;

        public LoaiTaiSanAppService(IRepository<LoaiTaiSan> loaiTaiSanRepository)
        {
            this.loaiTaiSanRepository = loaiTaiSanRepository;
        }

        #region Public Method

        public void CreateOrEditPropertyType(LoaiTaiSanInput loaiTaiSanInput)
        {
            if (loaiTaiSanInput.Id == 0)
            {
                Create(loaiTaiSanInput);
            }
            else
            {
                Update(loaiTaiSanInput);
            }
        }

        public void DeletePropertyType(int id)
        {
            var loaiTaiSanEntity = loaiTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiTaiSanEntity != null)
            {
                loaiTaiSanEntity.IsDelete = true;
                loaiTaiSanRepository.Update(loaiTaiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LoaiTaiSanInput GetPropertyTypeForEdit(int id)
        {
            var loaiTaiSanEntity = loaiTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiTaiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiTaiSanInput>(loaiTaiSanEntity);
        }

        public LoaiTaiSanForViewDto GetPropertyTypeForView(int id)
        {
            var loaiTaiSanEntity = loaiTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiTaiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiTaiSanForViewDto>(loaiTaiSanEntity);
        }

        public PagedResultDto<LoaiTaiSanDto> GetPropertyTypes(LoaiTaiSanFilter input)
        {
            var query = loaiTaiSanRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<LoaiTaiSanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LoaiTaiSanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(LoaiTaiSanInput loaiTaiSanInput)
        {
            var loaiTaiSanEntity = ObjectMapper.Map<LoaiTaiSan>(loaiTaiSanInput);
            SetAuditInsert(loaiTaiSanEntity);
            loaiTaiSanRepository.Insert(loaiTaiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(LoaiTaiSanInput loaiTaiSanInput)
        {
            var loaiTaiSanEntity = loaiTaiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == loaiTaiSanInput.Id);
            if (loaiTaiSanEntity == null)
            {
            }
            ObjectMapper.Map(loaiTaiSanInput, loaiTaiSanEntity);
            SetAuditEdit(loaiTaiSanEntity);
            loaiTaiSanRepository.Update(loaiTaiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
