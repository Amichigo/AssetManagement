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
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.NhaCungCaps
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_NhaCungCap)]
    public class NhaCungCapAppService : GWebsiteAppServiceBase, INhaCungCapAppService
    {
        private readonly IRepository<NhaCungCap> nhacungcapRepository;

        public NhaCungCapAppService(IRepository<NhaCungCap> nhacungcapRepository)
        {
            this.nhacungcapRepository = nhacungcapRepository;
        }

        #region Public Method

        public void CreateOrEditNhaCungCap(NhaCungCapInput nhacungcapInput)
        {
            if (nhacungcapInput.Id == 0)
            {
                Create(nhacungcapInput);
            }
            else
            {
                Update(nhacungcapInput);
            }
        }

        public void DeleteNhaCungCap(int id)
        {
            var nhacungcapEntity = nhacungcapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (nhacungcapEntity != null)
            {
                nhacungcapEntity.IsDelete = true;
                nhacungcapRepository.Update(nhacungcapEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public NhaCungCapInput GetNhaCungCapForEdit(int id)
        {
            var nhacungcapEntity = nhacungcapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (nhacungcapEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhaCungCapInput>(nhacungcapEntity);
        }

        public NhaCungCapForViewDto GetNhaCungCapForView(int id)
        {
            var nhacungcapEntity = nhacungcapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (nhacungcapEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhaCungCapForViewDto>(nhacungcapEntity);
        }

        public PagedResultDto<NhaCungCapDto> GetNhaCungCaps(NhaCungCapFilter input)
        {
            var query = nhacungcapRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.TenNhaCungCap != null)
            {
                query = query.Where(x => x.TenNhaCungCap.ToLower().Equals(input.TenNhaCungCap));
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
            return new PagedResultDto<NhaCungCapDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<NhaCungCapDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(NhaCungCapInput nhacungcapInput)
        {
            var nhacungcapEntity = ObjectMapper.Map<NhaCungCap>(nhacungcapInput);
            SetAuditInsert(nhacungcapEntity);
            nhacungcapRepository.Insert(nhacungcapEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(NhaCungCapInput nhacungcapInput)
        {
            var nhacungcapEntity = nhacungcapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == nhacungcapInput.Id);
            if (nhacungcapEntity == null)
            {
            }
            ObjectMapper.Map(nhacungcapInput, nhacungcapEntity);
            SetAuditEdit(nhacungcapEntity);
            nhacungcapRepository.Update(nhacungcapEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
