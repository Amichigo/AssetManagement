using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetGroups
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup)]
    public class AssetGroupAppService : GWebsiteAppServiceBase, IAssetGroupAppService
    {
        private readonly IRepository<AssetGroup> assetGroupRepository;
        private readonly IRepository<TypeOfAsset> typeOfAssetRepository;

        public AssetGroupAppService(IRepository<AssetGroup> assetGroupRepository,
            IRepository<TypeOfAsset> typeOfAssetRepository)
        {
            this.assetGroupRepository = assetGroupRepository;
            this.typeOfAssetRepository = typeOfAssetRepository;
        }

        #region Public Method

        public void CreateOrEditAssetGroup(AssetGroupInput assetGroupInput)
        {
            if (assetGroupInput.Id == 0)
            {
                Create(assetGroupInput);
            }
            else
            {
                Update(assetGroupInput);
            }
        }

        public void DeleteAssetGroup(int id)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetGroupEntity != null)
            {
                assetGroupEntity.IsDelete = true;
                assetGroupRepository.Update(assetGroupEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetGroupInput GetAssetGroupForEdit(int id)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetGroupEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetGroupInput>(assetGroupEntity);
        }

        public AssetGroupForViewDto GetAssetGroupForView(int id)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetGroupEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetGroupForViewDto>(assetGroupEntity);
        }

        public PagedResultDto<AssetGroupDto> GetAssetGroups(AssetGroupFilter input)
        {
            var query = assetGroupRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
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
            return new PagedResultDto<AssetGroupDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetGroupDto>(item)).ToList());
        }

        public AssetGroupOutput GetAssetGroupsById(string assetTypeId)
        {
            AssetGroupOutput output = new AssetGroupOutput()
            {
                AssetGroups = assetGroupRepository
                .GetAll()
                .Where(assetGroup => assetGroup.AssetType == assetTypeId)
                .Select(item => new ComboboxItemDto { Value = item.Id.ToString(), DisplayText = item.AssetGroupName })
                .ToList()
            };
            return output;
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

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_Create)]
        private void Create(AssetGroupInput assetGroupInput)
        {
            int nextID = assetGroupRepository.GetAll().Count() + 1;
            assetGroupInput.AssetGroupCode = "NTS000" + nextID;
            var assetGroupEntity = ObjectMapper.Map<AssetGroup>(assetGroupInput);
            SetAuditInsert(assetGroupEntity);
            assetGroupRepository.Insert(assetGroupEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_Edit)]
        private void Update(AssetGroupInput assetGroupInput)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetGroupInput.Id);
            if (assetGroupEntity == null)
            {
            }
            ObjectMapper.Map(assetGroupInput, assetGroupEntity);
            SetAuditEdit(assetGroupEntity);
            assetGroupRepository.Update(assetGroupEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
