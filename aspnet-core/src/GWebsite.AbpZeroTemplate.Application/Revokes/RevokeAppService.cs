using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Revokes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RevokeAppService : GWebsiteAppServiceBase, IRevokeAppService
    {
        private readonly IRepository<Revoke> RevokeRepository;

        public RevokeAppService(IRepository<Revoke> RevokeRepository)
        {
            this.RevokeRepository = RevokeRepository;
        }

        #region Public Method

        public void CreateOrEditRevoke(RevokeInput RevokeInput)
        {
            if (RevokeInput.Id == 0)
            {
                Create(RevokeInput);
            }
            else
            {
                Update(RevokeInput);
            }
        }

        public void DeleteRevoke(int id)
        {
            var RevokeEntity = RevokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RevokeEntity != null)
            {
                RevokeEntity.IsDelete = true;
                RevokeRepository.Update(RevokeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RevokeInput GetRevokeForEdit(int id)
        {
            var RevokeEntity = RevokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RevokeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RevokeInput>(RevokeEntity);
        }

        public RevokeForViewDto GetRevokeForView(int id)
        {
            var RevokeEntity = RevokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RevokeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RevokeForViewDto>(RevokeEntity);
        }

        public PagedResultDto<RevokeDto> GetRevokes(RevokeFilter input)
        {
            var query = RevokeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.LoaiBatDongSan != null)
            {
                query = query.Where(x => x.LoaiBatDongSan.ToLower().Equals(input.LoaiBatDongSan));
            }
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
            }
            if (input.MaPhieuThu != null)
            {
                query = query.Where(x => x.MaPhieuThu.ToLower().Equals(input.MaPhieuThu));
            }
            if (input.TinhTrangBatDongSan != null)
            {
                query = query.Where(x => x.TinhTrangBatDongSan.ToLower().Equals(input.TinhTrangBatDongSan));
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
            return new PagedResultDto<RevokeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RevokeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RevokeInput RevokeInput)
        {
            var RevokeEntity = ObjectMapper.Map<Revoke>(RevokeInput);
            SetAuditInsert(RevokeEntity);
            RevokeRepository.Insert(RevokeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RevokeInput RevokeInput)
        {
            var RevokeEntity = RevokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == RevokeInput.Id);
            if (RevokeEntity == null)
            {
            }
            ObjectMapper.Map(RevokeInput, RevokeEntity);
            SetAuditEdit(RevokeEntity);
            RevokeRepository.Update(RevokeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
