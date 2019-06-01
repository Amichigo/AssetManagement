using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
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

            // LoaiNhaCungCap
            configuration.CreateMap<LoaiNhaCungCap, LoaiNhaCungCapDto>();
            configuration.CreateMap<LoaiNhaCungCapInput, LoaiNhaCungCap>();
            configuration.CreateMap<LoaiNhaCungCap, LoaiNhaCungCapInput>();
            configuration.CreateMap<LoaiNhaCungCap, LoaiNhaCungCapForViewDto>();

            //NhaCungCapHangHoa
            configuration.CreateMap<NhaCungCapHangHoa, NhaCungCapHangHoaDto>();
            configuration.CreateMap<NhaCungCapHangHoaInput, NhaCungCapHangHoa>();
            configuration.CreateMap<NhaCungCapHangHoa, NhaCungCapHangHoaInput>();
            configuration.CreateMap<NhaCungCapHangHoa, NhaCungCapHangHoaForViewDto>();

            //ProductType

            configuration.CreateMap<ProductType, ProductTypeDto>();
            configuration.CreateMap<ProductTypeInput, ProductType>();
            configuration.CreateMap<ProductType, ProductTypeInput>();
            configuration.CreateMap<ProductType, ProductTypeForViewDto>();

            //Product
            configuration.CreateMap<Product, ProductDto>();
            configuration.CreateMap<ProductInput, Product>();
            configuration.CreateMap<Product, ProductInput>();
            configuration.CreateMap<Product, ProductForViewDto>();

        }
    }
}