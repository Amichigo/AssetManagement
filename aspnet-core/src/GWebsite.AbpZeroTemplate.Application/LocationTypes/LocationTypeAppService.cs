using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.LocationTypes;
using GWebsite.AbpZeroTemplate.Application.Share.LocationTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.LocationTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class LocationTypeAppService : GWebsiteAppServiceBase, ILocationTypeAppService
    {
        private readonly IRepository<LocationType_9> LocationTypeRepository;

        public LocationTypeAppService(IRepository<LocationType_9> LocationTypeRepository)
        {
            this.LocationTypeRepository = LocationTypeRepository;
        }

        #region Public Method

        public void CreateOrEditLocationType(LocationTypeInput_9 LocationTypeInput)
        {
            if (LocationTypeInput.Id == 0)
            {
                Create(LocationTypeInput);
            }
            else
            {
                Update(LocationTypeInput);
            }
        }

        public void DeleteLocationType(int id)
        {
            var LocationTypeEntity = LocationTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LocationTypeEntity != null)
            {
                LocationTypeEntity.IsDelete = true;
                LocationTypeRepository.Update(LocationTypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LocationTypeInput_9 GetLocationTypeForEdit(int id)
        {
            var LocationTypeEntity = LocationTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LocationTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LocationTypeInput_9>(LocationTypeEntity);
        }

        public LocationTypeForViewDto_9 GetLocationTypeForView(int id)
        {
            var LocationTypeEntity = LocationTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LocationTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LocationTypeForViewDto_9>(LocationTypeEntity);
        }

        public PagedResultDto<LocationTypeDto_9> GetLocationTypes(LocationTypeFilter_9 input)
        {
            var query = LocationTypeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaDiaDiem != null)
            {
                query = query.Where(x => x.MaDiaDiem.ToLower().Equals(input.MaDiaDiem));
            }
            if (input.TenDiaDiem != null)
            {
                query = query.Where(x => x.TenDiaDiem.ToLower().Equals(input.TenDiaDiem));
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
            return new PagedResultDto<LocationTypeDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LocationTypeDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(LocationTypeInput_9 LocationTypeInput)
        {
            var LocationTypeEntity = ObjectMapper.Map<LocationType_9>(LocationTypeInput);
            SetAuditInsert(LocationTypeEntity);
            LocationTypeRepository.Insert(LocationTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(LocationTypeInput_9 LocationTypeInput)
        {
            var LocationTypeEntity = LocationTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == LocationTypeInput.Id);
            if (LocationTypeEntity == null)
            {
            }
            ObjectMapper.Map(LocationTypeInput, LocationTypeEntity);
            SetAuditEdit(LocationTypeEntity);
            LocationTypeRepository.Update(LocationTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
