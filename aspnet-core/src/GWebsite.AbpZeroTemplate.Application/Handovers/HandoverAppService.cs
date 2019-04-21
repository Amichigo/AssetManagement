using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Handovers;
using GWebsite.AbpZeroTemplate.Application.Share.Handovers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Handovers
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class HandoverAppService : GWebsiteAppServiceBase, IHandoverAppService
    {
        private readonly IRepository<Handover> HandoverRepository;

        public HandoverAppService(IRepository<Handover> HandoverRepository)
        {
            this.HandoverRepository = HandoverRepository;
        }

        #region Public Method

        public void CreateOrEditHandover(HandoverInput HandoverInput)
        {
            if (HandoverInput.Id == 0)
            {
                Create(HandoverInput);
            }
            else
            {
                Update(HandoverInput);
            }
        }

        public void DeleteHandover(int id)
        {
            var HandoverEntity = HandoverRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (HandoverEntity != null)
            {
                HandoverEntity.IsDelete = true;
                HandoverRepository.Update(HandoverEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HandoverInput GetHandoverForEdit(int id)
        {
            var HandoverEntity = HandoverRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (HandoverEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HandoverInput>(HandoverEntity);
        }

        public HandoverForViewDto GetHandoverForView(int id)
        {
            var HandoverEntity = HandoverRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (HandoverEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HandoverForViewDto>(HandoverEntity);
        }

        public PagedResultDto<HandoverDto> GetHandovers(HandoverFilter input)
        {
            var query = HandoverRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.LoaiBatDongSan != null)
            {
                query = query.Where(x => x.LoaiBatDongSan.ToLower().Equals(input.LoaiBatDongSan));
            }
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
            }
            if (input.MaPhieuNhan != null)
            {
                query = query.Where(x => x.MaPhieuNhan.ToLower().Equals(input.MaPhieuNhan));
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
            return new PagedResultDto<HandoverDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<HandoverDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(HandoverInput HandoverInput)
        {
            var HandoverEntity = ObjectMapper.Map<Handover>(HandoverInput);
            SetAuditInsert(HandoverEntity);
            HandoverRepository.Insert(HandoverEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(HandoverInput HandoverInput)
        {
            var HandoverEntity = HandoverRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == HandoverInput.Id);
            if (HandoverEntity == null)
            {
            }
            ObjectMapper.Map(HandoverInput, HandoverEntity);
            SetAuditEdit(HandoverEntity);
            HandoverRepository.Update(HandoverEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
