using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts.Dto;
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

            //ShoppingPlan
            configuration.CreateMap<ShoppingPlan, ShoppingPlanDto>();
            configuration.CreateMap<ShoppingPlanInput, ShoppingPlan>();
            configuration.CreateMap<ShoppingPlan, ShoppingPlanInput>();
            configuration.CreateMap<ShoppingPlan, ShoppingPlanForViewDto>();

            //ShoppingPlanDetail
            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailDto>();
            configuration.CreateMap<ShoppingPlanDetailInput, ShoppingPlanDetail>();
            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailInput>();

            //ConstructionPlan
            configuration.CreateMap<ConstructionPlan, ConstructionPlanDto>();
            configuration.CreateMap<ConstructionPlanInput, ConstructionPlan>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanInput>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanForViewDto>();

            //ConstructionPlanDetail
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailDto>();
            configuration.CreateMap<ConstructionPlanDetailInput, ConstructionPlanDetail>();
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailInput>();

            //DisposalPlan
            configuration.CreateMap<DisposalPlan, DisposalPlanDto>();
            configuration.CreateMap<DisposalPlanInput, DisposalPlan>();
            configuration.CreateMap<DisposalPlan, DisposalPlanInput>();
            configuration.CreateMap<DisposalPlan, DisposalPlanForViewDto>();

            //DisposalPlanDetail
            configuration.CreateMap<DisposalPlanDetail, DisposalPlanDetailDto>();
            configuration.CreateMap<DisposalPlanDetailInput, DisposalPlanDetail>();
            configuration.CreateMap<DisposalPlanDetail, DisposalPlanDetailInput>();

            //DisposalProduct
            configuration.CreateMap<DisposalProduct, DisposalProductDto>();
            configuration.CreateMap<DisposalProductInput, DisposalProduct>();
            configuration.CreateMap<DisposalProduct, DisposalProductInput>();
        }
    }
}