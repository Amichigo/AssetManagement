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

            var fixedAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset, L("FixedAsset"));
            fixedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset_Create, L("CreatingNewFixedAsset"));
            fixedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset_Edit, L("EditingFixedAsset"));
            fixedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset_Delete, L("DeletingFixedAsset"));

            var assetDashboard = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetDashboard, L("AssetDashboard"));

            var Asset_05 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05, L("Asset_05"));
            Asset_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05_Create, L("CreatingNewAsset_05"));
            Asset_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05_Edit, L("EditingAsset_05"));
            Asset_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05_Delete, L("DeletingAsset_05"));

            var AssetType_05 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetType_05, L("AssetType_05"));

            var AssetGroup_05 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05, L("AssetGroup_05"));
            AssetGroup_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05_Create, L("CreatingNewAssetGroup_05"));
            AssetGroup_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05_Edit, L("EditingAssetGroup_05"));
            AssetGroup_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05_Delete, L("DeletingAssetGroup_05"));

            var transferringAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset, L("TransferringAsset"));
            transferringAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset_Create, L("CreatingNewTransferringAsset"));
            transferringAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset_Edit, L("EditingTransferringAsset"));
            transferringAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset_Delete, L("DeletingTransferringAsset"));

            var exportingUsedAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset, L("ExportingUsedAsset"));
            exportingUsedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Create, L("CreatingNewExportingUsedAsset"));
            exportingUsedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Edit, L("EditingExportingUsedAsset"));
            exportingUsedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Delete, L("DeletingExportingUsedAsset"));

            var warranty = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Warranty_05, L("Warranty"));

            var purchaseOrder = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PurchaseOrder_05, L("PurchaseOrder"));


        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
