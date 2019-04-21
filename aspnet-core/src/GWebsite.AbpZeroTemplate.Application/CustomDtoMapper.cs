using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs.Dto;
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

            //du an
            configuration.CreateMap<DuAn, DuAnDto>();
            configuration.CreateMap<DuAnInput, DuAn>();
            configuration.CreateMap<DuAn, DuAnInput>();
            configuration.CreateMap<DuAn, DuAnForViewDto>();

            //ho so thau
            configuration.CreateMap<HoSoThau, HoSoThauDto>();
            configuration.CreateMap<HoSoThauInput, HoSoThau>();
            configuration.CreateMap<HoSoThau, HoSoThauInput>();
            configuration.CreateMap<HoSoThau, HoSoThauForViewDto>();

            //nha cung cap
            configuration.CreateMap<NhaCungCap, NhaCungCapDto>();
            configuration.CreateMap<NhaCungCapInput, NhaCungCap>();
            configuration.CreateMap<NhaCungCap, NhaCungCapInput>();
            configuration.CreateMap<NhaCungCap, NhaCungCapForViewDto>();

            //hop dong thau
            configuration.CreateMap<HopDongThau, HopDongThauDto>();
            configuration.CreateMap<HopDongThauInput, HopDongThau>();
            configuration.CreateMap<HopDongThau, HopDongThauInput>();
            configuration.CreateMap<HopDongThau, HopDongThauForViewDto>();

            //phieu goi hang
            configuration.CreateMap<PhieuGoiHang, PhieuGoiHangDto>();
            configuration.CreateMap<PhieuGoiHangInput, PhieuGoiHang>();
            configuration.CreateMap<PhieuGoiHang, PhieuGoiHangInput>();
            configuration.CreateMap<PhieuGoiHang, PhieuGoiHangForViewDto>();

        }
    }
}