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

            var realestate_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9, L("RealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Create, L("CreatingNewRealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Edit, L("EditingRealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Delete, L("DeletingRealEstate"));

            var land_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land9, L("Land"));
            land_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land9_Create, L("CreatingNewLand"));
            land_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land9_Edit, L("EditingLand"));
            land_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Land9_Delete, L("DeletingLand"));

            var building_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building9, L("Building"));
            building_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building9_Create, L("CreatingNewBuilding"));
            building_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building9_Edit, L("EditingBuilding"));
            building_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Building9_Delete, L("DeletingBuilding"));

            var asset_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9, L("Asset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Create, L("CreatingNewAsset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Edit, L("EditingAsset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Delete, L("DeletingAsset"));

            var realestatetype_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9, L("RealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Create, L("CreatingNewRealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Edit, L("EditingRealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Delete, L("DeletingRealEstateType9"));

            var legalstatustype_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LegalStatusType9, L("LegalStatusType9"));
            legalstatustype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_LegalStatusType9_Create, L("CreatingNewLegalStatusType9"));
            legalstatustype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_LegalStatusType9_Edit, L("EditingLegalStatusType9"));
            legalstatustype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_LegalStatusType9_Delete, L("DeletingLegalStatusType9"));

            var locationtype_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LocationType9, L("LocationType9"));
            locationtype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_LocationType9_Create, L("CreatingNewLocationType9"));
            locationtype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_LocationType9_Edit, L("EditingLocationType9"));
            locationtype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_LocationType9_Delete, L("DeletingLocationType9"));
            
            var realestaterepair_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9, L("RealEstateRepair9"));
            realestaterepair_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Create, L("CreatingNewRealEstateRepair9"));
            realestaterepair_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Edit, L("EditingRealEstateRepair9"));
            realestaterepair_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Delete, L("DeletingRealEstateRepair9"));

            var bidmanager_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9, L("BidManager9"));
            bidmanager_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9_Create, L("CreatingNewBidManager9"));
            bidmanager_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9_Edit, L("EditingBidManager9"));
            bidmanager_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9_Delete, L("DeletingBidManager9"));

            var construction_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9, L("Construction9"));
            construction_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9_Create, L("CreatingNewConstruction9"));
            construction_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9_Edit, L("EditingConstruction9"));
            construction_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9_Delete, L("DeletingConstruction9"));

            var contractguarantee_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9, L("ContractGuarantee9"));
            contractguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Create, L("CreatingNewContractGuarantee9"));
            contractguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Edit, L("EditingContractGuarantee9"));
            contractguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Delete, L("DeletingContractGuarantee9"));

            var contractmanagement_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9, L("ContractManagement9"));
            contractmanagement_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9_Create, L("CreatingNewContractManagement9"));
            contractmanagement_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9_Edit, L("EditingContractManagement9"));
            contractmanagement_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9_Delete, L("DeletingContractManagement9"));

            var contractor_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9, L("Contractor9"));
            contractor_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9_Create, L("CreatingNewContractor9"));
            contractor_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9_Edit, L("EditingContractor9"));
            contractor_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9_Delete, L("DeletingContractor9"));

            var paymentdetail_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9, L("PaymentDetail9"));
            paymentdetail_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9_Create, L("CreatingNewPaymentDetail9"));
            paymentdetail_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9_Edit, L("EditingPaymentDetail9"));
            paymentdetail_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9_Delete, L("DeletingPaymentDetail9"));

            var plan_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9, L("Plan9"));
            plan_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9_Create, L("CreatingNewPlan9"));
            plan_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9_Edit, L("EditingPlan9"));
            plan_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9_Delete, L("DeletingPlan9"));

            var warrantyguarantee_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9, L("WarrantyGuarantee9"));
            warrantyguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Create, L("CreatingNewWarrantyGuarantee9"));
            warrantyguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Edit, L("EditingWarrantyGuarantee9"));
            warrantyguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Delete, L("DeletingWarrantyGuarantee9"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
