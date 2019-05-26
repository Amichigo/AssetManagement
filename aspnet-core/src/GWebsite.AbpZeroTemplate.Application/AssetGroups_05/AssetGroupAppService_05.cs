using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetGroups_05
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_05)]
    public class AssetGroupAppService_05 : GWebsiteAppServiceBase, IAssetGroupAppService_05
    {
        private readonly IRepository<AssetGroup_05> assetGroupRepository;

        public AssetGroupAppService_05(IRepository<AssetGroup_05> assetGroupRepository)
        {
            this.assetGroupRepository = assetGroupRepository;
        }

        #region Public Method
        public void CreateOrEditAssetGroup(AssetGroupInput_05 assetGroupInput)
        {
            
                if (assetGroupInput.Id == null)
                {
                    Create(assetGroupInput);
                }
                else
                {
                    Update(assetGroupInput);
                }

        }

        public void DeleteAssetGroup(string idAssetGroup)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == idAssetGroup);
            if (assetGroupEntity != null)
            {
                assetGroupEntity.IsDelete = true;
                assetGroupRepository.Update(assetGroupEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetGroupOutput_05 GetAssetGroupForEdit(string idAssetGroup)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == idAssetGroup);
            if (assetGroupEntity == null)
            {
                return null;
            }
            AssetGroup_05 assetGroup = null;

            var output = new AssetGroupOutput_05();

            output.AssetGroup = assetGroup != null
                ? ObjectMapper.Map<AssetGroupDto_05>(assetGroup)
                : new AssetGroupDto_05();//kiem tra neu ton tai thi map else tao moi

            var parentId = output.AssetGroup.Id ?? null;//Do du lieu name vai combobox
            output.AssetGroups = assetGroupRepository.GetAll()
                .Where(x => !x.IsDelete)
                .Select(c => new ComboboxItemDto(c.Level.ToString(), c.Name) { IsSelected = parentId == c.Id })
                .ToList();
            return output;
        }

        public AssetGroupForViewDto_05 GetAssetGroupForView(string idAssetGroup)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == idAssetGroup);
            if (assetGroupEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetGroupForViewDto_05>(assetGroupEntity);
        }

        public PagedResultDto<AssetGroupDto_05> GetAssetGroups(AssetGroupFilter_05 input)
        {
            var query = assetGroupRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(sorting => input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<AssetGroupDto_05>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetGroupDto_05>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_05_Create)]
        private void Create(AssetGroupInput_05 assetGroupInput)
        {
            var assetGroupEntity = ObjectMapper.Map<AssetGroup_05>(assetGroupInput);

            assetGroupRepository.Insert(assetGroupEntity);

            assetGroupEntity.CreatedDate = DateTime.Now;
            assetGroupEntity.CreatedBy = GetCurrentUser().Name;
            assetGroupEntity.IsDelete = false;
           
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_05_Edit)]
        private void Update(AssetGroupInput_05 assetGroupInput)
        {
            var assetGroupEntity = assetGroupRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetGroupInput.Id);
            if (assetGroupEntity != null)
            {
                ObjectMapper.Map(assetGroupInput, assetGroupEntity);
                assetGroupEntity.UpdatedDate = DateTime.Now;
                assetGroupEntity.UpdatedBy = GetCurrentUser().Name;
                assetGroupRepository.Update(assetGroupEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }
        #endregion
    }
}
