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
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Building9)]
    public class BuildingAppService : GWebsiteAppServiceBase, IBuildingAppService
    {
        private readonly IRepository<Building_9> BuildingRepository;

        public BuildingAppService(IRepository<Building_9> BuildingRepository)
        {
            this.BuildingRepository = BuildingRepository;
        }

        #region Public Method

        public void CreateOrEditBuilding(BuildingInput_9 BuildingInput)
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

        public BuildingInput_9 GetBuildingForEdit(int id)
        {
            var BuildingEntity = BuildingRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BuildingEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BuildingInput_9>(BuildingEntity);
        }

        public BuildingForViewDto_9 GetBuildingForView(int id)
        {
            var BuildingEntity = BuildingRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BuildingEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BuildingForViewDto_9>(BuildingEntity);
        }

        public PagedResultDto<BuildingDto_9> GetBuildings(BuildingFilter_9 input)
        {
            var query = BuildingRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.SoTang != null)
            {
                query = query.Where(x => x.SoTang.ToLower().Equals(input.SoTang));
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
            return new PagedResultDto<BuildingDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BuildingDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Building9_Create)]
        private void Create(BuildingInput_9 BuildingInput)
        {
            var BuildingEntity = ObjectMapper.Map<Building_9>(BuildingInput);
            SetAuditInsert(BuildingEntity);
            BuildingRepository.Insert(BuildingEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Building9_Edit)]
        private void Update(BuildingInput_9 BuildingInput)
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
