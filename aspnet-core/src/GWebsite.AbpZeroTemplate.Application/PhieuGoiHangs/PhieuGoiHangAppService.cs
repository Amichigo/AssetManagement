using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs;
using GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.PhieuGoiHangs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_PhieuGoiHang)]
    public class PhieuGoiHangAppService : GWebsiteAppServiceBase, IPhieuGoiHangAppService
    {
        private readonly IRepository<PhieuGoiHang> phieugoihangRepository;
        private readonly IRepository<HopDongThau> hopdongthauRepository;

        public PhieuGoiHangAppService(IRepository<PhieuGoiHang> phieugoihangRepository, IRepository<HopDongThau> hopdongthauRepository)
        {
            this.phieugoihangRepository = phieugoihangRepository;
            this.hopdongthauRepository = hopdongthauRepository;
        }

        #region Public Method

        public void CreateOrEditPhieuGoiHang(PhieuGoiHangInput phieugoihangInput)
        {
            if (phieugoihangInput.Id == 0)
            {
                Create(phieugoihangInput);
            }
            else
            {
                Update(phieugoihangInput);
            }
        }

        public void DeletePhieuGoiHang(int id)
        {
            var phieugoihangEntity = phieugoihangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (phieugoihangEntity != null)
            {
                phieugoihangEntity.IsDelete = true;
                phieugoihangRepository.Update(phieugoihangEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PhieuGoiHangInput GetPhieuGoiHangForEdit(int id)
        {
            var phieugoihangEntity = phieugoihangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (phieugoihangEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PhieuGoiHangInput>(phieugoihangEntity);
        }

        public async Task<HopDongThauOutput> GetHopDongThauComboboxForEditAsync(NullableIdDto input)
        {
            HopDongThau hopDongThau = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                hopDongThau = await hopdongthauRepository.GetAsync(input.Id.Value);
            }
            var output = new HopDongThauOutput();

            output.HopDongThau = hopDongThau != null
                ? ObjectMapper.Map<HopDongThauDto>(hopDongThau)
                : new HopDongThauDto();

            output.HopDongThaus = await hopdongthauRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.TenHopDong))
                .ToListAsync();

            return output;
        }

        public PhieuGoiHangForViewDto GetPhieuGoiHangForView(int id)
        {
            var phieugoihangEntity = phieugoihangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (phieugoihangEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PhieuGoiHangForViewDto>(phieugoihangEntity);
        }

        public PagedResultDto<PhieuGoiHangDto> GetPhieuGoiHangs(PhieuGoiHangFilter input)
        {
            var query = phieugoihangRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.TenKeHoach != null)
            {
                query = query.Where(x => x.TenKeHoach.ToLower().Equals(input.TenKeHoach));
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
            return new PagedResultDto<PhieuGoiHangDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PhieuGoiHangDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(PhieuGoiHangInput phieugoihangInput)
        {
            var phieugoihangEntity = ObjectMapper.Map<PhieuGoiHang>(phieugoihangInput);
            SetAuditInsert(phieugoihangEntity);
            phieugoihangRepository.Insert(phieugoihangEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(PhieuGoiHangInput phieugoihangInput)
        {
            var phieugoihangEntity = phieugoihangRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == phieugoihangInput.Id);
            if (phieugoihangEntity == null)
            {
            }
            ObjectMapper.Map(phieugoihangInput, phieugoihangEntity);
            SetAuditEdit(phieugoihangEntity);
            phieugoihangRepository.Update(phieugoihangEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
