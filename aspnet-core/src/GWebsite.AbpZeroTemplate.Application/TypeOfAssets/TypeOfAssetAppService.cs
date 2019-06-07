using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.TypeOfAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_TypeOfAsset)]
    public class TypeOfAssetAppService : GWebsiteAppServiceBase, ITypeOfAssetAppService
    {
        private readonly IRepository<TypeOfAsset> typeOfAssetRepository;

        public TypeOfAssetAppService(IRepository<TypeOfAsset> typeOfAssetRepository)
        {
            this.typeOfAssetRepository = typeOfAssetRepository;
        }

        #region Public Method

        public void CreateOrEditTypeOfAsset(TypeOfAssetInput typeOfAssetInput)
        {
            if (typeOfAssetInput.Id == 0)
            {
                Create(typeOfAssetInput);
            }
            else
            {
                Update(typeOfAssetInput);
            }
        }

        public void DeleteTypeOfAsset(int id)
        {
            var typeOfAssetEntity = typeOfAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typeOfAssetEntity != null)
            {
                typeOfAssetEntity.IsDelete = true;
                typeOfAssetRepository.Update(typeOfAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TypeOfAssetInput GetTypeOfAssetForEdit(int id)
        {
            var typeOfAssetEntity = typeOfAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typeOfAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TypeOfAssetInput>(typeOfAssetEntity);
        }

        public TypeOfAssetForViewDto GetTypeOfAssetForView(int id)
        {
            var typeOfAssetEntity = typeOfAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typeOfAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TypeOfAssetForViewDto>(typeOfAssetEntity);
        }

        public PagedResultDto<TypeOfAssetDto> GetTypeOfAssets(TypeOfAssetFilter input)
        {
            var query = typeOfAssetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetType != null)
            {
                query = query.Where(x => x.AssetType.ToLower().Equals(input.AssetType));
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
            return new PagedResultDto<TypeOfAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TypeOfAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TypeOfAsset_Create)]
        private void Create(TypeOfAssetInput typeOfAssetInput)
        {
            var typeOfAssetEntity = ObjectMapper.Map<TypeOfAsset>(typeOfAssetInput);
            SetAuditInsert(typeOfAssetEntity);
            typeOfAssetRepository.Insert(typeOfAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TypeOfAsset_Edit)]
        private void Update(TypeOfAssetInput typeOfAssetInput)
        {
            var typeOfAssetEntity = typeOfAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == typeOfAssetInput.Id);
            if (typeOfAssetEntity == null)
            {
            }
            ObjectMapper.Map(typeOfAssetInput, typeOfAssetEntity);
            SetAuditEdit(typeOfAssetEntity);
            typeOfAssetRepository.Update(typeOfAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
