using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.HoSoThau13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau)]
    public class HoSoThauN13AppService : GWebsiteAppServiceBase, IHoSoThauN13AppService
    {
        private readonly IRepository<HoSoThau_N13> hoSoThauRepository;
        private readonly IRepository<CongTrinh_N13> congTrinhRepository;
        private readonly IRepository<DonViThau_N13> donvithauRepository;
   
        public HoSoThauN13AppService(IRepository<HoSoThau_N13> hoSoThauRepository, IRepository<CongTrinh_N13> congTrinhRepository, IRepository<DonViThau_N13> donvithauRepository)
        {
            this.hoSoThauRepository = hoSoThauRepository;
            this.congTrinhRepository = congTrinhRepository;
            this.donvithauRepository = donvithauRepository;
        }

        #region Public Method

        public int CreateOrEditHoSoThau(HoSoThauN13Input hoSoThauInput)
        {
            if (hoSoThauInput.Id == 0)
            {
                return Create(hoSoThauInput);
            }
            else
            {
                Update(hoSoThauInput);
            }
            return 0;
        }

        public void DeleteHoSoThau(int id)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hoSoThauEntity != null)
            {
                hoSoThauEntity.IsDelete = true;
                hoSoThauRepository.Update(hoSoThauEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HoSoThauN13Input GetHoSoThauForEdit(int id)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hoSoThauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HoSoThauN13Input>(hoSoThauEntity);
        }

        public HoSoThauN13ForViewDto GetHoSoThauForView(int id)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hoSoThauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HoSoThauN13ForViewDto>(hoSoThauEntity);
        }
        //Lay ds ho so thau da co dv trung thau
        public PagedResultDto<HoSoThauN13Dto> GetDSHoSoThauChoHopDong(HoSoThauN13Filter input)
        {
            var query = hoSoThauRepository.GetAll().Where(x => !x.IsDelete);
            var dvt = donvithauRepository.GetAll().Where(x => !x.IsDelete).Where(y=>y.IsTrungThau==true);
            var congTrinh = congTrinhRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.MaDuAnXayDungCoBan != null);

            if (dvt == null || congTrinh==null )
            {
                return null;
            }
            // filter by value
            if (input.IdCongTrinh != null)
            {
                query = query.Where(x => x.IdCongTrinh == input.IdCongTrinh);
            }
            // filter by value
            if (input.MaHoSoThau != null)
            {
                query = query.Where(x => x.MaHoSoThau.ToLower().Equals(input.MaHoSoThau));
            }


            // filter by value
            if (input.NgayNhapHoSoThau != null)
            {
                query = query.Where(x => x.NgayNhapHoSoThau.ToLower().Equals(input.NgayNhapHoSoThau));
            }
            // filter by value
            if (input.NgayHetHanNopHoSoThau != null)
            {
                query = query.Where(x => x.NgayHetHanNopHoSoThau.ToLower().Equals(input.NgayHetHanNopHoSoThau));
            }
            // filter by value
            if (input.HangMucThau != null)
            {
                query = query.Where(x => x.HangMucThau.ToLower().Equals(input.HangMucThau));
            }
            // filter by value
            if (input.MaHinhThucThau != null)
            {
                query = query.Where(x => x.MaHinhThucThau.ToLower().Equals(input.MaHinhThucThau));
            }
            var listItem = from gt in query
                           join ct in congTrinh
                           on gt.IdCongTrinh equals ct.Id
                           join dvtt in dvt
                           on gt.Id equals dvtt.IdHoSoThau
                           select new HoSoThauN13Dto
                           {

                               MaHoSoThau = gt.MaHoSoThau,
                               IDHoSoThau = gt.Id,
                               IDCongTrinh = ct.Id,
                               MaHinhThucThau = gt.MaHinhThucThau,
                               TenCongTrinh = ct.TenCongTrinh,
                               TenDonViTrungThau = dvtt.TenDonViThamGiaThau,
                               MaDonViTrungThau = dvtt.MaDonViThau,
                               TenHoSoThau = gt.TenHoSoThau,
                               HangMucThau = gt.HangMucThau,
                               MaCongTrinh = ct.MaCongTrinh,
                               GiaTrungThau = dvtt.GiaChaoThau,
                           };
       

            var totalCount = listItem.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                listItem = listItem.OrderBy(input.Sorting);
            }

            // paging
            var items = listItem.PageBy(input).ToList();

            // result
            return new PagedResultDto<HoSoThauN13Dto>(
                totalCount,
                items.ToList());

        }

        public PagedResultDto<HoSoThauN13Dto> GetHoSoThaus(HoSoThauN13Filter input)
        {
            var congTrinh = congTrinhRepository.GetAll().Where(x => !x.IsDelete);
            var query = hoSoThauRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaHoSoThau != null)
            {
                query = query.Where(x => x.MaHoSoThau.ToLower().Equals(input.MaHoSoThau));
            }

            // filter by value
            if (input.IdCongTrinh != null)
            {
                query = query.Where(x => x.IdCongTrinh==input.IdCongTrinh);
            }
            // filter by value
            if (input.NgayNhapHoSoThau != null)
            {
                query = query.Where(x => x.NgayNhapHoSoThau.ToLower().Equals(input.NgayNhapHoSoThau));
            }
            // filter by value
            if (input.NgayHetHanNopHoSoThau != null)
            {
                query = query.Where(x => x.NgayHetHanNopHoSoThau.ToLower().Equals(input.NgayHetHanNopHoSoThau));
            }
            // filter by value
            if (input.HangMucThau != null)
            {
                query = query.Where(x => x.HangMucThau.ToLower().Equals(input.HangMucThau));
            }
            // filter by value
            if (input.MaHinhThucThau != null)
            {
                query = query.Where(x => x.MaHinhThucThau.ToLower().Equals(input.MaHinhThucThau));
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
            var listItem = from gt in query
                           join ct in congTrinh
                           on gt.IdCongTrinh equals ct.Id
                           select new HoSoThauN13Dto
                           {
                                 Id=gt.Id,
                                MaHoSoThau = gt.MaHoSoThau,
                                HangMucThau=gt.HangMucThau,
                                NgayNhapHoSoThau=gt.NgayNhapHoSoThau,
                                MaHinhThucThau=gt.MaHinhThucThau,
                                BaoLanhDuThauBD=gt.BaoLanhDuThauBD,
                                TenCongTrinh=ct.TenCongTrinh,
                                MaCongTrinh=ct.MaCongTrinh,
                           };
           
            return new PagedResultDto<HoSoThauN13Dto>(
                totalCount,
                listItem.ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Create)]
        private int Create(HoSoThauN13Input hoSoThauInput)
        {
            hoSoThauInput.MaHoSoThau = hoSoThauInput.MaHoSoThau + "_" + hoSoThauInput.IdCongTrinh;
            var hoSoThauEntity = ObjectMapper.Map<HoSoThau_N13>(hoSoThauInput);
            SetAuditInsert(hoSoThauEntity);
            hoSoThauRepository.Insert(hoSoThauEntity);
            CurrentUnitOfWork.SaveChanges();
            var newHS = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.MaHoSoThau == hoSoThauEntity.MaHoSoThau);
            return newHS.Id;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Edit)]
        private void Update(HoSoThauN13Input hoSoThauInput)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == hoSoThauInput.Id);
            if (hoSoThauEntity == null)
            {
            }
            ObjectMapper.Map(hoSoThauInput, hoSoThauEntity);
            SetAuditEdit(hoSoThauEntity);
            hoSoThauRepository.Update(hoSoThauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
