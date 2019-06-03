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

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            var categoryType = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General, L("CategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Create, L("CreatingNewCategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Edit, L("EditingCategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Delete, L("DeletingCategoryType"));

            var category = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Categories_General, L("Category"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Create, L("CreatingNewCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Edit, L("EditingCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Delete, L("DeletingCategory"));

            var orderPackages = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage, L("OrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Create, L("CreatingNewOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Edit, L("EditingOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Delete, L("DeletingOrderPackage"));

            var videoInstructions = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction, L("VideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Create, L("CreatingNewVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Edit, L("EditingVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Delete, L("DeletingVideoInstruction"));

            var VideoInstructionCategories = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory, L("VideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Create, L("CreatingNewVVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Edit, L("EditingVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Delete, L("DeletingVideoInstructionCategory"));
            ///project
            var duan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project, L("Project"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Create, L("CreatingNewProject"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Edit, L("EditingProject"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Delete, L("DeletingProject"));

            ///bid
            var thau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid, L("Bid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Create, L("CreatingNewBid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Edit, L("EditingBid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Delete, L("DeletingBid"));

            ///supplier
            var nhacungcap = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier, L("Supplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Create, L("CreatingNewSupplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Edit, L("EditingSupplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Delete, L("DeletingSupplier"));

            ///contract
            var hopdongthau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract, L("Contract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Create, L("CreatingNewContract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Edit, L("EditingContract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Delete, L("DeletingContract"));

            ///goodsInvoice
            var phieugoihang = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice, L("GoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Create, L("CreatingNewGoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Edit, L("EditingGoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Delete, L("DeletingGoodsInvoice"));

            ///goods
            var hanghoa = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods, L("Goods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Create, L("CreatingNewGoods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Edit, L("EditingGoods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Delete, L("DeletingGoods"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
