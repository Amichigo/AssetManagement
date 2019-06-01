using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.TypeOfRentalAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class TypeOfRentalAssetAppService : GWebsiteAppServiceBase, ITypeOfRentalAssetAppService
    {
        private readonly IRepository<TypeOfRentalAsset> typeOfRentalAssetRepository;

        public TypeOfRentalAssetAppService(IRepository<TypeOfRentalAsset> typeOfRentalAssetRepository)
        {
            this.typeOfRentalAssetRepository = typeOfRentalAssetRepository;
        }

        #region Public Method

        public void CreateOrEditTypeOfRentalAsset(TypeOfRentalAssetInput typeOfRentalAssetInput)
        {
            if (typeOfRentalAssetInput.Id == 0)
            {
                Create(typeOfRentalAssetInput);
            }
            else
            {
                Update(typeOfRentalAssetInput);
            }
        }

        public void DeleteTypeOfRentalAsset(int id)
        {
            var typeOfRentalAssetEntity = typeOfRentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typeOfRentalAssetEntity != null)
            {
                typeOfRentalAssetEntity.IsDelete = true;
                typeOfRentalAssetRepository.Update(typeOfRentalAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TypeOfRentalAssetInput GetTypeOfRentalAssetForEdit(int id)
        {
            var typeOfRentalAssetEntity = typeOfRentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typeOfRentalAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TypeOfRentalAssetInput>(typeOfRentalAssetEntity);
        }

        public TypeOfRentalAssetForViewDto GetTypeOfRentalAssetForView(int id)
        {
            var typeOfRentalAssetEntity = typeOfRentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typeOfRentalAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TypeOfRentalAssetForViewDto>(typeOfRentalAssetEntity);
        }

        public PagedResultDto<TypeOfRentalAssetDto> GetTypeOfRentalAssets(TypeOfRentalAssetFilter input)
        {
            var query = typeOfRentalAssetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.TypeOfAsset != null)
            {
                query = query.Where(x => x.TypeOfAsset.ToLower().Equals(input.TypeOfAsset));
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
            return new PagedResultDto<TypeOfRentalAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TypeOfRentalAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(TypeOfRentalAssetInput typeOfRentalAssetInput)
        {
            var typeOfRentalAssetEntity = ObjectMapper.Map<TypeOfRentalAsset>(typeOfRentalAssetInput);
            SetAuditInsert(typeOfRentalAssetEntity);
            typeOfRentalAssetRepository.Insert(typeOfRentalAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(TypeOfRentalAssetInput typeOfRentalAssetInput)
        {
            var typeOfRentalAssetEntity = typeOfRentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == typeOfRentalAssetInput.Id);
            if (typeOfRentalAssetEntity == null)
            {
            }
            ObjectMapper.Map(typeOfRentalAssetInput, typeOfRentalAssetEntity);
            SetAuditEdit(typeOfRentalAssetEntity);
            typeOfRentalAssetRepository.Update(typeOfRentalAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
