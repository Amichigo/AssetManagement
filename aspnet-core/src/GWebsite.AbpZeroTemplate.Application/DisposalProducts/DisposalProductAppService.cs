using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.DisposalProducts
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_DisposalProduct)]
    public class DisposalProductAppService: GWebsiteAppServiceBase, IDisposalProductAppService
    {
        private readonly IRepository<DisposalProduct> disposalPlanRepository;

        public DisposalProductAppService(IRepository<DisposalProduct> disposalPlanRepository)
        {
            this.disposalPlanRepository = disposalPlanRepository;
        }

        #region Public Method

        public void CreateOrEditDisposalProduct(DisposalProductInput disposalPlanInput)
        {
            if (disposalPlanInput.Id == 0)
            {
                Create(disposalPlanInput);
            }
            else
            {
                Update(disposalPlanInput);
            }
        }

        public void DeleteDisposalProduct(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity != null)
            {
                disposalPlanEntity.IsDelete = true;
                disposalPlanRepository.Update(disposalPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DisposalProductInput GetDisposalProductForEdit(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DisposalProductInput>(disposalPlanEntity);
        }

        public PagedResultDto<DisposalProductDto> GetDisposalProducts(DisposalProductFilter input)
        {
            var query = disposalPlanRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaTS != null)
            {
                query = query.Where(x => x.MaTS.ToLower().Equals(input.MaTS));
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
            return new PagedResultDto<DisposalProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DisposalProductDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(DisposalProductInput disposalPlanInput)
        {
            var disposalPlanEntity = ObjectMapper.Map<DisposalProduct>(disposalPlanInput);
            SetAuditInsert(disposalPlanEntity);
            disposalPlanRepository.Insert(disposalPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(DisposalProductInput disposalPlanInput)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == disposalPlanInput.Id);
            if (disposalPlanEntity == null)
            {
            }
            ObjectMapper.Map(disposalPlanInput, disposalPlanEntity);
            SetAuditEdit(disposalPlanEntity);
            disposalPlanRepository.Update(disposalPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
