using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.HopDong_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HopDong)]
    public class HopDongN13AppService : GWebsiteAppServiceBase, IHopDongN13AppService
    {
        private readonly IRepository<HopDong_N13> hopDongRepository;
        private readonly IRepository<HoSoThau_N13> hoSoThauRepository;
        public HopDongN13AppService(IRepository<HopDong_N13> hopDongRepository, IRepository<HoSoThau_N13> hoSoThauRepository)
        {
            this.hopDongRepository = hopDongRepository;
            this.hoSoThauRepository = hoSoThauRepository;
        }

        #region Public Method

        public int CreateOrEditHopDong(HopDongN13Input hopDongInput, int idGoiThau)
        {
            if (hopDongInput.Id == 0)
            {
               return Create(hopDongInput, idGoiThau);
            }
            else
            {
                Update(hopDongInput);
            }
            return 0;
        }

        public void DeleteHopDong(int id)
        {
            var hopDongEntity = hopDongRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hopDongEntity != null)
            {
                hopDongEntity.IsDelete = true;
                hopDongRepository.Update(hopDongEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HopDongN13Input GetHopDongForEdit(int id)
        {
            var hopDongEntity = hopDongRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hopDongEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HopDongN13Input>(hopDongEntity);
        }

        public HopDongN13ForViewDto GetHopDongForView(int id)
        {
            var hopDongEntity = hopDongRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hopDongEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HopDongN13ForViewDto>(hopDongEntity);
        }

        public PagedResultDto<HopDongN13Dto> GetHopDongs(HopDongN13Filter input)
        {
            var query = hopDongRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.SoHopDong != null)
            {
                query = query.Where(x => x.SoHopDong.ToLower().Equals(input.SoHopDong));
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
            return new PagedResultDto<HopDongN13Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<HopDongN13Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HopDong_Create)]
        private int Create(HopDongN13Input hopDongInput,int idGoiThau)
        {
            var nextId = hopDongRepository.GetAll().Count() + 1;
            hopDongInput.MaHopDong = hopDongInput.MaHopDong + "HD00" + nextId;
           
            var hopDongEntity = ObjectMapper.Map<HopDong_N13>(hopDongInput);
            SetAuditInsert(hopDongEntity);
            hopDongRepository.Insert(hopDongEntity);
            CurrentUnitOfWork.SaveChanges();

            var newHD = hopDongRepository.GetAll().FirstOrDefault(x => x.MaHopDong == hopDongInput.MaHopDong);
            if (newHD == null) return 0;
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == idGoiThau);
            hoSoThauEntity.IdHopDong = newHD.Id;
            hoSoThauRepository.Update(hoSoThauEntity);
            return newHD.Id;
        
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HopDong_Edit)]
        private void Update(HopDongN13Input hopDongInput)
        {
            var hopDongEntity = hopDongRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == hopDongInput.Id);
            if (hopDongEntity == null)
            {
            }
            ObjectMapper.Map(hopDongInput, hopDongEntity);
            SetAuditEdit(hopDongEntity);
            hopDongRepository.Update(hopDongEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
