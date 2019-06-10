using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MaintainedAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToMaintainAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToPurchaseAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PlannedToSellAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SoldAssets.Dto;
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

            // AssetActivity
            configuration.CreateMap<AssetActivity, AssetActivityDto>();
            configuration.CreateMap<AssetActivityInput, AssetActivity>();
            configuration.CreateMap<AssetActivity, AssetActivityInput>();
            configuration.CreateMap<AssetActivity, AssetActivityForViewDto>();

            // SoldAsset
            configuration.CreateMap<SoldAsset, SoldAssetDto>();
            configuration.CreateMap<SoldAssetInput, SoldAsset>();
            configuration.CreateMap<SoldAsset, SoldAssetInput>();
            configuration.CreateMap<SoldAsset, SoldAssetForViewDto>();

            // PurchasedAsset
            configuration.CreateMap<PurchasedAsset, PurchasedAssetDto>();
            configuration.CreateMap<PurchasedAssetInput, PurchasedAsset>();
            configuration.CreateMap<PurchasedAsset, PurchasedAssetInput>();
            configuration.CreateMap<PurchasedAsset, PurchasedAssetForViewDto>();

            // MaintainedAsset
            configuration.CreateMap<MaintainedAsset, MaintainedAssetDto>();
            configuration.CreateMap<MaintainedAssetInput, MaintainedAsset>();
            configuration.CreateMap<MaintainedAsset, MaintainedAssetInput>();
            configuration.CreateMap<MaintainedAsset, MaintainedAssetForViewDto>();

            // PlannedToMaintainAsset
            configuration.CreateMap<PlannedToMaintainAsset, PlannedToMaintainAssetDto>();
            configuration.CreateMap<PlannedToMaintainAssetInput, PlannedToMaintainAsset>();
            configuration.CreateMap<PlannedToMaintainAsset, PurchasedAssetInput>();
            configuration.CreateMap<PlannedToMaintainAsset, PlannedToMaintainAssetForViewDto>();

            // PlannedToPurchaseAsset
            configuration.CreateMap<PlannedToPurchaseAsset, PlannedToPurchaseAssetDto>();
            configuration.CreateMap<PlannedToPurchaseAssetInput, PlannedToPurchaseAsset>();
            configuration.CreateMap<PlannedToPurchaseAsset, PurchasedAssetInput>();
            configuration.CreateMap<PlannedToPurchaseAsset, PlannedToPurchaseAssetForViewDto>();

            // PlannedToSellAsset
            configuration.CreateMap<PlannedToSellAsset, PlannedToSellAssetDto>();
            configuration.CreateMap<PlannedToSellAssetInput, PlannedToSellAsset>();
            configuration.CreateMap<PlannedToSellAsset, PurchasedAssetInput>();
            configuration.CreateMap<PlannedToSellAsset, PlannedToSellAssetForViewDto>();

            // OperatingAsset
            configuration.CreateMap<OperatingAsset, OperatingAssetDto>();
            configuration.CreateMap<OperatingAssetInput, OperatingAsset>();
            configuration.CreateMap<OperatingAsset, OperatingAssetInput>();
            configuration.CreateMap<OperatingAsset, OperatingAssetForViewDto>();
        }
    }
}