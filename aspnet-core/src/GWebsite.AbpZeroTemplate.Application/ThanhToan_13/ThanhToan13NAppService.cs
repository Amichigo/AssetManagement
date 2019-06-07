using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13;

namespace GWebsite.AbpZeroTemplate.Web.Core.ThanhToan_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HopDong)]
    public class ThanhToanN13AppService : GWebsiteAppServiceBase, IThanhToanN13AppService
    {
        private readonly IRepository<ThanhToan_N13> thanhToanRepository;

        public ThanhToanN13AppService(IRepository<ThanhToan_N13> thanhToanRepository)
        {
            this.thanhToanRepository = thanhToanRepository;
        }

        #region Public Method

        public void CreateOrEditThanhToanN13(ThanhToanN13Input thanhToanInput)
        {
            if (thanhToanInput.Id == 0)
            {
                Create(thanhToanInput);
            }
            else
            {
                Update(thanhToanInput);
            }
        }

        public void DeleteThanhToanN13(int id)
        {
            var thanhToanEntity = thanhToanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (thanhToanEntity != null)
            {
                thanhToanEntity.IsDelete = true;
                thanhToanRepository.Update(thanhToanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ThanhToanN13Input GetThanhToanN13ForEdit(int id)
        {
            var thanhToanEntity = thanhToanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (thanhToanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ThanhToanN13Input>(thanhToanEntity);
        }

        public ThanhToanN13ForViewDto GetThanhToanN13ForView(int id)
        {
            var thanhToanEntity = thanhToanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (thanhToanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ThanhToanN13ForViewDto>(thanhToanEntity);
        }

        public PagedResultDto<ThanhToanN13Dto> GetThanhToanN13s(ThanhToanN13Filter input)
        {
            var query = thanhToanRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
    
            // filter by value
            if (input.MaHopDong != null)
            {
                query = query.Where(x => x.MaHopDong.ToLower().Equals(input.MaHopDong));
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
            return new PagedResultDto<ThanhToanN13Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ThanhToanN13Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HopDong_Create)]
        private void Create(ThanhToanN13Input thanhToanInput)
        {
         
            var thanhToanEntity = ObjectMapper.Map<ThanhToan_N13>(thanhToanInput);
            SetAuditInsert(thanhToanEntity);
            thanhToanRepository.Insert(thanhToanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HopDong_Edit)]
        private void Update(ThanhToanN13Input thanhToanInput)
        {
            var thanhToanEntity = thanhToanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == thanhToanInput.Id);
            if (thanhToanEntity == null)
            {
            }
            ObjectMapper.Map(thanhToanInput, thanhToanEntity);
            SetAuditEdit(thanhToanEntity);
            thanhToanRepository.Update(thanhToanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
