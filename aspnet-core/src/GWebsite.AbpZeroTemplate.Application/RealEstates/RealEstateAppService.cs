using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RealEstates
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RealEstateAppService : GWebsiteAppServiceBase, IRealEstateAppService
    {
        private readonly IRepository<RealEstate> RealEstateRepository;

        public RealEstateAppService(IRepository<RealEstate> RealEstateRepository)
        {
            this.RealEstateRepository = RealEstateRepository;
        }

        #region Public Method

        public void CreateOrEditRealEstate(RealEstateInput RealEstateInput)
        {
            if (RealEstateInput.Id == 0)
            {
                Create(RealEstateInput);
            }
            else
            {
                Update(RealEstateInput);
            }
        }

        public void DeleteRealEstate(int id)
        {
            var RealEstateEntity = RealEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateEntity != null)
            {
                RealEstateEntity.IsDelete = true;
                RealEstateRepository.Update(RealEstateEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RealEstateInput GetRealEstateForEdit(int id)
        {
            var RealEstateEntity = RealEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateInput>(RealEstateEntity);
        }

        public RealEstateForViewDto GetRealEstateForView(int id)
        {
            var RealEstateEntity = RealEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateForViewDto>(RealEstateEntity);
        }

        public PagedResultDto<RealEstateDto> GetRealEstates(RealEstateFilter input)
        {
            var query = RealEstateRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
            }
            if (input.LoaiBatDongSan != null)
            {
                query = query.Where(x => x.LoaiBatDongSan.ToLower().Equals(input.LoaiBatDongSan));
            }
            if (input.LoaiSoHuu != null)
            {
                query = query.Where(x => x.LoaiSoHuu.ToLower().Equals(input.LoaiSoHuu));
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
            return new PagedResultDto<RealEstateDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RealEstateDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RealEstateInput RealEstateInput)
        {
            var RealEstateEntity = ObjectMapper.Map<RealEstate>(RealEstateInput);
            SetAuditInsert(RealEstateEntity);
            RealEstateRepository.Insert(RealEstateEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RealEstateInput RealEstateInput)
        {
            var RealEstateEntity = RealEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == RealEstateInput.Id);
            if (RealEstateEntity == null)
            {
            }
            ObjectMapper.Map(RealEstateInput, RealEstateEntity);
            SetAuditEdit(RealEstateEntity);
            RealEstateRepository.Update(RealEstateEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
