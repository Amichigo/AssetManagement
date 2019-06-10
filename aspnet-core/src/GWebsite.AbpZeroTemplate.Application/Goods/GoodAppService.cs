using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Goods;
using GWebsite.AbpZeroTemplate.Application.Share.Goods.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.Goods
{
    public class GoodAppService : GWebsiteAppServiceBase, IGoodAppService
    {
        private readonly IRepository<Good> GoodRepository;

        public GoodAppService(IRepository<Good> GoodRepository)
        {
            this.GoodRepository = GoodRepository;
        }

        #region Public Method

        public PagedResultDto<GoodDto> GetGoods(GoodFilter input)
        {
            var query = GoodRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaSP != null)
            {
                query = query.Where(x => x.MaSP.ToLower().Equals(input.MaSP));
            }

            if (input.TenSP != null)
            {
                query = query.Where(x => x.TenSP.ToLower().Equals(input.TenSP));
            }

            if (input.Gia != null)
            {
                query = query.Where(x => x.Gia.ToLower().Equals(input.Gia));
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
            return new PagedResultDto<GoodDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<GoodDto>(item)).ToList());
        }

        #endregion
    }
}
