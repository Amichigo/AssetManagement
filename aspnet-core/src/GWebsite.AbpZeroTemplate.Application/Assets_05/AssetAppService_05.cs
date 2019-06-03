using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets_05
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]

    public class AssetAppService_05 : GWebsiteAppServiceBase, IAssetAppService_05
    {
        private readonly IRepository<Asset_05> assetRepository;
        private readonly IRepository<AssetGroup_05> assetGroupRepository;
        private readonly IRepository<AssetType_05> assetTypeRepository;

        public AssetAppService_05(IRepository<Asset_05> assetRepository, 
            IRepository<AssetGroup_05> assetGroupRepository, IRepository<AssetType_05> assetTypeRepository)
        {
            this.assetRepository = assetRepository;
            this.assetGroupRepository = assetGroupRepository;
            this.assetTypeRepository = assetTypeRepository;
        }

        #region Public Method

        public void CreateOrEditAsset(AssetDto_05 assetInput)
        {
            if (assetInput.Id == 0)
            {
                Create(assetInput);
            }
            else
            {
                Update(assetInput);
            }
        }

        public void DeleteAsset(string id)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == id);
            if (assetEntity != null)
            {
                assetEntity.IsDelete = true;
                assetRepository.Update(assetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetDto_05 GetAssetForEdit(string id)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetDto_05>(assetEntity);
        }

        public AssetForViewDto_05 GetAssetForView(string id)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetForViewDto_05>(assetEntity);
        }

        public AssetOutput_05 GetAssetEdit(string id)
        {
            Asset_05 asset = null;
            var output = new AssetOutput_05();
            var selectedAssetId = 1;
            var selectedAssetGroupId = "";

            asset = assetRepository.GetAll()
                                   .Where(x => !x.IsDelete)
                                   .SingleOrDefault(x => x.AssetId == id);

            if(asset != null)
            {
                output.Asset = ObjectMapper.Map<AssetDto_05>(asset);
                selectedAssetId = asset.AssetTypeId;
                selectedAssetGroupId = asset.AssetGroupId;
            }
            else
            {
                output.Asset = new AssetDto_05();
            }
            

            output.AssetGroups = assetGroupRepository.GetAll()
                .Where(x => !x.IsDelete)
                .Select(c => new ComboboxItemDto(c.AssetGroupId, c.Name)
                { IsSelected = selectedAssetGroupId == c.AssetGroupId })
                .ToList();

            output.AssetTypes = assetTypeRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name)
                { IsSelected = selectedAssetId == c.Id })
                .ToList();
            return output;
        }

        public PagedResultDto<AssetDto_05> GetAssets(AssetFilter_05 input)
        {
            var query = assetRepository.GetAll().Where(x => !x.IsDelete);

            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            }

            var totalCount = query.Count();

            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            var items = query.PageBy(input).ToList();

            return new PagedResultDto<AssetDto_05>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetDto_05>(item)).ToList());
        }
        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]

        private void Create(AssetDto_05 assetInput)
        {
            CreateIdAuto(assetInput);
            var assetEntity = ObjectMapper.Map<Asset_05>(assetInput);
            assetRepository.Insert(assetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]

        private void Update(AssetDto_05 assetInput)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == assetInput.AssetId);
            if (assetEntity != null)
            {
                ObjectMapper.Map(assetInput, assetEntity);
                assetRepository.Update(assetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private void CreateIdAuto(AssetDto_05 assetInput)
        {
            int count = assetRepository.GetAll().Count();
            string tempID = "";
            string AssetID = "";

            count += 1;

            if (assetInput.AssetTypeId == 1)
            {
                AssetID += "T";
            }
            else
            {
                AssetID += "C";
            }

            tempID = count.ToString();

            while (tempID.Length < 6)
            {
                tempID = "0" + tempID;
            }

            assetInput.AssetId = AssetID + assetInput.AssetGroupId
                                                     .Substring(3) 
                                                     + tempID;
        }

        #endregion
    }
}
