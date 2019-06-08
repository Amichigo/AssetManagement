﻿using Abp.Authorization;
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

            var typeOfAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfAsset, L("TypeOfAsset"));
            typeOfAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfAsset_Create, L("CreatingNewTypeOfAsset"));
            typeOfAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfAsset_Edit, L("EditingTypeOfAsset"));
            typeOfAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeOfAsset_Delete, L("DeletingTypeOfAsset"));

            var assetGroup = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup, L("AssetGroup"));
            assetGroup.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_Create, L("CreatingNewAssetGroup"));
            assetGroup.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_Edit, L("EditingAssetGroup"));
            assetGroup.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_Delete, L("DeletingAssetGroup"));

            var asset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset, L("Asset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Create, L("CreatingNewAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Edit, L("EditingAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Delete, L("DeletingAsset"));

            var rentalAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset, L("RentalAsset"));
            rentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset_Create, L("CreatingNewRentalAsset"));
            rentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset_Edit, L("EditingRentalAsset"));
            rentalAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_RentalAsset_Delete, L("DeletingRentalAsset"));

        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
