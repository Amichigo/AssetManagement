using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto;
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

            configuration.CreateMap<Customer, CustomerDto>();
            configuration.CreateMap<CustomerInput, Customer>();
            configuration.CreateMap<Customer, CustomerInput>();
            configuration.CreateMap<Customer, CustomerForViewDto>();

            //project
            configuration.CreateMap<Project, ProjectDto>();
            configuration.CreateMap<ProjectInput, Project>();
            configuration.CreateMap<Project, ProjectInput>();
            configuration.CreateMap<Project, ProjectForViewDto>();

            //bid
            configuration.CreateMap<Bid, BidDto>();
            configuration.CreateMap<BidInput, Bid>();
            configuration.CreateMap<Bid, BidInput>();
            configuration.CreateMap<Bid, BidForViewDto>();

            //supplier
            configuration.CreateMap<Supplier, SupplierDto>();
            configuration.CreateMap<SupplierInput, Supplier>();
            configuration.CreateMap<Supplier, SupplierInput>();
            configuration.CreateMap<Supplier, SupplierForViewDto>();

            //contract
            configuration.CreateMap<Contract, ContractDto>();
            configuration.CreateMap<ContractInput, Contract>();
            configuration.CreateMap<Contract, ContractInput>();
            configuration.CreateMap<Contract, ContractForViewDto>();

            //goodsInvoice
            configuration.CreateMap<GoodsInvoice, GoodsInvoiceDto>();
            configuration.CreateMap<GoodsInvoiceInput, GoodsInvoice>();
            configuration.CreateMap<GoodsInvoice, GoodsInvoiceInput>();
            configuration.CreateMap<GoodsInvoice, GoodsInvoiceForViewDto>();

            //goods
            configuration.CreateMap<Goods, GoodsDto>();
            configuration.CreateMap<GoodsInput, Goods>();
            configuration.CreateMap<Goods, GoodsInput>();
            configuration.CreateMap<Goods, GoodsForViewDto>();

            //contractPayment
            configuration.CreateMap<ContractPayment, ContractPaymentDto>();
            configuration.CreateMap<ContractPaymentInput, ContractPayment>();
            configuration.CreateMap<ContractPayment, ContractPaymentInput>();
            configuration.CreateMap<ContractPayment, ContractPaymentForViewDto>();
        }
    }
}