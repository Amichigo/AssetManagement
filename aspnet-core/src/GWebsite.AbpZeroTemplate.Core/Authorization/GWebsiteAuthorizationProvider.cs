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

            var menuClient = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient, L("MenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Create, L("CreatingNewMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Edit, L("EditingMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Delete, L("DeletingMenuClient"));

            var demoModel = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel, L("DemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Create, L("CreatingNewDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Edit, L("EditingDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Delete, L("DeletingDemoModel"));

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            var loaibds = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiBatDongSan, L("LoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiBatDongSan_Create, L("CreatingNewLoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiBatDongSan_Edit, L("EditingLoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiBatDongSan_Delete, L("DeletingLoaiBatDongSan"));

            var loaish = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiSoHuu, L("LoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiSoHuu_Create, L("CreatingNewLoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiSoHuu_Edit, L("EditingLoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiSoHuu_Delete, L("DeletingLoaiSoHuu"));
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
            var htpl = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_HienTrangPhapLy, L("HienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_HienTrangPhapLy_Create, L("CreatingNewHienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_HienTrangPhapLy_Edit, L("EditingHienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_HienTrangPhapLy_Delete, L("DeletingHienTrangPhapLy"));
            //Muc dich su dung dat
            var mdsdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MucDichSuDungDat, L("MucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_MucDichSuDungDat_Create, L("CreatingNewMucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_MucDichSuDungDat_Edit, L("EditingMucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_MucDichSuDungDat_Delete, L("DeletingMucDichSuDungDat"));

            var loaits = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan, L("LoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Create, L("CreatingNewLoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Edit, L("EditingLoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Delete, L("DeletingLoaiTaiSan"));

            var nhomts = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan, L("NhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Create, L("CreatingNewNhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Edit, L("EditingNhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Delete, L("DeletingNhomTaiSan"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
