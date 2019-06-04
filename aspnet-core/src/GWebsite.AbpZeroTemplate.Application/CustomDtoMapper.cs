using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FormOfRentingAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRentingContracts.Dto;

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

     

            // RentalAsset
            configuration.CreateMap<RentalAsset, RentalAssetDto>();
            configuration.CreateMap<RentalAssetInput, RentalAsset>();
            configuration.CreateMap<RentalAsset, RentalAssetInput>();
            configuration.CreateMap<RentalAsset, RentalAssetForViewDto>();

             // TypeOfRentalAsset
            configuration.CreateMap<TypeOfRentalAsset, TypeOfRentalAssetDto>();
            configuration.CreateMap<TypeOfRentalAssetInput, TypeOfRentalAsset>();
            configuration.CreateMap<TypeOfRentalAsset, TypeOfRentalAssetInput>();
            configuration.CreateMap<TypeOfRentalAsset, TypeOfRentalAssetForViewDto>();

            // FormOfRentingAsset
            configuration.CreateMap<FormOfRentingAsset, FormOfRentingAssetDto>();
            configuration.CreateMap<FormOfRentingAssetInput, FormOfRentingAsset>();
            configuration.CreateMap<FormOfRentingAsset, FormOfRentingAssetInput>();
            configuration.CreateMap<FormOfRentingAsset, FormOfRentingAssetForViewDto>();

            // AssetRentingFile
            configuration.CreateMap<AssetRentingFile, AssetRentingFileDto>();
            configuration.CreateMap<AssetRentingFileInput, AssetRentingFile>();
            configuration.CreateMap<AssetRentingFile, AssetRentingFileInput>();
            configuration.CreateMap<AssetRentingFile, AssetRentingFileForViewDto>();

            // AssetRentingContract
            configuration.CreateMap<AssetRentingContract, AssetRentingContractDto>();
            configuration.CreateMap<AssetRentingContractInput, AssetRentingContract>();
            configuration.CreateMap<AssetRentingContract, AssetRentingContractInput>();
            configuration.CreateMap<AssetRentingContract, AssetRentingContractForViewDto>();
        }
    }
}