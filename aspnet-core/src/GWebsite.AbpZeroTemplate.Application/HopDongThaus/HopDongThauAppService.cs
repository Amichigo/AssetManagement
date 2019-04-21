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
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.HopDongThaus
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_HopDongThau)]
    public class HopDongThauAppService : GWebsiteAppServiceBase, IHopDongThauAppService
    {
        private readonly IRepository<HopDongThau> hopdongthauRepository;
        private readonly IRepository<HoSoThau> hosothauRepository;
        private readonly IRepository<NhaCungCap> nhacungcapRepository;

        public HopDongThauAppService(IRepository<HopDongThau> hopdongthauRepository, IRepository<HoSoThau> hosothauRepository, IRepository<NhaCungCap> nhacungcapRepository)
        {
            this.hopdongthauRepository = hopdongthauRepository;
            this.hosothauRepository = hosothauRepository;
            this.nhacungcapRepository = nhacungcapRepository;
        }

        #region Public Method

        public void CreateOrEditHopDongThau(HopDongThauInput hopdongthauInput)
        {
            if (hopdongthauInput.Id == 0)
            {
                Create(hopdongthauInput);
            }
            else
            {
                Update(hopdongthauInput);
            }
        }

        public void DeleteHopDongThau(int id)
        {
            var hopdongthauEntity = hopdongthauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hopdongthauEntity != null)
            {
                hopdongthauEntity.IsDelete = true;
                hopdongthauRepository.Update(hopdongthauEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HopDongThauInput GetHopDongThauForEdit(int id)
        {
            var hopdongthauEntity = hopdongthauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hopdongthauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HopDongThauInput>(hopdongthauEntity);
        }

        public HopDongThauForViewDto GetHopDongThauForView(int id)
        {
            var hopdongthauEntity = hopdongthauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hopdongthauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HopDongThauForViewDto>(hopdongthauEntity);
        }

        public PagedResultDto<HopDongThauDto> GetHopDongThaus(HopDongThauFilter input)
        {
            var query = hopdongthauRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.TenHopDong != null)
            {
                query = query.Where(x => x.TenHopDong.ToLower().Equals(input.TenHopDong));
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
            return new PagedResultDto<HopDongThauDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<HopDongThauDto>(item)).ToList());
        }

        public async Task<HoSoThauOutput> GetHoSoThauComboboxForEditAsync(NullableIdDto input)
        {
            HoSoThau hoSoThau = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                hoSoThau = await hosothauRepository.GetAsync(input.Id.Value);
            }
            var output = new HoSoThauOutput();

            output.HoSoThau = hoSoThau != null
                ? ObjectMapper.Map<HoSoThauDto>(hoSoThau)
                : new HoSoThauDto();

            output.HoSoThaus = await hosothauRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.MaHoSo))
                .ToListAsync();

            return output;
        }

        public async Task<NhaCungCapOutput> GetNhaCungCapComboboxForEditAsync(NullableIdDto input)
        {
            NhaCungCap nhaCungCap = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                nhaCungCap = await nhacungcapRepository.GetAsync(input.Id.Value);
            }
            var output = new NhaCungCapOutput();

            output.NhaCungCap = nhaCungCap != null
                ? ObjectMapper.Map<NhaCungCapDto>(nhaCungCap)
                : new NhaCungCapDto();

            output.NhaCungCaps = await nhacungcapRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.TenNhaCungCap))
                .ToListAsync();

            return output;
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(HopDongThauInput hopdongthauInput)
        {
            var hopdongthauEntity = ObjectMapper.Map<HopDongThau>(hopdongthauInput);
            SetAuditInsert(hopdongthauEntity);
            hopdongthauRepository.Insert(hopdongthauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(HopDongThauInput hopdongthauInput)
        {
            var hopdongthauEntity = hopdongthauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == hopdongthauInput.Id);
            if (hopdongthauEntity == null)
            {
            }
            ObjectMapper.Map(hopdongthauInput, hopdongthauEntity);
            SetAuditEdit(hopdongthauEntity);
            hopdongthauRepository.Update(hopdongthauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
