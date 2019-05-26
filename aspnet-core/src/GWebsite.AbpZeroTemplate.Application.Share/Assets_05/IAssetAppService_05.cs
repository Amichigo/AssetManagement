using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDetails_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Customers
{
    public interface IAssetAppService_05
    {
        Task<ListResultDto<AssetGroupDto_05>> GetGrsAsync();

        Task<PagedResultDto<MenuClientListDto>> GetMenuClientsAsync(GetMenuClientInput input);//for filter

        Task<GetMenuClientOutput> GetMenuClientForEditAsync(NullableIdDto input);

        Task<MenuClientDto> CreateMenuClientAsync(CreateMenuClientInput input);

        Task<MenuClientDto> UpdateMenuClientAsync(UpdateMenuClientInput input);

        Task DeleteMenuClientAsync(EntityDto<int> input);
    }
}