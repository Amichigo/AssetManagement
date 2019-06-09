using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto;
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
            configuration.CreateMap<Asset_8, Asset_8Dto>();
            configuration.CreateMap<Asset_8Input, Asset_8>();
            configuration.CreateMap<Asset_8, Asset_8Input>();
            configuration.CreateMap<Asset_8, Asset_8ForViewDto>();
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

            configuration.CreateMap<RoadFeeVehicle, RoadFeeVehicleDto>();
            configuration.CreateMap<RoadFeeVehicleInput, RoadFeeVehicle>();
            configuration.CreateMap<RoadFeeVehicle, RoadFeeVehicleInput>();
            configuration.CreateMap<RoadFeeVehicle, RoadFeeVehicleForViewDto>();


            // Insurrance
            configuration.CreateMap<Insurrance, InsurranceDto>();
            configuration.CreateMap<InsurranceInput, Insurrance>();
            configuration.CreateMap<Insurrance, InsurranceInput>();
            configuration.CreateMap<Insurrance, InsurranceForViewDto>();

            // InsurranceType
            configuration.CreateMap<InsurranceType, InsurranceTypeDto>();
            configuration.CreateMap<InsurranceTypeInput, InsurranceType>();
            configuration.CreateMap<InsurranceType, InsurranceTypeInput>();
            configuration.CreateMap<InsurranceType, InsurranceTypeForViewDto>();
        }
    }
}