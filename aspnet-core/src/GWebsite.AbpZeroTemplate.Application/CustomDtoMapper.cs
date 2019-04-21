using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;

using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung.DTO;

using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO;

using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO;

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

            // LoaiBDS
            configuration.CreateMap<LoaiBatDongSan, LoaiBatDongSanDto>();
            configuration.CreateMap<LoaiBatDongSanInput, LoaiBatDongSan>();
            configuration.CreateMap<LoaiBatDongSan, LoaiBatDongSanInput>();
            configuration.CreateMap<LoaiBatDongSan, LoaiBatDongSanForViewDto>();

            // LoaiSH
            configuration.CreateMap<LoaiSoHuu, LoaiSoHuuDto>();
            configuration.CreateMap<LoaiSoHuuInput, LoaiSoHuu>();
            configuration.CreateMap<LoaiSoHuu, LoaiSoHuuInput>();
            configuration.CreateMap<LoaiSoHuu, LoaiSoHuuForViewDto>();

            //Khu Vuc
            configuration.CreateMap<KhuVuc, KhuVucDto>();
            configuration.CreateMap<KhuVucInput, KhuVuc>();
            configuration.CreateMap<KhuVuc, KhuVucInput>();
            configuration.CreateMap<KhuVuc, KhuVucForViewDto>();
            //Tinh trang su dung dat 
            configuration.CreateMap<TinhTrangSuDungDat, TinhTrangSuDungDatDto>();
            configuration.CreateMap<TinhTrangSuDungDatInput, TinhTrangSuDungDat>();
            configuration.CreateMap<TinhTrangSuDungDat, TinhTrangSuDungDatInput>();
            configuration.CreateMap<TinhTrangSuDungDat, TinhTrangSuDungDatForViewDto>();
            // Tinh trang xay dung 
            configuration.CreateMap<TinhTrangXayDung, TinhTrangXayDungDto>();
            configuration.CreateMap<TinhTrangXayDungInput, TinhTrangXayDung>();
            configuration.CreateMap<TinhTrangXayDung, TinhTrangXayDungInput>();
            configuration.CreateMap<TinhTrangXayDung, TinhTrangXayDungForViewDto>();
            //Hien trang phap ly
            configuration.CreateMap<HienTrangPhapLy, HienTrangPhapLyDto>();
            configuration.CreateMap<HienTrangPhapLyInput, HienTrangPhapLy>();
            configuration.CreateMap<HienTrangPhapLy, HienTrangPhapLyInput>();
            configuration.CreateMap<HienTrangPhapLy, HienTrangPhapLyForViewDto>();
            //Muc dich su dung dat 
            configuration.CreateMap<MucDichSuDungDat, MucDichSuDungDatDto>();
            configuration.CreateMap<MucDichSuDungDatInput, MucDichSuDungDat>();
            configuration.CreateMap<MucDichSuDungDat, MucDichSuDungDatInput>();
            configuration.CreateMap<MucDichSuDungDat, MucDichSuDungDatForViewDto>();

            configuration.CreateMap<LoaiTaiSan, LoaiTaiSanDto>();
            configuration.CreateMap<LoaiTaiSanInput, LoaiTaiSan>();
            configuration.CreateMap<LoaiTaiSan, LoaiTaiSanInput>();
            configuration.CreateMap<LoaiTaiSan, LoaiTaiSanForViewDto>();

            configuration.CreateMap<NhomTaiSan, NhomTaiSanDto>();
            configuration.CreateMap<NhomTaiSanInput, NhomTaiSan>();
            configuration.CreateMap<NhomTaiSan, NhomTaiSanInput>();
            configuration.CreateMap<NhomTaiSan, NhomTaiSanForViewDto>();

            configuration.CreateMap<BatDongSan, BatDongSanDto>();
            configuration.CreateMap<BatDongSanInput, BatDongSan>();
            configuration.CreateMap<BatDongSan, BatDongSanInput>();
            configuration.CreateMap<BatDongSan, BatDongSanForViewDto>();

        }
    }
}