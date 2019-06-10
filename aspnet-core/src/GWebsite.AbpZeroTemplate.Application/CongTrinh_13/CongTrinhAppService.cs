using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application.Share.CongTrinh_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using GWebsite.AbpZeroTemplate.Application;
using Abp.Application.Services.Dto;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13;

namespace GWebsite.AbpZeroTemplate.Web.Core.CongTrinh_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang)]
    public class CongTrinhAppService : GWebsiteAppServiceBase, ICongTrinhAppService
    {
        private readonly IRepository<CongTrinh_N13> congTrinhRepository;
        private readonly IRepository<KeHoachXayDung_N13> keHoachXayDungRepository;
        public CongTrinhAppService(IRepository<CongTrinh_N13> congTrinhRepository, IRepository<KeHoachXayDung_N13> keHoachXayDungRepository)
        {
            this.congTrinhRepository = congTrinhRepository;
            this.keHoachXayDungRepository = keHoachXayDungRepository;
        }

        #region Public Method

        public void CreateOrEditCongTrinh(CongTrinhInput congTrinhInput)
        {
            if (congTrinhInput.Id == 0)
            {
                Create(congTrinhInput);
            }
            else
            {
                Update(congTrinhInput);
            }
        }

        public void DeleteCongTrinh(int id)
        {
            var congTrinhEntity = congTrinhRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (congTrinhEntity != null)
            {
                congTrinhEntity.IsDelete = true;
                congTrinhRepository.Update(congTrinhEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CongTrinhInput GetCongTrinhForEdit(int id)
        {
            var congTrinhEntity = congTrinhRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (congTrinhEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CongTrinhInput>(congTrinhEntity);
        }

        public CongTrinhForViewDto GetCongTrinhForView(int id)
        {
            var congTrinhEntity = congTrinhRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (congTrinhEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CongTrinhForViewDto>(congTrinhEntity);
        }

        
        public CongTrinhForViewDto GetCongTrinhForViewByMCT(string GetCongTrinhForViewByMCT)
        {
            var congTrinhEntity = congTrinhRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.MaCongTrinh == GetCongTrinhForViewByMCT);
            if (congTrinhEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CongTrinhForViewDto>(congTrinhEntity);
        }
        public PagedResultDto<CongTrinhDto> GetCongTrinhs(CongTrinhFilter input)
        {
            var query = congTrinhRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
            }

            // filter by value
            if (input.TenCongTrinh != null)
            {
                query = query.Where(x => x.TenCongTrinh.ToLower().Equals(input.TenCongTrinh));
            }

            // filter by value
            if (input.idKeHoach != null)
            {
                query = query.Where(x => x.idKeHoach==input.idKeHoach);
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
            return new PagedResultDto<CongTrinhDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CongTrinhDto>(item)).ToList());
        }

        public PagedResultDto<CongTrinhDto> GetDsCongTrinhTheoDuAn(CongTrinhFilter input)
        {
            var query = congTrinhRepository.GetAll().Where(x => !x.IsDelete).Where(da=>da.MaDuAnXayDungCoBan!=null);
            var khquery = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
            }

            // filter by value
            if (input.idKeHoach != null)
            {
                query = query.Where(x => x.idKeHoach == input.idKeHoach);
            }

            var listCT = from ct in query
                         join kt in khquery
                         on ct.idKeHoach equals kt.Id
                         select new CongTrinhDto
                         {
                             Id=ct.Id,
                             MaCongTrinh = ct.MaCongTrinh,
                             MaKeHoach = kt.MaKeHoach,
                             TenCongTrinh = ct.TenCongTrinh,
                             NamThucHien = kt.NamThucHien,
                             KinhPhiDuocDuyet = ct.KinhPhiDuocDuyet,
                             KinhPhiDeXuat=ct.KinhPhiDeXuat,
                             ChiPhiDaSuDung = ct.ChiPhiDaSuDung,
                             TienDoThucHien = ct.TienDoThucHien,
                             DuKienXayDung = ct.DuKienXayDung,
                             DuKienHoanThanh = ct.DuKienHoanThanh,
                             GhiChu = ct.GhiChu,
                             NgayThiCongThucTe = ct.NgayThiCongThucTe,
                         };
          

            var totalCount = listCT.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                listCT = listCT.OrderBy(input.Sorting);
            }

            // paging
            var items = listCT.PageBy(input).ToList();

            // result
            return new PagedResultDto<CongTrinhDto>(
                totalCount,
                items.ToList());
        }
        public PagedResultDto<CongTrinhDto> GetCongTrinhKhongThuocDuAn(CongTrinhFilter input)
        {
            var query = congTrinhRepository.GetAll().Where(x => !x.IsDelete).Where(da => da.MaDuAnXayDungCoBan == null); ;
            // filter by value
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
            }

            // filter by value
            if (input.TenCongTrinh != null)
            {
                query = query.Where(x => x.TenCongTrinh.ToLower().Equals(input.TenCongTrinh));
            }
            // filter by value
            if (input.idKeHoach != null)
            {
                query = query.Where(x => x.idKeHoach==input.idKeHoach);
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
            return new PagedResultDto<CongTrinhDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CongTrinhDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Create)]
        private void Create(CongTrinhInput congTrinhInput)
        {
           int nextID = congTrinhRepository.GetAll().Count() + 1;
            congTrinhInput.MaCongTrinh = congTrinhInput.MaCongTrinh +"_00"+nextID;
            var congTrinhEntity = ObjectMapper.Map<CongTrinh_N13>(congTrinhInput);
            SetAuditInsert(congTrinhEntity);
            congTrinhRepository.Insert(congTrinhEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Edit)]
        private void Update(CongTrinhInput congTrinhInput)
        {
            var congTrinhEntity = congTrinhRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == congTrinhInput.Id);
            if (congTrinhEntity == null)
            {
            }
            ObjectMapper.Map(congTrinhInput, congTrinhEntity);
            SetAuditEdit(congTrinhEntity);
            congTrinhRepository.Update(congTrinhEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
