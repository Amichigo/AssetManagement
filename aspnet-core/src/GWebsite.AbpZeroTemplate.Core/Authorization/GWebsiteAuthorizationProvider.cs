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

            var vehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle, L("Vehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Create, L("CreatingNewVehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Edit, L("EditingVehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Delete, L("DeletingVehicle"));

            var typevehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle, L("TypeVehicle"));
            typevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle_Create, L("CreatingNewTypeVehicle"));
            typevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle_Edit, L("EditingTypeVehicle"));
            typevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle_Delete, L("DeletingTypeVehicle"));


            var modelvehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle, L("ModelVehicle"));
            modelvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle_Create, L("CreatingNewModelVehicle"));
            modelvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle_Edit, L("EditingModelVehicle"));
            modelvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle_Delete, L("DeletingModelVehicle"));

            var ts = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset, L("Asset"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset_Create, L("CreatingNewAsset"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset_Edit, L("EditingAsset"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset_Delete, L("DeletingAsset"));

            var brandvehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle, L("BrandVehicle"));
            brandvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle_Create, L("CreatingNewBrandVehicle"));
            brandvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle_Edit, L("EditingBrandVehicle"));
            brandvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle_Delete, L("DeletingBrandVehicle"));

            var operatevehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle, L("OperateVehicle"));
            operatevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle_Create, L("CreatingNewOperateVehicle"));
            operatevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle_Edit, L("EditingOperateVehicle"));
           operatevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle_Delete, L("DeletingOperateVehicle"));

            var roadfeevehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle, L("RoadFeeVehicle"));
            roadfeevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Create, L("CreatingNewRoadFeeVehicle"));
            roadfeevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Edit, L("EditingRoadFeeVehicle"));
            roadfeevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Delete, L("DeletingRoadFeeVehicle"));


            var insurrance = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance, L("Insurrance"));
            insurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance_Create, L("CreatingNewInsurrance"));
            insurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance_Edit, L("EditingInsurrance"));
            insurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance_Delete, L("DeletingInsurrance"));

            var insurrancetype = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType, L("InsurranceType"));
            insurrancetype.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType_Create, L("CreatingNewInsurranceType"));
            insurrancetype.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType_Edit, L("EditingInsurranceType"));
            insurrancetype.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType_Delete, L("DeletingInsurranceType"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
