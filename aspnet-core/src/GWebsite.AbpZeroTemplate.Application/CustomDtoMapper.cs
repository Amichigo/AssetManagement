using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
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

            //DirectorShoppingPlan
            configuration.CreateMap<DirectorShoppingPlan, DirectorShoppingPlanDto>();
            configuration.CreateMap<DirectorShoppingPlanInput, DirectorShoppingPlan>();
            configuration.CreateMap<DirectorShoppingPlan, DirectorShoppingPlanInput>();
            configuration.CreateMap<DirectorShoppingPlan, DirectorShoppingPlanForViewDto>();

            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailDto>();
            configuration.CreateMap<ShoppingPlanDetailInput, ShoppingPlanDetail>();
            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailInput>();
        }
    }
}