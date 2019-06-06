using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Asset11s
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class Asset11AppService : GWebsiteAppServiceBase, IAsset11AppService
    {
        private readonly IRepository<Asset11> asset11Repository;

        public Asset11AppService(IRepository<Asset11> asset11Repository)
        {
            this.asset11Repository = asset11Repository;
        }

        #region Public Method

        public void CreateOrEditAsset11(Asset11Input asset11Input)
        {
            if (asset11Input.Id == 0)
            {
                Create(asset11Input);
            }
            else
            {
                Update(asset11Input);
            }
        }

        public void DeleteAsset11(int id)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset11Entity != null)
            {
                asset11Entity.IsDelete = true;
                asset11Repository.Update(asset11Entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Asset11Input GetAsset11ForEdit(int id)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset11Input>(asset11Entity);
        }

        public Asset11ForViewDto GetAsset11ForView(int id)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset11ForViewDto>(asset11Entity);
        }

        public PagedResultDto<Asset11Dto> GetAsset11s(Asset11Filter input)
        {
            var query = asset11Repository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.IdAsset != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.IdAsset));
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
            return new PagedResultDto<Asset11Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Asset11Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11_Create)]
        private void Create(Asset11Input asset11Input)
        {
            var asset11Entity = ObjectMapper.Map<Asset11>(asset11Input);
            SetAuditInsert(asset11Entity);
            asset11Repository.Insert(asset11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11_Edit)]
        private void Update(Asset11Input asset11Input)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == asset11Input.Id);
            if (asset11Entity == null)
            {
            }
            ObjectMapper.Map(asset11Input, asset11Entity);
            SetAuditEdit(asset11Entity);
            asset11Repository.Update(asset11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
