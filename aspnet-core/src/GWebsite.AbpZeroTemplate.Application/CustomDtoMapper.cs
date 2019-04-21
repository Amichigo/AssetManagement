using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Handovers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes.Dto;
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

            // Asset
            configuration.CreateMap<Asset, AssetDto>();
            configuration.CreateMap<AssetInput, Asset>();
            configuration.CreateMap<Asset, AssetInput>();
            configuration.CreateMap<Asset, AssetForViewDto>();

            // Building
            configuration.CreateMap<Building, BuildingDto>();
            configuration.CreateMap<BuildingInput, Building>();
            configuration.CreateMap<Building, BuildingInput>();
            configuration.CreateMap<Building, BuildingForViewDto>();

            // Construction
            configuration.CreateMap<Construction, ConstructionDto>();
            configuration.CreateMap<ConstructionInput, Construction>();
            configuration.CreateMap<Construction, ConstructionInput>();
            configuration.CreateMap<Construction, ConstructionForViewDto>();

            // Handover
            configuration.CreateMap<Handover, HandoverDto>();
            configuration.CreateMap<HandoverInput, Handover>();
            configuration.CreateMap<Handover, HandoverInput>();
            configuration.CreateMap<Handover, HandoverForViewDto>();

            // Land
            configuration.CreateMap<Land, LandDto>();
            configuration.CreateMap<LandInput, Land>();
            configuration.CreateMap<Land, LandInput>();
            configuration.CreateMap<Land, LandForViewDto>();

            // Real Estate
            configuration.CreateMap<RealEstate, RealEstateDto>();
            configuration.CreateMap<RealEstateInput, RealEstate>();
            configuration.CreateMap<RealEstate, RealEstateInput>();
            configuration.CreateMap<RealEstate, RealEstateForViewDto>();

            // Revoke
            configuration.CreateMap<Revoke, RevokeDto>();
            configuration.CreateMap<RevokeInput, Revoke>();
            configuration.CreateMap<Revoke, RevokeInput>();
            configuration.CreateMap<Revoke, RevokeForViewDto>();
        }
    }
}