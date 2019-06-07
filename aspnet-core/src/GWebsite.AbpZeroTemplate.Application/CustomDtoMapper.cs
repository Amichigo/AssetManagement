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
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;
using GWebsite.AbpZeroTemplate.Core.Models.RealEstasAsset.QuanLyBDS;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.CongTrinh_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13.Dto;

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

          

            configuration.CreateMap<BatDongSan, BatDongSanDto>();
            configuration.CreateMap<BatDongSanInput, BatDongSan>();
            configuration.CreateMap<BatDongSan, BatDongSanInput>();
            configuration.CreateMap<BatDongSan, BatDongSanForViewDto>();

            //ts 13
            configuration.CreateMap<TaiSan_13, TaiSanDto>();
            configuration.CreateMap<TaiSanN13Input, TaiSan_13>();
            configuration.CreateMap<TaiSan_13, TaiSanN13Input>();
            configuration.CreateMap<TaiSan_13, TaiSanN13ForViewDto>();

            //sc bds 13
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanDto>();
            configuration.CreateMap<SuaChuaBatDongSanInput, SuaChuaBatDongSan>();
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanInput>();
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanForViewDto>();

            //cong trinh 13
            configuration.CreateMap<CongTrinh_N13, CongTrinhDto>();
            configuration.CreateMap<CongTrinhInput, CongTrinh_N13>();
            configuration.CreateMap<CongTrinh_N13, CongTrinhInput>();
            configuration.CreateMap<CongTrinh_N13, CongTrinhForViewDto>();


            //ke hoach 13
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungDto>();
            configuration.CreateMap<KeHoachXayDungInput, KeHoachXayDung_N13>();
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungInput>();
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungForViewDto>();

            //ho so thau 13
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13Dto>();
            configuration.CreateMap<HoSoThauN13Input, HoSoThau_N13>();
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13Input>();
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13ForViewDto>();


            //don vi thau 13
            configuration.CreateMap<DonViThau_N13, DonViThauN13Dto>();
            configuration.CreateMap<DonViThauN13Input, DonViThau_N13>();
            configuration.CreateMap<DonViThau_N13, DonViThauN13Input>();
            configuration.CreateMap<DonViThau_N13, DonViThauN13ForViewDto>();

            //hop dong
            configuration.CreateMap<HopDong_N13, HopDongN13Dto>();
            configuration.CreateMap<HopDongN13Input, HopDong_N13>();
            configuration.CreateMap<HopDong_N13, HopDongN13Input>();
            configuration.CreateMap<HopDong_N13, HopDongN13ForViewDto>();

            // thanh toan
            configuration.CreateMap<ThanhToan_N13, ThanhToanN13Dto>();
            configuration.CreateMap<ThanhToanN13Input, ThanhToan_N13>();
            configuration.CreateMap<ThanhToan_N13, ThanhToanN13Input>();
            configuration.CreateMap<ThanhToan_N13, ThanhToanN13ForViewDto>();
        }
    }
}