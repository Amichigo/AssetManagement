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

            var asset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset, L("Asset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Create, L("CreatingNewAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Edit, L("EditingAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Delete, L("DeletingAsset"));

            var building = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building, L("Building"));
            building.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building_Create, L("CreatingNewBuilding"));
            building.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building_Edit, L("EditingBuilding"));
            building.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building_Delete, L("DeletingBuilding"));

            var construction = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction, L("Construction"));
            construction.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction_Create, L("CreatingNewConstruction"));
            construction.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction_Edit, L("EditingConstruction"));
            construction.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction_Delete, L("DeletingConstruction"));

            var handover = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Handover, L("Handover"));
            handover.CreateChildPermission(GWebsitePermissions.Pages_Administration_Handover_Create, L("CreatingNewHandover"));
            handover.CreateChildPermission(GWebsitePermissions.Pages_Administration_Handover_Edit, L("EditingHandover"));
            handover.CreateChildPermission(GWebsitePermissions.Pages_Administration_Handover_Delete, L("DeletingHandover"));

            var land = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land, L("Land"));
            land.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land_Create, L("CreatingNewLand"));
            land.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land_Edit, L("EditingLand"));
            land.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land_Delete, L("DeletingLand"));

            var realestate = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate, L("RealEstate"));
            realestate.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate_Create, L("CreatingNewRealEstate"));
            realestate.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate_Edit, L("EditingRealEstate"));
            realestate.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate_Delete, L("DeletingRealEstate"));

            var revoke = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Revoke, L("Revoke"));
            revoke.CreateChildPermission(GWebsitePermissions.Pages_Administration_Revoke_Create, L("CreatingNewRevoke"));
            revoke.CreateChildPermission(GWebsitePermissions.Pages_Administration_Revoke_Edit, L("EditingRevoke"));
            revoke.CreateChildPermission(GWebsitePermissions.Pages_Administration_Revoke_Delete, L("DeletingRevoke"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
