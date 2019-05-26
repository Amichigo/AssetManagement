//using Abp.Application.Services.Dto;
//using Abp.Authorization;
//using Abp.Domain.Repositories;
//using Abp.Linq.Extensions;
//using GWebsite.AbpZeroTemplate.Application;
//using GWebsite.AbpZeroTemplate.Application.Share.AssetDetails_05.Dto;
//using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
//using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
//using GWebsite.AbpZeroTemplate.Application.Share.Customers;
//using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
//using GWebsite.AbpZeroTemplate.Core.Authorization;
//using GWebsite.AbpZeroTemplate.Core.Models;
//using System.Linq;
//using System.Linq.Dynamic.Core;

//namespace GWebsite.AbpZeroTemplate.Web.Core.Assets_05
//{

//    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
//    public class AssetAppService_05 : GWebsiteAppServiceBase, IAssetAppService_05
//    {
//        private Asset_05 assetRepository;

//        public AssetAppService_05(IRepository<Asset_05, string> assetRepository)
//        {
//            this.assetRepository = assetRepository;
//        }

//        #region Public Method

//        public void CreateOrEditAsset(AssetInput_05 assetInput, AssetTypeInput_05 assetType,
//            AssetGroupFilter_05 assetGroup, AssetDetailInput_05 assetDetailInput)
//        {
//            if (assetInput.Id == null)
//            {
//                Create(assetInput);
//            }
//            else
//            {
//                Update(assetInput);
//            }
//        }

//        public void DeleteAsset(string id)
//        {
//            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
//            if (assetEntity != null)
//            {
//                assetEntity.IsDelete = true;
//                assetRepository.Update(assetEntity);
//                CurrentUnitOfWork.SaveChanges();
//            }
//        }

//        public AssetInput_05 GetAssetForEdit(string id)
//        {
//            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
//            if (assetEntity == null)
//            {
//                return null;
//            }
//            return ObjectMapper.Map<AssetInput_05>(assetEntity);
//        }

//        public AssetForViewDto_05 GetAssetForView(string id)
//        {
//            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
//            if (assetEntity == null)
//            {
//                return null;
//            }
//            return ObjectMapper.Map<AssetForViewDto_05>(assetEntity);
//        }

//        public PagedResultDto<AssetDto_05> GetAssets(AssetFilter_05 input, AssetTypeFilter_05 assetType,
//            AssetGroupFilter_05 assetGroup, AssetDetailFilter_05 assetDetailInput)
//        {
//            var query = assetRepository.GetAll().Where(x => !x.IsDelete);

//            // filter by value
//            if (input.Name != null)
//            {
//                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
//            }

//            var totalCount = query.Count();

//            // sorting
//            if (!string.IsNullOrWhiteSpace(input.Sorting))
//            {
//                query = query.OrderBy(input.Sorting);
//            }

//            // paging
//            var items = query.PageBy(input).ToList();

//            // result
//            return new PagedResultDto<AssetDto_05>(
//                totalCount,
//                items.Select(item => ObjectMapper.Map<AssetDto_05>(item)).ToList());
//        }

//        #endregion

//        #region Private Method

//        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
//        private void Create(AssetInput_05 assetInput)
//        {
//            var assetEntity = ObjectMapper.Map<Asset_05>(assetInput);
//            assetRepository.Insert(assetEntity);
//            CurrentUnitOfWork.SaveChanges();
//        }

//        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
//        private void Update(AssetInput_05 assetInput)
//        {
//            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetInput.Id);
//            if (assetEntity == null)
//            {
//            }
//            ObjectMapper.Map(assetInput, assetEntity);
//            assetRepository.Update(assetEntity);
//            CurrentUnitOfWork.SaveChanges();
//        }

//        #endregion
//    }
//}
