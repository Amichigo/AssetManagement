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

            var shoppingPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan, L("ShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Create, L("CreatingNewShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Edit, L("EditingShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Delete, L("DeletingShoppingPlan"));

            var shoppingPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail, L("ShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Create, L("CreatingNewShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Edit, L("EditingShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Delete, L("DeletingShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Check, L("CheckingShoppingPlanDetail"));


            var constructionPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan, L("ConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Create, L("CreatingNewConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Edit, L("EditingConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Delete, L("DeletingConstructionPlan"));

            var constructionPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail, L("ConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Create, L("CreatingNewConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Edit, L("EditingConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Delete, L("DeletingConstructionPlanDetail"));

            var disposalPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan, L("DisposalPlan"));
            disposalPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan_Create, L("CreatingNewDisposalPlan"));
            disposalPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan_Edit, L("EditingDisposalPlan"));
            disposalPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan_Delete, L("DeletingDisposalPlan"));

            var disposalPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail, L("DisposalPlanDetail"));
            disposalPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail_Create, L("CreatingNewDisposalPlanDetail"));
            disposalPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail_Edit, L("EditingDisposalPlanDetail"));
            disposalPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail_Delete, L("DeletingDisposalPlanDetail"));

            var disposalProduct = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalProduct, L("DisposalProduct"));
            disposalProduct.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalProduct_Create, L("CreatingNewDisposalProduct"));
            disposalProduct.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalProduct_Edit, L("EditingDisposalProduct"));
            disposalProduct.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalProduct_Delete, L("DeletingDisposalProduct"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
