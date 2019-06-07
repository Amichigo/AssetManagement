using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;


using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Applications
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<MenuClient, MenuClientDto>();
            configuration.CreateMap<MenuClient, MenuClientListDto>();
            configuration.CreateMap<CreateMenuClientInput, MenuClient>();
            configuration.CreateMap<UpdateMenuClientInput, MenuClient>();

            // DemoModel
            configuration.CreateMap<DemoModel, DemoModelDto>();
            configuration.CreateMap<DemoModelInput, DemoModel>();
            configuration.CreateMap<DemoModel, DemoModelInput>();
            configuration.CreateMap<DemoModel, DemoModelForViewDto>();

            // Customer
            configuration.CreateMap<Customer, CustomerDto>();
            configuration.CreateMap<CustomerInput, Customer>();
            configuration.CreateMap<Customer, CustomerInput>();
            configuration.CreateMap<Customer, CustomerForViewDto>();

            // TypeOfAsset
            configuration.CreateMap<TypeOfAsset, TypeOfAssetDto>();
            configuration.CreateMap<TypeOfAssetInput, TypeOfAsset>();
            configuration.CreateMap<TypeOfAsset, TypeOfAssetInput>();
            configuration.CreateMap<TypeOfAsset, TypeOfAssetForViewDto>();

            // AssetGroup
            configuration.CreateMap<AssetGroup, AssetGroupDto>();
            configuration.CreateMap<AssetGroupInput, AssetGroup>();
            configuration.CreateMap<AssetGroup, AssetGroupInput>();
            configuration.CreateMap<AssetGroup, AssetGroupForViewDto>();

            // Asset
            configuration.CreateMap<Asset, AssetDto>();
            configuration.CreateMap<AssetInput, Asset>();
            configuration.CreateMap<Asset, AssetInput>();
            configuration.CreateMap<Asset, AssetForViewDto>();
        }
    }
}