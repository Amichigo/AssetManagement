using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13;

namespace GWebsite.AbpZeroTemplate.Web.Core.KeHoach_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung)]
    public class KeHoachXayDungAppService : GWebsiteAppServiceBase, IKeHoachXayDungAppService
    {
        private readonly IRepository<KeHoachXayDung_N13> keHoachXayDungRepository;

        public KeHoachXayDungAppService(IRepository<KeHoachXayDung_N13> keHoachXayDungRepository)
        {
            this.keHoachXayDungRepository = keHoachXayDungRepository;
        }

        #region Public Method

        public int CreateOrEditKeHoachXayDung(KeHoachXayDungInput keHoachXayDungInput)
        {
            if (keHoachXayDungInput.Id == 0)
            {
               return Create(keHoachXayDungInput);
            }
            else
            {
                Update(keHoachXayDungInput);
            }
            return 0;
        }

        public void DeleteKeHoachXayDung(int id)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (keHoachXayDungEntity != null)
            {
                keHoachXayDungEntity.IsDelete = true;
                keHoachXayDungRepository.Update(keHoachXayDungEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public KeHoachXayDungInput GetKeHoachXayDungForEdit(int id)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (keHoachXayDungEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<KeHoachXayDungInput>(keHoachXayDungEntity);
        }

        public KeHoachXayDungForViewDto GetKeHoachXayDungForView(int id)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (keHoachXayDungEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<KeHoachXayDungForViewDto>(keHoachXayDungEntity);
        }

        public PagedResultDto<KeHoachXayDungDto> GetKeHoachXayDungs(KeHoachXayDungFilter input)
        {
            var query = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
            }

            // filter by value
            if (input.TenKeHoach != null)
            {
                query = query.Where(x => x.TenKeHoach.ToLower().Equals(input.TenKeHoach));
            }
            // filter by value
            if (input.TrangThaiDuyet != null)
            {
                query = query.Where(x => x.TrangThaiDuyet.ToLower().Equals(input.TrangThaiDuyet));
            }
            // filter by value
            if (input.NamThucHien != null)
            {
                query = query.Where(x => x.NamThucHien.ToLower().Equals(input.NamThucHien));
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
            return new PagedResultDto<KeHoachXayDungDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<KeHoachXayDungDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Create)]
        private int Create(KeHoachXayDungInput keHoachXayDungInput)
        {
            var nextID = keHoachXayDungRepository.GetAll().Count() + 1;
            keHoachXayDungInput.MaKeHoach = keHoachXayDungInput.MaKeHoach + "00" + nextID;
            var keHoachXayDungEntity = ObjectMapper.Map<KeHoachXayDung_N13>(keHoachXayDungInput);
            SetAuditInsert(keHoachXayDungEntity);
            keHoachXayDungRepository.Insert(keHoachXayDungEntity);
            CurrentUnitOfWork.SaveChanges();
            var newKH = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).FirstOrDefault(x => x.MaKeHoach == keHoachXayDungInput.MaKeHoach);
            if (newKH == null) return 0;
            return newKH.Id;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Edit)]
        private void Update(KeHoachXayDungInput keHoachXayDungInput)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == keHoachXayDungInput.Id);
            if (keHoachXayDungEntity == null)
            {
            }
            ObjectMapper.Map(keHoachXayDungInput, keHoachXayDungEntity);
            SetAuditEdit(keHoachXayDungEntity);
            keHoachXayDungRepository.Update(keHoachXayDungEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
