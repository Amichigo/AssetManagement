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
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;
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

namespace GWebsite.AbpZeroTemplate.Applications
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
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

            //ConstructionPlan
            configuration.CreateMap<ConstructionPlan, ConstructionPlanDto>();
            configuration.CreateMap<ConstructionPlanInput, ConstructionPlan>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanInput>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanForViewDto>();

            //ConstructionPlanDetail
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailDto>();
            configuration.CreateMap<ConstructionPlanDetailInput, ConstructionPlanDetail>();
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailInput>();

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

            //ts
            configuration.CreateMap<TaiSan_13, TaiSanDto>();
            configuration.CreateMap<TaiSanInput, TaiSan_13>();
            configuration.CreateMap<TaiSan_13, TaiSanInput>();
            configuration.CreateMap<TaiSan_13, TaiSanForViewDto>();

            //sc bds
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanDto>();
            configuration.CreateMap<SuaChuaBatDongSanInput, SuaChuaBatDongSan>();
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanInput>();
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanForViewDto>();

            //cong trinh
            configuration.CreateMap<CongTrinh_N13, CongTrinhDto>();
            configuration.CreateMap<CongTrinhInput, CongTrinh_N13>();
            configuration.CreateMap<CongTrinh_N13, CongTrinhInput>();
            configuration.CreateMap<CongTrinh_N13, CongTrinhForViewDto>();


            //ke hoach
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungDto>();
            configuration.CreateMap<KeHoachXayDungInput, KeHoachXayDung_N13>();
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungInput>();
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungForViewDto>();

            //ho so thau
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13Dto>();
            configuration.CreateMap<HoSoThauN13Input, HoSoThau_N13>();
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13Input>();
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13ForViewDto>();


            //don vi thau
            configuration.CreateMap<DonViThau_N13, DonViThauDto>();
            configuration.CreateMap<DonViThauInput, DonViThau_N13>();
            configuration.CreateMap<DonViThau_N13, DonViThauInput>();
            configuration.CreateMap<DonViThau_N13, DonViThauForViewDto>();
        }
    }
}