using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.BatDongSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan)]
    public class BatDongSanAppService : GWebsiteAppServiceBase, IBatDongSanAppService
    {
        private readonly IRepository<BatDongSan> batdongsanRepository;
        private readonly IRepository<LoaiBatDongSan> loaiBDSRepos;
        private readonly IRepository<TaiSan_13> taisanRepos;
        private readonly IRepository<LoaiSoHuu> loaishRepos;
        public BatDongSanAppService(IRepository<BatDongSan> batdongsanRepository, IRepository<LoaiBatDongSan> loaiBDSRepos, IRepository<TaiSan_13> taisanRepos, IRepository<LoaiSoHuu> loaishRepos)
        {
            this.batdongsanRepository = batdongsanRepository;
            this.loaiBDSRepos = loaiBDSRepos;
            this.taisanRepos = taisanRepos;
            this.loaishRepos = loaishRepos;
        }

        #region Public Method

        public void CreateOrEditBatDongSan(BatDongSanInput batdongsanInput, int IdTaiSan = 0)
        {
            if (batdongsanInput.Id == 0)
            {
                Create(batdongsanInput, IdTaiSan);
            }
            else
            {
                Update(batdongsanInput);
            }
        }

        public void DeleteBatDongSan(int id)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            var taiSanEntity = taisanRepos.GetAll().Where(x => !x.IsDelete).FirstOrDefault(y => y.IdBatDongSan == batdongsanEntity.Id);
            if (batdongsanEntity != null)
            {
                batdongsanEntity.IsDelete = true;
                batdongsanRepository.Update(batdongsanEntity);
                taiSanEntity.IdBatDongSan = null;
                taisanRepos.Update(taiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BatDongSanInput GetBatDongSanForEdit(int id)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (batdongsanEntity == null)
            {
                return null;
            }

            return ObjectMapper.Map<BatDongSanInput>(batdongsanEntity);
        }

        public BatDongSanForViewDto GetBatDongSanForView(int id)
        {
            var lquery = loaiBDSRepos.GetAll().Where(x => !x.IsDelete);
            var lshquery = loaishRepos.GetAll().Where(x => !x.IsDelete);
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.Id == id);
            if (batdongsanEntity == null)
            {
                return null;
            }
            var item = from bds in batdongsanEntity
                       join lbds in lquery
                       on bds.IdLoaiBDS equals lbds.Id
                       join lsh in lshquery
                       on bds.IdLoaiBDS equals lsh.Id
                       select new BatDongSanForViewDto
                       {
                           MaBatDongSan = bds.MaBatDongSan,
                           MaPhongGiaoDich = bds.MaPhongGiaoDich,
                           NgayMuaBatDongSan = bds.NgayMuaBatDongSan,
                           HienTrangBDS = bds.HienTrangBDS,
                           MaLoaiBDS = lbds.Name,
                           ChieuDai = bds.ChieuDai,
                           ChieuRong = bds.ChieuRong,
                           DienTichDatNen = bds.DienTichDatNen,
                           DienTichXayDung = bds.DienTichXayDung,
                           MaTinhTrangSuDungDat = bds.MaTinhTrangSuDungDat,
                           MaTinhTrangXayDung = bds.MaTinhTrangXayDung,
                           CongNangSuDung = bds.CongNangSuDung,
                           KetCauNha = bds.KetCauNha,
                           RanhGioi = bds.RanhGioi,
                           MaHienTrangPhapLy = bds.MaHienTrangPhapLy,
                           MaLoaiSoHuu = lsh.Name,
                           ChuSoHuu = bds.ChuSoHuu,
                           GhiChu = bds.GhiChu,
                           FileDinhKem = bds.FileDinhKem,
                       };
            return item.SingleOrDefault();
        }

        public PagedResultDto<BatDongSanDto> GetBatDongSans(BatDongSanFilter input)
        {
            var query = batdongsanRepository.GetAll().Where(x => !x.IsDelete);
            var lquery = loaiBDSRepos.GetAll().Where(x => !x.IsDelete);
            var lshquery = loaishRepos.GetAll().Where(x => !x.IsDelete);
            var tsquery = taisanRepos.GetAll().Where(x => !x.IsDelete).Where(y => y.IdBatDongSan != null);


            // filter by value
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
            }
            // filter by loai bds
            if (input.IdLoaiBDS != null)
            {
                query = query.Where(x => x.IdLoaiBDS == input.IdLoaiBDS);
            }



            var tableBDS = from bds in query
                           join a in lquery
                           on bds.IdLoaiBDS equals a.Id
                           join lsh in lshquery
                           on bds.IdLoaiSoHuu equals lsh.Id
                           join t in tsquery
                           on bds.Id equals t.IdBatDongSan
                           select new BatDongSanDto
                           {
                               MaBatDongSan = bds.MaBatDongSan,
                               DienTichDatNen = bds.DienTichDatNen,
                               DiaChi = t.DiaChi,
                               DienTichXayDung = bds.DienTichXayDung,
                               ChieuDai = bds.ChieuDai,
                               ChieuRong = bds.ChieuRong,
                               ChuSoHuu = bds.ChuSoHuu,
                               CongNangSuDung = bds.CongNangSuDung,
                               FileDinhKem = bds.FileDinhKem,
                               HienTrangBDS = bds.HienTrangBDS,
                               MaLoaiBDS = a.Name,
                               MaPhongGiaoDich = bds.MaPhongGiaoDich,
                               MaTinhTrangSuDungDat = bds.MaTinhTrangSuDungDat,
                               MaTinhTrangXayDung = bds.MaTinhTrangXayDung,
                               NgayMuaBatDongSan = bds.NgayMuaBatDongSan,
                               GhiChu = bds.GhiChu,
                               Id = bds.Id,
                               KetCauNha = bds.KetCauNha,
                               MaHienTrangPhapLy = bds.MaHienTrangPhapLy,
                               MaLoaiSoHuu = lsh.Name,
                               MaTaiSan = t.MaTaiSan,
                               NguyenGiaTaiSan = t.NguyenGiaTaiSan,
                               RanhGioi = bds.RanhGioi,
                           };

            // filter by value
            if (input.MaTaiSan != null)
            {
                tableBDS = tableBDS.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }

            var totalCount = tableBDS.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                tableBDS = tableBDS.OrderBy(input.Sorting);
            }
            // paging
            var items = tableBDS.PageBy(input);

            var list = tableBDS.PageBy(input).ToList();

            // result
            return new PagedResultDto<BatDongSanDto>(
                totalCount,
                list.ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Create)]
        private void Create(BatDongSanInput batdongsanInput, int IdTaiSan)
        {
            int nextID = batdongsanRepository.GetAll().Count() + 1;
            batdongsanInput.MaBatDongSan = "BDS0000" + nextID;
            var batdongsanEntity = ObjectMapper.Map<BatDongSan>(batdongsanInput);
            SetAuditInsert(batdongsanEntity);
            batdongsanRepository.Insert(batdongsanEntity);
            CurrentUnitOfWork.SaveChanges();
            var newBDS = batdongsanRepository.GetAll().SingleOrDefault(x => x.MaBatDongSan == batdongsanEntity.MaBatDongSan);
            int id = newBDS.Id;
            // update cho TS
            if (IdTaiSan == 0)
            {
                return;
            }
            var taisanEntiTy = taisanRepos.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == IdTaiSan);
            taisanEntiTy.IdBatDongSan = id;
            taisanRepos.Update(taisanEntiTy);

        }


        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Edit)]
        private void Update(BatDongSanInput batdongsanInput)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == batdongsanInput.Id);
            if (batdongsanEntity == null)
            {
            }
            ObjectMapper.Map(batdongsanInput, batdongsanEntity);
            SetAuditEdit(batdongsanEntity);
            batdongsanRepository.Update(batdongsanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
