using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes;
using GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.LegalStatusTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_LegalStatusType9)]
    public class LegalStatusTypeAppService : GWebsiteAppServiceBase, ILegalStatusTypeAppService
    {
        private readonly IRepository<LegalStatusType_9> LegalStatusTypeRepository;

        public LegalStatusTypeAppService(IRepository<LegalStatusType_9> LegalStatusTypeRepository)
        {
            this.LegalStatusTypeRepository = LegalStatusTypeRepository;
        }

        #region Public Method

        public void CreateOrEditLegalStatusType(LegalStatusTypeInput_9 LegalStatusTypeInput)
        {
            if (LegalStatusTypeInput.Id == 0)
            {
                Create(LegalStatusTypeInput);
            }
            else
            {
                Update(LegalStatusTypeInput);
            }
        }

        public void DeleteLegalStatusType(int id)
        {
            var LegalStatusTypeEntity = LegalStatusTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LegalStatusTypeEntity != null)
            {
                LegalStatusTypeEntity.IsDelete = true;
                LegalStatusTypeRepository.Update(LegalStatusTypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LegalStatusTypeInput_9 GetLegalStatusTypeForEdit(int id)
        {
            var LegalStatusTypeEntity = LegalStatusTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LegalStatusTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LegalStatusTypeInput_9>(LegalStatusTypeEntity);
        }

        public LegalStatusTypeForViewDto_9 GetLegalStatusTypeForView(int id)
        {
            var LegalStatusTypeEntity = LegalStatusTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LegalStatusTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LegalStatusTypeForViewDto_9>(LegalStatusTypeEntity);
        }

        public PagedResultDto<LegalStatusTypeDto_9> GetLegalStatusTypes(LegalStatusTypeFilter_9 input)
        {
            var query = LegalStatusTypeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaHienTrangPhapLy != null)
            {
                query = query.Where(x => x.MaHienTrangPhapLy.ToLower().Equals(input.MaHienTrangPhapLy));
            }
            if (input.TenHienTrangPhapLy != null)
            {
                query = query.Where(x => x.TenHienTrangPhapLy.ToLower().Equals(input.TenHienTrangPhapLy));
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
            return new PagedResultDto<LegalStatusTypeDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LegalStatusTypeDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LegalStatusType9_Create)]
        private void Create(LegalStatusTypeInput_9 LegalStatusTypeInput)
        {
            var LegalStatusTypeEntity = ObjectMapper.Map<LegalStatusType_9>(LegalStatusTypeInput);
            SetAuditInsert(LegalStatusTypeEntity);
            LegalStatusTypeRepository.Insert(LegalStatusTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LegalStatusType9_Edit)]
        private void Update(LegalStatusTypeInput_9 LegalStatusTypeInput)
        {
            var LegalStatusTypeEntity = LegalStatusTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == LegalStatusTypeInput.Id);
            if (LegalStatusTypeEntity == null)
            {
            }
            ObjectMapper.Map(LegalStatusTypeInput, LegalStatusTypeEntity);
            SetAuditEdit(LegalStatusTypeEntity);
            LegalStatusTypeRepository.Update(LegalStatusTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
