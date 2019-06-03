using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;

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

            //Vehicle
            configuration.CreateMap<Vehicle, VehicleDto>();
            configuration.CreateMap<VehicleInput, Vehicle>();
            configuration.CreateMap<Vehicle, VehicleInput>();
            configuration.CreateMap<Vehicle, VehicleForViewDto>();
            //TypeVehcile
            configuration.CreateMap<TypeVehicle, TypeVehicleDto>();
            configuration.CreateMap<TypeVehicleInput, TypeVehicle>();
            configuration.CreateMap<TypeVehicle, TypeVehicleInput>();
            configuration.CreateMap<TypeVehicle, TypeVehicleForViewDto>();
            //ModelVehicle
            configuration.CreateMap<ModelVehicle, ModelVehicleDto>();
            configuration.CreateMap<ModelVehicleInput, ModelVehicle>();
            configuration.CreateMap<ModelVehicle, ModelVehicleInput>();
            configuration.CreateMap<ModelVehicle, ModelVehicleForViewDto>();
            //Asset
            configuration.CreateMap<Asset_8, AssetDto>();
            configuration.CreateMap<AssetInput, Asset_8>();
            configuration.CreateMap<Asset_8, AssetInput>();
            configuration.CreateMap<Asset_8, AssetForViewDto>();
            //brand
            configuration.CreateMap<BrandVehicle, BrandVehicleDto>();
            configuration.CreateMap<BrandVehicleInput, BrandVehicle>();
            configuration.CreateMap<BrandVehicle, BrandVehicleInput>();
            configuration.CreateMap<BrandVehicle, BrandVehicleForViewDto>();
            //operate
            configuration.CreateMap<OperateVehicle, OperateVehicleDto>();
            configuration.CreateMap<OperateVehicleInput, OperateVehicle>();
            configuration.CreateMap<OperateVehicle, OperateVehicleInput>();
            configuration.CreateMap<OperateVehicle, OperateVehicleForViewDto>();
        }
    }
}