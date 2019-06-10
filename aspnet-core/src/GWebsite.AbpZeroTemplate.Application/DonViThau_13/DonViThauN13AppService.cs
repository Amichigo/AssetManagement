using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau;

namespace GWebsite.AbpZeroTemplate.Web.Core.DonViThau_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau)]
    public class DonViThauN13AppService : GWebsiteAppServiceBase, IDonViThauN13AppService
    {
        private readonly IRepository<DonViThau_N13> taiSanRepository;

        public DonViThauN13AppService(IRepository<DonViThau_N13> taiSanRepository)
        {
            this.taiSanRepository = taiSanRepository;
        }

        #region Public Method

        public void CreateOrEditDonViThau(DonViThauN13Input taiSanInput)
        {
            if (taiSanInput.Id == 0)
            {
                Create(taiSanInput);
            }
            else
            {
                Update(taiSanInput);
            }
        }

        public void DeleteDonViThau(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity != null)
            {
                taiSanEntity.IsDelete = true;
                taiSanRepository.Update(taiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DonViThauN13Input GetDonViThauForEdit(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DonViThauN13Input>(taiSanEntity);
        }

        public DonViThauN13ForViewDto GetDonViThauForView(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DonViThauN13ForViewDto>(taiSanEntity);
        }

        public DonViThauN13ForViewDto GetDonViThauByIdGoiThauForView(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).Where(y=>y.IsTrungThau==true).FirstOrDefault(x => x.IdHoSoThau == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DonViThauN13ForViewDto>(taiSanEntity);
        }

        public PagedResultDto<DonViThauN13Dto> GetDonViThaus(DonViThauN13Filter input)
        {
            var query = taiSanRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaDonViThau != null)
            {
                query = query.Where(x => x.MaDonViThau.ToLower().Equals(input.MaDonViThau));
            }

            // filter by value
            if (input.IdHoSoThau != null)
            {
                query = query.Where(x => x.IdHoSoThau==input.IdHoSoThau);
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
            return new PagedResultDto<DonViThauN13Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DonViThauN13Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Create)]
        private void Create(DonViThauN13Input taiSanInput)
        {
            int nextID = taiSanRepository.GetAll().Count() + 1;
            taiSanInput.MaDonViThau = taiSanInput.MaDonViThau + "00" + nextID;
            var taiSanEntity = ObjectMapper.Map<DonViThau_N13>(taiSanInput);
            SetAuditInsert(taiSanEntity);
            taiSanRepository.Insert(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Edit)]
        private void Update(DonViThauN13Input taiSanInput)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == taiSanInput.Id);
            if (taiSanEntity == null)
            {
            }
            ObjectMapper.Map(taiSanInput, taiSanEntity);
            SetAuditEdit(taiSanEntity);
            taiSanRepository.Update(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
