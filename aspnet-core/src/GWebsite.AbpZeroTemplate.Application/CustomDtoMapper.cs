using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto;
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

            configuration.CreateMap<Slide, SlideDto>();
            configuration.CreateMap<CreateSlideInput, Slide>();
            configuration.CreateMap<UpdateSlideInput, Slide>();

            configuration.CreateMap<VideoInstruction, VideoInstructionDto>();
            configuration.CreateMap<CreateVideoInstructionInput, VideoInstruction>();
            configuration.CreateMap<UpdateVideoInstructionInput, VideoInstruction>();

            configuration.CreateMap<OrderPackage, OrderPackageDto>();
            configuration.CreateMap<CreateOrderPackageInput, OrderPackage>();
            configuration.CreateMap<UpdateOrderPackageInput, OrderPackage>();

            configuration.CreateMap<VideoInstructionCategory, VideoInstructionCategoryDto>();
            configuration.CreateMap<CreateVideoInstructionCategoryInput, VideoInstructionCategory>();
            configuration.CreateMap<UpdateVideoInstructionCategoryInput, VideoInstructionCategory>();
            // DemoModel
            configuration.CreateMap<DemoModel, DemoModelDto>();
            configuration.CreateMap<DemoModelInput, DemoModel>();
            configuration.CreateMap<DemoModel, DemoModelInput>();

            configuration.CreateMap<Customer, CustomerDto>();
            configuration.CreateMap<CustomerInput, Customer>();
            configuration.CreateMap<Customer, CustomerInput>();
            configuration.CreateMap<Customer, CustomerForViewDto>();

            // Category type
            configuration.CreateMap<CategoryType, CategoryTypeDto>();
            configuration.CreateMap<CategoryTypeInput, CategoryType>();
            configuration.CreateMap<CategoryType, CategoryTypeInput>();
            configuration.CreateMap<CategoryType, CategoryTypeForViewDto>();

            // Category 
            configuration.CreateMap<Category, CategoryDto>();
            configuration.CreateMap<CategoryInput, Category>();
            configuration.CreateMap<Category, CategoryInput>();
            configuration.CreateMap<Category, CategoryForViewDto>();
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
        }
    }
}