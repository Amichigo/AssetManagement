using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;

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
            configuration.CreateMap<SanPham, SanPhamDto>();
            configuration.CreateMap<SanPhamInput, SanPham>();
            configuration.CreateMap<SanPham, SanPhamInput>();
            configuration.CreateMap<SanPham, SanPhamForViewDto>();
        }
    }
}