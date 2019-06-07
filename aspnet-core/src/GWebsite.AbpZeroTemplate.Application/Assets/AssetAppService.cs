using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset)]
    public class AssetAppService : GWebsiteAppServiceBase, IAssetAppService
    {
        private readonly IRepository<Asset> assetRepository;
        private readonly IRepository<TypeOfAsset> typeOfAssetRepository;
        private readonly IRepository<AssetGroup> assetGroupRepository;

        public AssetAppService(IRepository<Asset> assetRepository,
            IRepository<TypeOfAsset> typeOfAssetRepository, IRepository<AssetGroup> assetGroupRepository)
        {
            this.assetRepository = assetRepository;
            this.typeOfAssetRepository = typeOfAssetRepository;
            this.assetGroupRepository = assetGroupRepository;
        }

        #region Public Method

        public void CreateOrEditAsset(AssetInput assetInput)
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

        public void DeleteAsset(int id)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetEntity != null)
            {
                assetEntity.IsDelete = true;
                assetRepository.Update(assetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetInput GetAssetForEdit(int id)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetInput>(assetEntity);
        }

        public AssetForViewDto GetAssetForView(int id)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetForViewDto>(assetEntity);
        }

        public PagedResultDto<AssetDto> GetAssets(AssetFilter input)
        {
            var query = assetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetName != null)
            {
                query = query.Where(x => x.AssetName.ToLower().Equals(input.AssetName));
            }
            if (input.AssetCode != null)
            {
                query = query.Where(x => x.AssetCode.ToLower().Equals(input.AssetCode));
            }
            if (input.AssetType != null)
            {
                query = query.Where(x => x.AssetType.ToLower().Equals(input.AssetType));
            }
            if (input.AssetGroupName != null)
            {
                query = query.Where(x => x.AssetGroupName.ToLower().Equals(input.AssetGroupName));
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
            return new PagedResultDto<AssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetDto>(item)).ToList());
        }

        public async Task<TypeOfAssetOutput> GetTypeOfAssetComboboxForEditAsync(NullableIdDto input)
        {
            TypeOfAsset typeOfAsset = null;
            //if (input.Id.HasValue && input.Id.Value > 0)
            //{
            //    typeOfAsset = await typeOfAssetRepository.GetAsync(input.Id.Value);
            //}
            var output = new TypeOfAssetOutput
            {
                //TypeOfAsset = typeOfAsset != null
                //? ObjectMapper.Map<TypeOfAssetDto>(typeOfAsset)
                //: new TypeOfAssetDto(),

                TypeOfAssets = await typeOfAssetRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.AssetType) {IsSelected = c.Id == input.Id })
                .ToListAsync()
            };

            return output;
        }

        public async Task<AssetGroupOutput> GetAssetGroupComboboxForEditAsync(NullableIdDto input)
        {
            AssetGroup assetGroup = null;
            //if (input.Id.HasValue && input.Id.Value > 0)
            //{
            //    typeOfAsset = await typeOfAssetRepository.GetAsync(input.Id.Value);
            //}
            var output = new AssetGroupOutput
            {
                //TypeOfAsset = typeOfAsset != null
                //? ObjectMapper.Map<TypeOfAssetDto>(typeOfAsset)
                //: new TypeOfAssetDto(),

                AssetGroups = await assetGroupRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.AssetGroupName) {IsSelected = c.Id == input.Id })
                .ToListAsync()
            };

            return output;
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_Create)]
        private void Create(AssetInput assetInput)
        {
            int nextID = assetRepository.GetAll().Count() + 1;
            assetInput.AssetCode = "TS000" + nextID;
            var assetEntity = ObjectMapper.Map<Asset>(assetInput);
            SetAuditInsert(assetEntity);
            assetRepository.Insert(assetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_Edit)]
        private void Update(AssetInput assetInput)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetInput.Id);
            if (assetEntity == null)
            {
            }
            ObjectMapper.Map(assetInput, assetEntity);
            SetAuditEdit(assetEntity);
            assetRepository.Update(assetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
