using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Buildings
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class BuildingAppService : GWebsiteAppServiceBase, IBuildingAppService
    {
        private readonly IRepository<Building> BuildingRepository;

        public BuildingAppService(IRepository<Building> BuildingRepository)
        {
            this.BuildingRepository = BuildingRepository;
        }

        #region Public Method

        public void CreateOrEditBuilding(BuildingInput BuildingInput)
        {
            if (BuildingInput.Id == 0)
            {
                Create(BuildingInput);
            }
            else
            {
                Update(BuildingInput);
            }
        }

        public void DeleteBuilding(int id)
        {
            var BuildingEntity = BuildingRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BuildingEntity != null)
            {
                BuildingEntity.IsDelete = true;
                BuildingRepository.Update(BuildingEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BuildingInput GetBuildingForEdit(int id)
        {
            var BuildingEntity = BuildingRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BuildingEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BuildingInput>(BuildingEntity);
        }

        public BuildingForViewDto GetBuildingForView(int id)
        {
            var BuildingEntity = BuildingRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BuildingEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BuildingForViewDto>(BuildingEntity);
        }

        public PagedResultDto<BuildingDto> GetBuildings(BuildingFilter input)
        {
            var query = BuildingRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            //if (input. != null)
            //{
            //    query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            //}

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<BuildingDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BuildingDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(BuildingInput BuildingInput)
        {
            var BuildingEntity = ObjectMapper.Map<Building>(BuildingInput);
            SetAuditInsert(BuildingEntity);
            BuildingRepository.Insert(BuildingEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(BuildingInput BuildingInput)
        {
            var BuildingEntity = BuildingRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == BuildingInput.Id);
            if (BuildingEntity == null)
            {
            }
            ObjectMapper.Map(BuildingInput, BuildingEntity);
            SetAuditEdit(BuildingEntity);
            BuildingRepository.Update(BuildingEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
