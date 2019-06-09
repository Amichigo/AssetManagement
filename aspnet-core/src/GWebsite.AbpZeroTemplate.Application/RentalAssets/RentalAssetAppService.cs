using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.RentalAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_RentalAsset)]
    public class RentalAssetAppService : GWebsiteAppServiceBase, IRentalAssetAppService
    {
        private readonly IRepository<RentalAsset> rentalAssetRepository;
        private readonly IRepository<Asset> assetRepos;
        public RentalAssetAppService(IRepository<RentalAsset> rentalAssetRepository, IRepository<Asset> assetRepos)
        {
            this.rentalAssetRepository = rentalAssetRepository;
            this.assetRepos = assetRepos;
        }

        #region Public Method

        public void CreateOrEditRentalAsset(RentalAssetInput rentalAssetInput,int idAsset)
        {
            if (rentalAssetInput.Id == 0)
            {
                int nextID = rentalAssetRepository.GetAll().Count() + 1;
                rentalAssetInput.RentalAssetCode = "TSCT000" + nextID;
                Create(rentalAssetInput);
                UpdateAsset(idAsset, rentalAssetInput.RentalAssetCode);
            }
            else
            {
                Update(rentalAssetInput);
            }
        }

        public void DeleteRentalAsset(int id)
        {
            var rentalAssetEntity = rentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (rentalAssetEntity != null)
            {
                rentalAssetEntity.IsDelete = true;
                rentalAssetRepository.Update(rentalAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RentalAssetInput GetRentalAssetForEdit(int id)
        {
            var rentalAssetEntity = rentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (rentalAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RentalAssetInput>(rentalAssetEntity);
        }

        public RentalAssetForViewDto GetRentalAssetForView(int id)
        {
            var rentalAssetEntity = rentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (rentalAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RentalAssetForViewDto>(rentalAssetEntity);
        }

        public PagedResultDto<RentalAssetDto> GetRentalAssets(RentalAssetFilter input)
        {
            var query = rentalAssetRepository.GetAll().Where(x => !x.IsDelete);
            var assetquery = assetRepos.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.RentalAssetCode != null)
            {
                query = query.Where(x => x.RentalAssetCode.ToLower().Equals(input.RentalAssetCode));
            }


            // filter by maTaisan
            if (input.AssetCode != null)
            {
                query = query.Where(x => x.AssetCode.ToLower().Equals(input.AssetCode));
            }




            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input);

           

            var jointTable = from i in items
                             join t in assetquery
                             on i.AssetCode equals t.AssetCode
                             select new RentalAssetDto
                             {
                                 RentalAssetCode = i.RentalAssetCode,
                                 AssetCode = i.AssetCode,
                                 DepreciationValue = i.DepreciationValue,
                                 DepreciationRate = i.DepreciationRate,
                                 RentalValue = i.DepreciationRate,
                                 Note = i.Note,
                                 AssetName = t.AssetName,
                                 AssetType = t.AssetType,
                                 AssetGroupName = t.AssetGroupName,
                                 AssetStatus = t.AssetStatus,
                                 AssetValue = t.AssetValue,
                                 LinkofImage = t.LinkofImage,
                                 Id = i.Id,
                             };



            var list = jointTable.PageBy(input).ToList();

            // result
            return new PagedResultDto<RentalAssetDto>(
                totalCount,
                jointTable.ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RentalAsset_Create)]
        private void Create(RentalAssetInput rentalAssetInput)
        {
           
            var rentalAssetEntity = ObjectMapper.Map<RentalAsset>(rentalAssetInput);
            SetAuditInsert(rentalAssetEntity);
            rentalAssetRepository.Insert(rentalAssetEntity);
          //  CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RentalAsset_Edit)]
        private void Update(RentalAssetInput rentalAssetInput)
        {
            var rentalAssetEntity = rentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == rentalAssetInput.Id);

            ObjectMapper.Map(rentalAssetEntity, rentalAssetInput);
            SetAuditEdit(rentalAssetEntity);
            rentalAssetRepository.Update(rentalAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }
        private void UpdateAsset(int idAsset,string rAssetCode)
        {
            
            var assetEntity = assetRepos.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == idAsset);
            if (assetEntity == null)
            {
                return;
            }
            assetEntity.RentalAssetCode = rAssetCode;
           // SetAuditEdit(assetEntity);
            assetRepos.Update(assetEntity);
            CurrentUnitOfWork.SaveChanges();
        }
        #endregion
    }
}
