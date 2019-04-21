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

            var menuClients = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage, L("MenuClient"));
            menuClients.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Create, L("CreatingNewMenuClient"));
            menuClients.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Edit, L("EditingMenuClient"));
            menuClients.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Delete, L("DeletingMenuClient"));

            var orderPackages = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient, L("OrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Create, L("CreatingNewOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Edit, L("EditingOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Delete, L("DeletingOrderPackage"));

            var videoInstructions = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction, L("VideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Create, L("CreatingNewVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Edit, L("EditingVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Delete, L("DeletingVideoInstruction"));

            var VideoInstructionCategories = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory, L("VideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Create, L("CreatingNewVVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Edit, L("EditingVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Delete, L("DeletingVideoInstructionCategory"));

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            ///du an
            var duan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DuAn, L("DuAn"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DuAn_Create, L("CreatingNewDuAn"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DuAn_Edit, L("EditingDuAn"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DuAn_Delete, L("DeletingDuAn"));

            ///ho so thau
            var thau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_HoSoThau, L("HoSoThau"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_HoSoThau_Create, L("CreatingNewHoSoThau"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_HoSoThau_Edit, L("EditingHoSoThau"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_HoSoThau_Delete, L("DeletingHoSoThau"));

            ///nha cung cap
            var nhacungcap = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCap, L("NhaCungCap"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCap_Create, L("CreatingNewNhaCungCap"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCap_Edit, L("EditingNhaCungCap"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCap_Delete, L("DeletingNhaCungCap"));

            ///hop dong thau
            var hopdongthau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_HopDongThau, L("HopDongThau"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_HopDongThau_Create, L("CreatingNewHopDongThau"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_HopDongThau_Edit, L("EditingHopDongThau"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_HopDongThau_Delete, L("DeletingHopDongThau"));

            ///hop dong thau
            var phieugoihang = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PhieuGoiHang, L("PhieuGoiHang"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_PhieuGoiHang_Create, L("CreatingNewPhieuGoiHang"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_PhieuGoiHang_Edit, L("EditingPhieuGoiHang"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_PhieuGoiHang_Delete, L("DeletingPhieuGoiHang"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
