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

            var rentalAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset, L("RentalAsset"));
            rentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset_Create, L("CreatingNewRentalAsset"));
            rentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset_Edit, L("EditingRentalAsset"));
            rentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset_Delete, L("DeletingRentalAsset"));

            var typeOfRentalAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfRentalAsset, L("TypeOfRentalAsset"));
            typeOfRentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfRentalAsset_Create, L("CreatingNewTypeOfRentalAsset"));
            typeOfRentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfRentalAsset_Edit, L("EditingTypeOfRentalAsset"));
            typeOfRentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfRentalAsset_Delete, L("DeletingTypeOfRentalAsset"));

            var formOfRentingAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_FormOfRentingAsset, L("FormOfRentingAsset"));
            formOfRentingAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FormOfRentingAsset_Create, L("CreatingNewFormOfRentingAsset"));
            formOfRentingAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FormOfRentingAsset_Edit, L("EditingFormOfRentingAsset"));
            formOfRentingAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FormOfRentingAsset_Delete, L("DeletingFormOfRentingAsset"));

            var assetRentingFile = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingFile, L("AssetRentingFile"));
            assetRentingFile.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingFile_Create, L("CreatingNewAssetRentingFile"));
            assetRentingFile.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingFile_Edit, L("EditingAssetRentingFile"));
            assetRentingFile.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingFile_Delete, L("DeletingAssetRentingFile"));

            var assetRentingContract = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingContract, L("AssetRentingContract"));
            assetRentingContract.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingContract_Create, L("CreatingNewAssetRentingContract"));
            assetRentingContract.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingContract_Edit, L("EditingAssetRentingContract"));
            assetRentingContract.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetRentingContract_Delete, L("DeletingAssetRentingContract"));

        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
