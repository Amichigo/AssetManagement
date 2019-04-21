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
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.HoSoThaus
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_HoSoThau)]
    public class HoSoThauAppService : GWebsiteAppServiceBase, IHoSoThauAppService
    {
        private readonly IRepository<HoSoThau> hosothauRepository;
        private readonly IRepository<DuAn> duanRepository;

        public HoSoThauAppService(IRepository<HoSoThau> hosothauRepository, IRepository<DuAn> duanRepository)
        {
            this.hosothauRepository = hosothauRepository;
            this.duanRepository = duanRepository;
        }

        #region Public Method

        public void CreateOrEditHoSoThau(HoSoThauInput hosothauInput)
        {
            if (hosothauInput.Id == 0)
            {
                Create(hosothauInput);
            }
            else
            {
                Update(hosothauInput);
            }
        }

        public void DeleteHoSoThau(int id)
        {
            var hosothauEntity = hosothauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hosothauEntity != null)
            {
                hosothauEntity.IsDelete = true;
                hosothauRepository.Update(hosothauEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HoSoThauInput GetHoSoThauForEdit(int id)
        {
            var hosothauEntity = hosothauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hosothauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HoSoThauInput>(hosothauEntity);
        }

        //public async Task<HoSoThauOutput> GetHoSoThauForEditAsync(NullableIdDto input)
        //{
        //    HoSoThau hoSoThau = null;
        //    if (input.Id.HasValue && input.Id.Value > 0)
        //    {
        //        hoSoThau = await hosothauRepository.GetAsync(input.Id.Value);
        //    }
        //    var output = new HoSoThauOutput();

        //    output.HoSoThau = hoSoThau != null
        //        ? ObjectMapper.Map<HoSoThauDto>(hoSoThau)
        //        : new HoSoThauDto();

        //    output.HoSoThaus = await hosothauRepository.GetAll()
        //        .Select(c => new ComboboxItemDto(c.Id.ToString(), c.MaHoSo))
        //        .ToListAsync();

        //    return output;
        //}

        public async Task<DuAnOutput> GetDuAnComboboxForEditAsync(NullableIdDto input)
        {
            DuAn duAn = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                duAn = await duanRepository.GetAsync(input.Id.Value);
            }
            var output = new DuAnOutput();

            output.DuAn = duAn != null
                ? ObjectMapper.Map<DuAnDto>(duAn)
                : new DuAnDto();

            output.DuAns = await duanRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.TenDuAn))
                .ToListAsync();

            return output;
        }

        public HoSoThauForViewDto GetHoSoThauForView(int id)
        {
            var hosothauEntity = hosothauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hosothauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HoSoThauForViewDto>(hosothauEntity);
        }

        public PagedResultDto<HoSoThauDto> GetHoSoThaus(HoSoThauFilter input)
        {
            var query = hosothauRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaHoSo != null)
            {
                query = query.Where(x => x.MaHoSo.ToLower().Equals(input.MaHoSo));
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
            return new PagedResultDto<HoSoThauDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<HoSoThauDto>(item)).ToList());
        }

        public async Task<ListResultDto<DuAnDto>> GetDuAnLienQuanHoSos()
        {

            var items = await duanRepository.GetAllListAsync();

            return new ListResultDto<DuAnDto>(
                items.Select(item => ObjectMapper.Map<DuAnDto>(item)).ToList());

        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(HoSoThauInput hosothauInput)
        {
            var hosothauEntity = ObjectMapper.Map<HoSoThau>(hosothauInput);
            SetAuditInsert(hosothauEntity);
            hosothauRepository.Insert(hosothauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(HoSoThauInput hosothauInput)
        {
            var hosothauEntity = hosothauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == hosothauInput.Id);
            if (hosothauEntity == null)
            {
            }
            ObjectMapper.Map(hosothauInput, hosothauEntity);
            SetAuditEdit(hosothauEntity);
            hosothauRepository.Update(hosothauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
