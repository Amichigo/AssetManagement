using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.FormOfRentingAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class FormOfRentingAssetAppService : GWebsiteAppServiceBase, IFormOfRentingAssetAppService
    {
        private readonly IRepository<FormOfRentingAsset> formOfRentingAssetRepository;

        public FormOfRentingAssetAppService(IRepository<FormOfRentingAsset> formOfRentingAssetRepository)
        {
            this.formOfRentingAssetRepository = formOfRentingAssetRepository;
        }

        #region Public Method

        public void CreateOrEditFormOfRentingAsset(FormOfRentingAssetInput formOfRentingAssetInput)
        {
            if (formOfRentingAssetInput.Id == 0)
            {
                Create(formOfRentingAssetInput);
            }
            else
            {
                Update(formOfRentingAssetInput);
            }
        }

        public void DeleteFormOfRentingAsset(int id)
        {
            var formOfRentingAssetEntity = formOfRentingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (formOfRentingAssetEntity != null)
            {
                formOfRentingAssetEntity.IsDelete = true;
                formOfRentingAssetRepository.Update(formOfRentingAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public FormOfRentingAssetInput GetFormOfRentingAssetForEdit(int id)
        {
            var formOfRentingAssetEntity = formOfRentingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (formOfRentingAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<FormOfRentingAssetInput>(formOfRentingAssetEntity);
        }

        public FormOfRentingAssetForViewDto GetFormOfRentingAssetForView(int id)
        {
            var formOfRentingAssetEntity = formOfRentingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (formOfRentingAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<FormOfRentingAssetForViewDto>(formOfRentingAssetEntity);
        }

        public PagedResultDto<FormOfRentingAssetDto> GetFormOfRentingAssets(FormOfRentingAssetFilter input)
        {
            var query = formOfRentingAssetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.FormOfRenting != null)
            {
                query = query.Where(x => x.FormOfRenting.ToLower().Equals(input.FormOfRenting));
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
            return new PagedResultDto<FormOfRentingAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<FormOfRentingAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(FormOfRentingAssetInput formOfRentingAssetInput)
        {
            var formOfRentingAssetEntity = ObjectMapper.Map<FormOfRentingAsset>(formOfRentingAssetInput);
            SetAuditInsert(formOfRentingAssetEntity);
            formOfRentingAssetRepository.Insert(formOfRentingAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(FormOfRentingAssetInput formOfRentingAssetInput)
        {
            var formOfRentingAssetEntity = formOfRentingAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == formOfRentingAssetInput.Id);
            if (formOfRentingAssetEntity == null)
            {
            }
            ObjectMapper.Map(formOfRentingAssetInput, formOfRentingAssetEntity);
            SetAuditEdit(formOfRentingAssetEntity);
            formOfRentingAssetRepository.Update(formOfRentingAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
