using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class GWebsiteAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public GWebsiteAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public GWebsiteAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(GWebsitePermissions.Pages) ?? context.CreatePermission(GWebsitePermissions.Pages, L("Pages"));
            var gwebsite = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_GWebsite, L("GWebsite"));

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            var categoryType = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General, L("CategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Create, L("CreatingNewCategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Edit, L("EditingCategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Delete, L("DeletingCategoryType"));

            var category = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Categories_General, L("Category"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Create, L("CreatingNewCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Edit, L("EditingCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Delete, L("DeletingCategory"));

            var orderPackages = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage, L("OrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Create, L("CreatingNewOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Edit, L("EditingOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Delete, L("DeletingOrderPackage"));

            var videoInstructions = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction, L("VideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Create, L("CreatingNewVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Edit, L("EditingVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Delete, L("DeletingVideoInstruction"));

            var VideoInstructionCategories = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory, L("VideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Create, L("CreatingNewVVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Edit, L("EditingVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Delete, L("DeletingVideoInstructionCategory"));
            ///project
            var duan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project, L("Project"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Create, L("CreatingNewProject"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Edit, L("EditingProject"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Delete, L("DeletingProject"));

            ///bid
            var thau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid, L("Bid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Create, L("CreatingNewBid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Edit, L("EditingBid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Delete, L("DeletingBid"));

            ///supplier
            var nhacungcap = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier, L("Supplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Create, L("CreatingNewSupplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Edit, L("EditingSupplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Delete, L("DeletingSupplier"));

            ///contract
            var hopdongthau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract, L("Contract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Create, L("CreatingNewContract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Edit, L("EditingContract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Delete, L("DeletingContract"));

            ///goodsInvoice
            var phieugoihang = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice, L("GoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Create, L("CreatingNewGoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Edit, L("EditingGoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Delete, L("DeletingGoodsInvoice"));

            ///goods
            var hanghoa = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods, L("Goods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Create, L("CreatingNewGoods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Edit, L("EditingGoods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Delete, L("DeletingGoods"));

            var shoppingPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan, L("ShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Create, L("CreatingNewShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Edit, L("EditingShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Delete, L("DeletingShoppingPlan"));

            var shoppingPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail, L("ShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Create, L("CreatingNewShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Edit, L("EditingShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Delete, L("DeletingShoppingPlanDetail"));

            var directorShoppingPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan, L("DirectorShoppingPlan"));
            directorShoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Create, L("CreatingNewDirectorShoppingPlan"));
            directorShoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Edit, L("EditingDirectorShoppingPlan"));
            directorShoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Delete, L("DeletingDirectorShoppingPlan"));

            var constructionPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan, L("ConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Create, L("CreatingNewConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Edit, L("EditingConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Delete, L("DeletingConstructionPlan"));

            var constructionPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail, L("ConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Create, L("CreatingNewConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Edit, L("EditingConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Delete, L("DeletingConstructionPlanDetail"));
        
            var loaibds = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan, L("LoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Create, L("CreatingNewLoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Edit, L("EditingLoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Delete, L("DeletingLoaiBatDongSan"));

            var loaish = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu, L("LoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Create, L("CreatingNewLoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Edit, L("EditingLoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Delete, L("DeletingLoaiSoHuu"));
            //Khu Vuc
            var kv = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc, L("KhuVuc"));
            kv.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc_Create, L("CreatingNewKhuVuc"));
            kv.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc_Edit, L("EditingKhuVuc"));
            kv.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc_Delete, L("DeletingKhuVuc"));
            //Tinh trang su dung dat
            var ttsdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat, L("TinhTrangSuDungDat"));
            ttsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Create, L("CreatingNewTinhTrangSuDungDat"));
            ttsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Edit, L("EditingTinhTrangSuDungDat"));
            ttsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Delete, L("DeletingTinhTrangSuDungDat"));
            //Tinh trang xay dung 
            var ttxd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung, L("TinhTrangXayDung"));
            ttxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Create, L("CreatingNewTinhTrangXayDung"));
            ttxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Edit, L("EditingTinhTrangXayDung"));
            ttxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Delete, L("DeletingTinhTrangXayDung"));
            //Hien trang phap ly
            var htpl = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy, L("HienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Create, L("CreatingNewHienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Edit, L("EditingHienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Delete, L("DeletingHienTrangPhapLy"));
            //Muc dich su dung dat
            var mdsdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat, L("MucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Create, L("CreatingNewMucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Edit, L("EditingMucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Delete, L("DeletingMucDichSuDungDat"));

            var loaits = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan, L("LoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Create, L("CreatingNewLoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Edit, L("EditingLoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Delete, L("DeletingLoaiTaiSan"));

            var nhomts = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan, L("NhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Create, L("CreatingNewNhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Edit, L("EditingNhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Delete, L("DeletingNhomTaiSan"));


            var bds = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan, L("BatDongSan"));
            bds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Create, L("CreatingNewBatDongSan"));
            bds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Edit, L("EditingBatDongSan"));
            bds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Delete, L("DeletingBatDongSan"));

            var ts = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan, L("TaiSan"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Create, L("CreatingNewTaiSan"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Edit, L("EditingTaiSan"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Delete, L("DeletingTaiSan"));


            var scBDS = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan, L("SuaChuaBatDongSan"));
            scBDS.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Create, L("CreatingNewSuaChuaBatDongSan"));
            scBDS.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Edit, L("EditingSuaChuaBatDongSan"));
            scBDS.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Delete, L("DeletingSuaChuaBatDongSan"));

            var khxd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung, L("KeHoachXayDung"));
            khxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Create, L("CreatingNewKeHoachXayDung"));
            khxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Edit, L("EditingKeHoachXayDung"));
            khxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Delete, L("DeletingKeHoachXayDung"));

            var ctdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang, L("CongTrinhDoDang"));
            ctdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Create, L("CreatingNewCongTrinhDoDang"));
            ctdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Edit, L("EditingCongTrinhDoDang"));
            ctdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Delete, L("DeletingCongTrinhDoDang"));

            var dvtN13 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau, L("HoSoThau"));
            dvtN13.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Create, L("CreatingNewHoSoThau"));
            dvtN13.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Edit, L("EditingHoSoThau"));
            dvtN13.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Delete, L("DeletingHoSoThau"));

        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
