using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
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

        }
    }
}