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
using GWebsite.AbpZeroTemplate.Application.Share.DuAns;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.DuAns
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_DuAn)]
    public class DuAnAppService : GWebsiteAppServiceBase, IDuAnAppService
    {
        private readonly IRepository<DuAn> duanRepository;

        public DuAnAppService(IRepository<DuAn> duanRepository)
        {
            this.duanRepository = duanRepository;
        }

        #region Public Method

        public void CreateOrEditDuAn(DuAnInput duanInput)
        {
            if (duanInput.Id == 0)
            {
                Create(duanInput);
            }
            else
            {
                Update(duanInput);
            }
        }

        public void DeleteDuAn(int id)
        {
            var duanEntity = duanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (duanEntity != null)
            {
                duanEntity.IsDelete = true;
                duanRepository.Update(duanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DuAnInput GetDuAnForEdit(int id)
        {
            var duanEntity = duanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (duanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DuAnInput>(duanEntity);
        }

        public DuAnForViewDto GetDuAnForView(int id)
        {
            var duanEntity = duanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (duanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DuAnForViewDto>(duanEntity);
        }

        public PagedResultDto<DuAnDto> GetDuAns(DuAnFilter input)
        {
            var query = duanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.TenDuAn != null)
            {
                query = query.Where(x => x.TenDuAn.ToLower().Equals(input.TenDuAn));
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
            return new PagedResultDto<DuAnDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DuAnDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_DuAn_Create)]
        private void Create(DuAnInput customerInput)
        {
            var duanEntity = ObjectMapper.Map<DuAn>(customerInput);
            SetAuditInsert(duanEntity);
            duanRepository.Insert(duanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_DuAn_Edit)]
        private void Update(DuAnInput customerInput)
        {
            var duanEntity = duanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == customerInput.Id);
            if (duanEntity == null)
            {
            }
            ObjectMapper.Map(customerInput, duanEntity);
            SetAuditEdit(duanEntity);
            duanRepository.Update(duanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}

