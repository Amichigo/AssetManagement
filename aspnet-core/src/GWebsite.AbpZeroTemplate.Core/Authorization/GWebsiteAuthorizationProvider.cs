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

            var realestate_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9, L("RealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Create, L("CreatingNewRealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Edit, L("EditingRealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Delete, L("DeletingRealEstate"));


            var asset_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9, L("Asset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Create, L("CreatingNewAsset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Edit, L("EditingAsset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Delete, L("DeletingAsset"));

            var realestatetype_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9, L("RealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Create, L("CreatingNewRealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Edit, L("EditingRealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Delete, L("DeletingRealEstateType9"));

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
