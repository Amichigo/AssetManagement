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

            var LoaiNhaCungCap = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap, L("LoaiNhaCungCap"));
            LoaiNhaCungCap.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Create, L("CreatingNewLoaiNhaCungCap"));
            LoaiNhaCungCap.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Edit, L("EditingLoaiNhaCungCap"));
            LoaiNhaCungCap.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Delete, L("DeletingLoaiNhaCungCap"));

            var NhaCungCapHangHoa = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa, L("NhaCungCapHangHoa"));
            NhaCungCapHangHoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Create, L("CreatingNewNhaCungCapHangHoa"));
            NhaCungCapHangHoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Edit, L("EditingNhaCungCapHangHoa"));
            NhaCungCapHangHoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Delete, L("DeletingNhaCungCapHangHoa"));

            var ProductType = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType, L("ProductType"));
            ProductType.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType_Create, L("CreatingNewProductType"));
            ProductType.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType_Edit, L("EditingProductType"));
            ProductType.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType_Delete, L("DeletingProductType"));

            var Product = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product, L("Product"));
            Product.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Create, L("CreatingNewProduct"));
            Product.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Edit, L("EditingProduct"));
            Product.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Delete, L("DeletingProduct"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
