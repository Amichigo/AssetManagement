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
using System.Linq;
using System.Linq.Dynamic.Core;
namespace GWebsite.AbpZeroTemplate.Web.Core.BatDongSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_QuanLyBatDongSan_BatDongSan)]
    public class BatDongSanAppService : GWebsiteAppServiceBase, IBatDongSanAppService
    {
        private readonly IRepository<BatDongSan> batdongsanRepository;

        public BatDongSanAppService(IRepository<BatDongSan> batdongsanRepository)
        {
            this.batdongsanRepository = batdongsanRepository;
        }

        #region Public Method

        public void CreateOrEditBatDongSan(BatDongSanInput batdongsanInput)
        {
            if (batdongsanInput.Id == 0)
            {
                Create(batdongsanInput);
            }
            else
            {
                Update(batdongsanInput);
            }
        }

        public void DeleteBatDongSan(int id)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (batdongsanEntity != null)
            {
                batdongsanEntity.IsDelete = true;
                batdongsanRepository.Update(batdongsanEntity);
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
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (batdongsanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BatDongSanForViewDto>(batdongsanEntity);
        }

        public PagedResultDto<BatDongSanDto> GetBatDongSans(BatDongSanFilter input)
        {
            var query = batdongsanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
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
            return new PagedResultDto<BatDongSanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BatDongSanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyBatDongSan_BatDongSan_Create)]
        private void Create(BatDongSanInput batdongsanInput)
        {
            batdongsanInput.MaBatDongSan = "BDS"+ DateTime.Now.ToString("yyyyMMddHHmmss");
            var batdongsanEntity = ObjectMapper.Map<BatDongSan>(batdongsanInput);
            SetAuditInsert(batdongsanEntity);
            batdongsanRepository.Insert(batdongsanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyBatDongSan_BatDongSan_Edit)]
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
