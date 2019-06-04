using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetRentingContracts
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetRentingContract)]
    public class AssetRentingContractAppService : GWebsiteAppServiceBase, IAssetRentingContractAppService
    {
        private readonly IRepository<AssetRentingContract> assetRentingContractRepository;
        private readonly IRepository<AssetRentingFile> assetRentingFileRepository;

        public AssetRentingContractAppService(IRepository<AssetRentingContract> assetRentingContractRepository,
            IRepository<AssetRentingFile> assetRentingFileRepository)
        {
            this.assetRentingContractRepository = assetRentingContractRepository;
            this.assetRentingFileRepository = assetRentingFileRepository;
        }

        #region Public Method

        public void CreateOrEditAssetRentingContract(AssetRentingContractInput assetRentingContractInput)
        {
            if (assetRentingContractInput.Id == 0)
            {
                Create(assetRentingContractInput);
            }
            else
            {
                Update(assetRentingContractInput);
            }
        }

        public void DeleteAssetRentingContract(int id)
        {
            var assetRentingContractEntity = assetRentingContractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentingContractEntity != null)
            {
                assetRentingContractEntity.IsDelete = true;
                assetRentingContractRepository.Update(assetRentingContractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetRentingContractInput GetAssetRentingContractForEdit(int id)
        {
            var assetRentingContractEntity = assetRentingContractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentingContractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetRentingContractInput>(assetRentingContractEntity);
        }

        public AssetRentingContractForViewDto GetAssetRentingContractForView(int id)
        {
            var assetRentingContractEntity = assetRentingContractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentingContractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetRentingContractForViewDto>(assetRentingContractEntity);
        }

        public PagedResultDto<AssetRentingContractDto> GetAssetRentingContracts(AssetRentingContractFilter input)
        {
            var query = assetRentingContractRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.ContractName != null)
            {
                query = query.Where(x => x.ContractName.ToLower().Equals(input.ContractName));
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
            return new PagedResultDto<AssetRentingContractDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetRentingContractDto>(item)).ToList());
        }

        public async Task<AssetRentingFileOutput> GetAssetRentingFileComboboxForEditAsync(NullableIdDto input)
        {
            AssetRentingFile assetRentingFile = null;
            //if (input.Id.HasValue && input.Id.Value > 0)
            //{
            //    assetRentingFile = await assetRentingFileRepository.GetAsync(input.Id.Value);
            //}
            var output = new AssetRentingFileOutput
            {
                //AssetRentingFile = assetRentingFile != null
                //? ObjectMapper.Map<AssetRentingFileDto>(assetRentingFile)
                //: new AssetRentingFileDto(),

                AssetRentingFiles = await assetRentingFileRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.FileCode) {IsSelected = c.Id == input.Id })
                .ToListAsync()
            };

            return output;
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetRentingContract_Create)]
        private void Create(AssetRentingContractInput assetRentingContractInput)
        {
            var assetRentingContractEntity = ObjectMapper.Map<AssetRentingContract>(assetRentingContractInput);
            SetAuditInsert(assetRentingContractEntity);
            assetRentingContractRepository.Insert(assetRentingContractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetRentingContract_Edit)]
        private void Update(AssetRentingContractInput assetRentingContractInput)
        {
            var assetRentingContractEntity = assetRentingContractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetRentingContractInput.Id);
            if (assetRentingContractEntity == null)
            {
            }
            ObjectMapper.Map(assetRentingContractInput, assetRentingContractEntity);
            SetAuditEdit(assetRentingContractEntity);
            assetRentingContractRepository.Update(assetRentingContractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
