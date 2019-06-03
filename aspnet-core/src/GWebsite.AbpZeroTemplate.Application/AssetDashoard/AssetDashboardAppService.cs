using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Auditing;
using Abp.Timing;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetDashboard
{
    [DisableAuditing]
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetDashboard)]
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixedAsset)]
    public class AssetDashboardAppService: GWebsiteAppServiceBase, IAssetDashboardAppService
    {
        private readonly IRepository<FixedAsset> assetDashboardRepository;
        private readonly IAssetStatisticsService assetStatisticsService;

        public AssetDashboardAppService(IRepository<FixedAsset> assetDashboardRepository,
             IAssetStatisticsService assetStatisticsService)
        {
            this.assetDashboardRepository = assetDashboardRepository;
            this.assetStatisticsService = assetStatisticsService;
        }

        public async Task<AssetDashboardDataOutput> GetAssetDashboardData(AssetDashboardDataInput input)
        {
            return new AssetDashboardDataOutput
            {
                //line-chart
                AssetTotalNumberStatistics = await assetStatisticsService.GetAssetTotalNumberStatisticsData(input.AssetDashboardDateInterval, input.StartDate, input.EndDate),
                //pie-chart
                AssetStatusStatistics = await GetAssetStatusStatisticsData(input.StartDate, input.EndDate),
                //add more card to dashboard
            };
        }
        public async Task<AssetTotalNumberStatisticsDataOutput> GetAssetTotalNumberStatistics(AssetTotalNumberStatisticsDataInput input)
        {
            return new AssetTotalNumberStatisticsDataOutput(await assetStatisticsService.GetAssetTotalNumberStatisticsData(input.AssetStatisticsDateInterval, input.StartDate, input.EndDate));
        }
        private async Task<List<AssetStatusStatistic>> GetAssetStatusStatisticsData (DateTime startDate, DateTime endDate)
        {
            return await assetDashboardRepository.GetAll()
                .Where(t => t.PurchaseDate >= startDate &&
                            t.PurchaseDate <= endDate)
                .GroupBy(t => t.Categocy)
                .Select(t => new AssetStatusStatistic
                {
                    Label = t.Key,
                    Value = t.Count()
                })
                .OrderBy(t => t.Label)
                .ToListAsync();
        }

    }
}



