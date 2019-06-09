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

            var assetActivity = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity, L("AssetActivity"));
            assetActivity.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity_Create, L("CreatingNewAssetActivity"));
            assetActivity.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity_Edit, L("EditingAssetActivity"));
            assetActivity.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity_Delete, L("DeletingAssetActivity"));

            var purchasedAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PurchasedAsset, L("PurchasedAsset"));
            purchasedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PurchasedAsset_Create, L("CreatingNewPurchasedAsset"));
            purchasedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PurchasedAsset_Edit, L("EditingPurchasedAsset"));
            purchasedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PurchasedAsset_Delete, L("DeletingPurchasedAsset"));

            var plannedToPurchaseAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToPurchaseAsset, L("PlannedToPurchaseAsset"));
            plannedToPurchaseAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToPurchaseAsset_Create, L("CreatingNewPlannedToPurchaseAsset"));
            plannedToPurchaseAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToPurchaseAsset_Edit, L("EditingPlannedToPurchaseAsset"));
            plannedToPurchaseAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToPurchaseAsset_Delete, L("DeletingPlannedToPurchaseAsset"));

            var operatingAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperatingAsset, L("OperatingAsset"));
            operatingAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperatingAsset_Create, L("CreatingNewOperatingAsset"));
            operatingAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperatingAsset_Edit, L("EditingOperatingAsset"));
            operatingAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperatingAsset_Delete, L("DeletingOperatingAsset"));

            var maintainedAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MaintainedAsset, L("MaintainedAsset"));
            maintainedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_MaintainedAsset_Create, L("CreatingNewMaintainedAsset"));
            maintainedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_MaintainedAsset_Edit, L("EditingMaintainedAsset"));
            maintainedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_MaintainedAsset_Delete, L("DeletingMaintainedAsset"));

            var plannedToMaintainAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToMaintainAsset, L("PlannedToMaintainAsset"));
            plannedToMaintainAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToMaintainAsset_Create, L("CreatingNewPlannedToMaintainAsset"));
            plannedToMaintainAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToMaintainAsset_Edit, L("EditingPlannedToMaintainAsset"));
            plannedToMaintainAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToMaintainAsset_Delete, L("DeletingPlannedToMaintainAsset"));

            var soldAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_SoldAsset, L("SoldAsset"));
            soldAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_SoldAsset_Create, L("CreatingNewSoldAsset"));
            soldAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_SoldAsset_Edit, L("EditingSoldAsset"));
            soldAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_SoldAsset_Delete, L("DeletingSoldAsset"));

            var plannedToSellAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToSellAsset, L("PlannedToSellAsset"));
            plannedToSellAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToSellAsset_Create, L("CreatingNewPlannedToSellAsset"));
            plannedToSellAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToSellAsset_Edit, L("EditingPlannedToSellAsset"));
            plannedToSellAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_PlannedToSellAsset_Delete, L("DeletingPlannedToSellAsset"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
