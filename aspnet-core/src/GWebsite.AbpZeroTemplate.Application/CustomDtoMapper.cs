using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LocationTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto;
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

            configuration.CreateMap<Asset_test9, AssetDto_9 >();
            configuration.CreateMap<AssetInput_9, Asset_test9>();
            configuration.CreateMap<Asset_test9, AssetInput_9>();
            configuration.CreateMap<Asset_test9, AssetForViewDto_9>();

            configuration.CreateMap<Building_9, BuildingDto_9>();
            configuration.CreateMap<BuildingInput_9, Building_9>();
            configuration.CreateMap<Building_9, BuildingInput_9>();
            configuration.CreateMap<Building_9, BuildingForViewDto_9>();

            configuration.CreateMap<Land_9, LandDto_9>();
            configuration.CreateMap<LandInput_9, Land_9>();
            configuration.CreateMap<Land_9, LandInput_9>();
            configuration.CreateMap<Land_9, LandForViewDto_9>();

            configuration.CreateMap<RealEstate_9, RealEstateDto_9>();
            configuration.CreateMap<RealEstateInput_9, RealEstate_9>();
            configuration.CreateMap<RealEstate_9, RealEstateInput_9>();
            configuration.CreateMap<RealEstate_9, RealEstateForViewDto_9>();

            configuration.CreateMap<RealEstateType_9, RealEstateTypeDto_9>();
            configuration.CreateMap<RealEstateTypeInput_9, RealEstateType_9>();
            configuration.CreateMap<RealEstateType_9, RealEstateTypeInput_9>();
            configuration.CreateMap<RealEstateType_9, RealEstateTypeForViewDto_9>();

            configuration.CreateMap<LegalStatusType_9, LegalStatusTypeDto_9>();
            configuration.CreateMap<LegalStatusTypeInput_9, LegalStatusType_9>();
            configuration.CreateMap<LegalStatusType_9, LegalStatusTypeInput_9>();
            configuration.CreateMap<LegalStatusType_9, LegalStatusTypeForViewDto_9>();

            configuration.CreateMap<LocationType_9, LocationTypeDto_9>();
            configuration.CreateMap<LocationTypeInput_9, LocationType_9>();
            configuration.CreateMap<LocationType_9, LocationTypeInput_9>();
            configuration.CreateMap<LocationType_9, LocationTypeForViewDto_9>();

            configuration.CreateMap<RealEstateRepair_9, RealEstateRepairDto_9>();
            configuration.CreateMap<RealEstateRepairInput_9, RealEstateRepair_9>();
            configuration.CreateMap<RealEstateRepair_9, RealEstateRepairInput_9>();
            configuration.CreateMap<RealEstateRepair_9, RealEstateRepairForViewDto_9>();

            configuration.CreateMap<BidManager_9, BidManagerDto>();
            configuration.CreateMap<BidManagerInput, BidManager_9>();
            configuration.CreateMap<BidManager_9, BidManagerInput>();
            configuration.CreateMap<BidManager_9, BidManagerForViewDto>();

            configuration.CreateMap<Construction_9, ConstructionDto>();
            configuration.CreateMap<ConstructionInput, Construction_9>();
            configuration.CreateMap<Construction_9, ConstructionInput>();
            configuration.CreateMap<Construction_9, ConstructionForViewDto>();

            configuration.CreateMap<ContractGuarantee, ContractGuaranteeDto>();
            configuration.CreateMap<ContractGuaranteeInput, ContractGuarantee>();
            configuration.CreateMap<ContractGuarantee, ContractGuaranteeInput>();
            configuration.CreateMap<ContractGuarantee, ContractGuaranteeForViewDto>();

            configuration.CreateMap<ContractManagement, ContractManagementDto>();
            configuration.CreateMap<ContractManagementInput, ContractManagement>();
            configuration.CreateMap<ContractManagement, ContractManagementForViewDto>();
            configuration.CreateMap<ContractManagement, CustomerForViewDto>();

            configuration.CreateMap<Contractors_9, ContractorDto>();
            configuration.CreateMap<ContractorInput, Contractors_9>();
            configuration.CreateMap<Contractors_9, ContractorInput>();
            configuration.CreateMap<Contractors_9, ContractorForViewDto>();

            configuration.CreateMap<PaymentDetails_9, PaymentDetailDto>();
            configuration.CreateMap<PaymentDetailInput, PaymentDetails_9>();
            configuration.CreateMap<PaymentDetails_9, PaymentDetailInput>();
            configuration.CreateMap<PaymentDetails_9, PaymentDetailForViewDto>();

            configuration.CreateMap<Plan_9, PlanDto>();
            configuration.CreateMap<PlanInput, Plan_9>();
            configuration.CreateMap<Plan_9, PlanInput>();
            configuration.CreateMap<Plan_9, PlanForViewDto>();

            configuration.CreateMap<WarrantyGuarantee, WarrantyGuaranteeDto>();
            configuration.CreateMap<WarrantyGuaranteeInput, WarrantyGuarantee>();
            configuration.CreateMap<WarrantyGuarantee, WarrantyGuaranteeInput>();
            configuration.CreateMap<WarrantyGuarantee, WarrantyGuaranteeForViewDto>();
        }
    }
}