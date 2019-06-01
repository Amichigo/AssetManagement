using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetRentingFiles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class AssetRentingFileAppService : GWebsiteAppServiceBase, IAssetRentingFileAppService
    {
        private readonly IRepository<AssetRentingFile> assetRentingFileRepository;
        private readonly IRepository<RentalAsset> rentalAssetRepository;
        private readonly IRepository<FormOfRentingAsset> formOfRentingAssetRepository;

        public AssetRentingFileAppService(IRepository<AssetRentingFile> assetRentingFileRepository,
            IRepository<RentalAsset> rentalAssetRepository, IRepository<FormOfRentingAsset> formOfRentingAssetRepository)
        {
            this.assetRentingFileRepository = assetRentingFileRepository;
            this.rentalAssetRepository = rentalAssetRepository;
            this.formOfRentingAssetRepository = formOfRentingAssetRepository;
        }

        #region Public Method

        public void CreateOrEditAssetRentingFile(AssetRentingFileInput assetRentingFileInput)
        {
            if (assetRentingFileInput.Id == 0)
            {
                Create(assetRentingFileInput);
            }
            else
            {
                Update(assetRentingFileInput);
            }
        }

        public void DeleteAssetRentingFile(int id)
        {
            var assetRentingFileEntity = assetRentingFileRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentingFileEntity != null)
            {
                assetRentingFileEntity.IsDelete = true;
                assetRentingFileRepository.Update(assetRentingFileEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetRentingFileInput GetAssetRentingFileForEdit(int id)
        {
            var assetRentingFileEntity = assetRentingFileRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentingFileEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetRentingFileInput>(assetRentingFileEntity);
        }

        public AssetRentingFileForViewDto GetAssetRentingFileForView(int id)
        {
            var assetRentingFileEntity = assetRentingFileRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentingFileEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetRentingFileForViewDto>(assetRentingFileEntity);
        }

        public PagedResultDto<AssetRentingFileDto> GetAssetRentingFiles(AssetRentingFileFilter input)
        {
            var query = assetRentingFileRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.FileName != null)
            {
                query = query.Where(x => x.FileName.ToLower().Equals(input.FileName));
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
            return new PagedResultDto<AssetRentingFileDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetRentingFileDto>(item)).ToList());
        }

        public async Task<RentalAssetOutput> GetRentalAssetComboboxForEditAsync(NullableIdDto input)
        {
            RentalAsset rentalAsset = null;
            //if (input.Id.HasValue && input.Id.Value > 0)
            //{
            //    rentalAsset = await rentalAssetRepository.GetAsync(input.Id.Value);
            //}
            var output = new RentalAssetOutput
            {
                //RentalAsset = rentalAsset != null
                //? ObjectMapper.Map<RentalAssetDto>(rentalAsset)
                //: new RentalAssetDto(),

                RentalAssets = await rentalAssetRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.AssetCode) {IsSelected = c.Id == input.Id })
                .ToListAsync()
            };

            return output;
        }

        public async Task<FormOfRentingAssetOutput> GetFormOfRentingAssetComboboxForEditAsync(NullableIdDto input)
        {
            FormOfRentingAsset formOfRentingAsset = null;
            //if (input.Id.HasValue && input.Id.Value > 0)
            //{
            //    rentalAsset = await rentalAssetRepository.GetAsync(input.Id.Value);
            //}
            var output = new FormOfRentingAssetOutput
            {
                //RentalAsset = rentalAsset != null
                //? ObjectMapper.Map<RentalAssetDto>(rentalAsset)
                //: new RentalAssetDto(),

                FormOfRentingAssets = await formOfRentingAssetRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.FormOfRenting) {IsSelected = c.Id == input.Id })
                .ToListAsync()
            };

            return output;
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(AssetRentingFileInput assetRentingFileInput)
        {
            var assetRentingFileEntity = ObjectMapper.Map<AssetRentingFile>(assetRentingFileInput);
            SetAuditInsert(assetRentingFileEntity);
            assetRentingFileRepository.Insert(assetRentingFileEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(AssetRentingFileInput assetRentingFileInput)
        {
            var assetRentingFileEntity = assetRentingFileRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetRentingFileInput.Id);
            if (assetRentingFileEntity == null)
            {
            }
            ObjectMapper.Map(assetRentingFileInput, assetRentingFileEntity);
            SetAuditEdit(assetRentingFileEntity);
            assetRentingFileRepository.Update(assetRentingFileEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
