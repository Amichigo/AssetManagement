using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.RentalAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RentalAssetAppService : GWebsiteAppServiceBase, IRentalAssetAppService
    {
        private readonly IRepository<RentalAsset> rentalAssetRepository;
        private readonly IRepository<TypeOfRentalAsset> typeOfRentalAssetRepository;

        public RentalAssetAppService(IRepository<RentalAsset> rentalAssetRepository,
            IRepository<TypeOfRentalAsset> typeOfRentalAssetRepository)
        {
            this.rentalAssetRepository = rentalAssetRepository;
            this.typeOfRentalAssetRepository = typeOfRentalAssetRepository;
        }

        #region Public Method

        public void CreateOrEditRentalAsset(RentalAssetInput rentalAssetInput)
        {
            if (rentalAssetInput.Id == 0)
            {
                Create(rentalAssetInput);
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

            // filter by value
            if (input.AssetName != null)
            {
                query = query.Where(x => x.AssetName.ToLower().Equals(input.AssetName));
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
            return new PagedResultDto<RentalAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RentalAssetDto>(item)).ToList());
        }

        public async Task<TypeOfRentalAssetOutput> GetTypeOfRentalAssetComboboxForEditAsync(NullableIdDto input)
        {
            TypeOfRentalAsset typeOfRentalAsset = null;
            //if (input.Id.HasValue && input.Id.Value > 0)
            //{
            //    typeOfRentalAsset = await typeOfRentalAssetRepository.GetAsync(input.Id.Value);
            //}
            var output = new TypeOfRentalAssetOutput
            {
                //TypeOfRentalAsset = typeOfRentalAsset != null
                //? ObjectMapper.Map<TypeOfRentalAssetDto>(typeOfRentalAsset)
                //: new TypeOfRentalAssetDto(),

                TypeOfRentalAssets = await typeOfRentalAssetRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.TypeOfAsset) {IsSelected = c.Id == input.Id })
                .ToListAsync()
            };

            return output;
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RentalAssetInput rentalAssetInput)
        {
            var rentalAssetEntity = ObjectMapper.Map<RentalAsset>(rentalAssetInput);
            SetAuditInsert(rentalAssetEntity);
            rentalAssetRepository.Insert(rentalAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RentalAssetInput rentalAssetInput)
        {
            var rentalAssetEntity = rentalAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == rentalAssetInput.Id);
            if (rentalAssetEntity == null)
            {
            }
            ObjectMapper.Map(rentalAssetInput, rentalAssetEntity);
            SetAuditEdit(rentalAssetEntity);
            rentalAssetRepository.Update(rentalAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
