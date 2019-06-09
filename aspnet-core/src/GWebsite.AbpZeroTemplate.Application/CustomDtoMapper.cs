using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets;

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

            // Asset
            configuration.CreateMap<FixedAsset, FixedAssetDto>();
            configuration.CreateMap<FixedAssetInput, FixedAsset>();
            configuration.CreateMap<FixedAsset, FixedAssetInput>();
            configuration.CreateMap<FixedAsset, FixedAssetForViewDto>();//view

           // AssetGroup
            configuration.CreateMap<AssetGroup_05, AssetGroupDto_05>();//get filter assetGroup
            configuration.CreateMap<AssetGroupDto_05, AssetGroup_05>();//create
            configuration.CreateMap<AssetGroup_05, AssetGroupInput_05>();//get for edit
            configuration.CreateMap<AssetGroup_05, AssetGroupOutput_05>();//get for edit
            configuration.CreateMap<AssetGroup_05, AssetGroupForViewDto_05>();//view

           // Asset_05
            configuration.CreateMap<Asset_05, AssetDto_05>();
            configuration.CreateMap<AssetDto_05, Asset_05>();
            configuration.CreateMap<Asset_05, AssetDto_05>();
            configuration.CreateMap<Asset_05, AssetForViewDto_05>();
            configuration.CreateMap<Asset_05, AssetOutput_05>();//get for edit

            //AssetType_05
            configuration.CreateMap<AssetType_05, AssetTypeDto_05>();
            configuration.CreateMap<AssetType_05, AssetForViewDto_05>();

            configuration.CreateMap<TransferringAssetDataInput, TransferringAsset>();
            configuration.CreateMap<TransferringAsset, TransferringAssetDataInput>();

            configuration.CreateMap<Warranty_05, WarrantyDto>();

            // ExportingUsedAsset
            configuration.CreateMap<ExportingUsedAsset, ExportingUsedAssetDto>();
            configuration.CreateMap<ExportingUsedAssetInput, ExportingUsedAsset>();
            configuration.CreateMap<ExportingUsedAsset, ExportingUsedAssetInput>();
            configuration.CreateMap<ExportingUsedAsset, ExportingUsedAssetForViewDto>();

        }
    }
}