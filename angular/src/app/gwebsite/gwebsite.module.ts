import { CustomerServiceProxy, ConstructionPlanDetailServiceProxy, DisposalPlanServiceProxy, DisposalPlanDetailServiceProxy} from './../../shared/service-proxies/service-proxies';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { GWebsiteRoutingModule } from './gwebsite-routing.module';

import {
    CategoryComponent, ViewCategoryModalComponent, CreateOrEditCategoryModalComponent,
    CategoryTypeComponent, CreateOrEditTypeModalComponent, ViewCategoryTypeModalComponent,
    DuAnComponent, ViewDuAnModalComponent, CreateOrEditDuAnModalComponent,
    HoSoThauComponent, ViewHoSoThauModalComponent, CreateOrEditHoSoThauModalComponent,
    NhaCungCapComponent, ViewNhaCungCapModalComponent, CreateOrEditNhaCungCapModalComponent,
    HopDongThauComponent, ViewHopDongThauModalComponent, CreateOrEditHopDongThauModalComponent,
    PhieuGoiHangComponent, ViewPhieuGoiHangModalComponent, CreateOrEditPhieuGoiHangModalComponent,
    HangHoaComponent, ViewHangHoaModalComponent, CreateOrEditHangHoaModalComponent,
    DirectorShoppingPlanComponent, ViewDirectorShoppingPlanModalComponent, CreateOrEditDirectorShoppingPlanModalComponent,
} from './index';

import { CategoryServiceProxy, CategoryTypeServiceProxy,
    ProjectServiceProxy, BidServiceProxy, SupplierServiceProxy, ContractServiceProxy, GoodsInvoiceServiceProxy, GoodsServiceProxy,
    ShoppingPlanServiceProxy, DirectorShoppingPlanServiceProxy, ShoppingPlanDetailServiceProxy, ConstructionPlanServiceProxy,
    LoaiBatDongSanServiceProxy, NhomTaiSanServiceProxy, LoaiSoHuuServiceProxy, MucDichSuDungDatServiceProxy, BatDongSanServiceProxy,
    HienTrangPhapLyServiceProxy, TinhTrangSuDungDatServiceProxy, TaiSanServiceProxy, SuaChuaBatDongSanServiceProxy, KeHoachXayDungServiceProxy, CongTrinhServiceProxy, HoSoThauN13ServiceProxy,
    ComputerServiceProxy, SoftwareServiceProxy, FixedAssetServiceProxy, AssetDashboardServiceProxy,
    AssetGroupController_05ServiceProxy, AssetController_05ServiceProxy,
    RealEstateServiceProxy, AssetServiceProxy, RealEstateTypeServiceProxy, RealEstateRepairServiceProxy
} from '@shared/service-proxies/service-proxies';

import { LoaiBatDongSanComponent } from './loaibatdongsan/loaibatdongsan.component';
import { CreateOrEditLoaiBatDongSanModalComponent } from './loaibatdongsan/create-or-edit-loaibatdongsan-modal.component';
import { ViewLoaiBatDongSanModalComponent } from './loaibatdongsan/view-loaibatdongsan-modal.component';
import { LoaiSoHuuComponent } from './loaisohuu/loaisohuu.component';
import { CreateOrEditLoaiSoHuuModalComponent } from './loaisohuu/create-or-edit-loaisohuu-modal.component';
import { ViewLoaiSoHuuModalComponent } from './loaisohuu/view-loaisohuu-modal.component';
import { BatDongSanComponent } from './batdongsan/batdongsan.component';
import { CreateOrEditBatDongSanModalComponent } from './batdongsan/create-or-edit-batdongsan-modal.component';
import { ViewBatDongSanModalComponent } from './batdongsan/view-batdongsan-modal.component';
import { HienTrangPhapLyComponent } from './hientrangphaply/hientrangphaply.component';
import { ViewHienTrangPhapLyModalComponent } from './hientrangphaply/view-hientrangphaply-modal.component';
import { TinhTrangSuDungDatComponent } from './tinhtrangsudungdat/tinhtrangsudungdat.component';
import { CreateOrEditTinhTrangSuDungDatModalComponent } from './tinhtrangsudungdat/create-or-edit-tinhtrangsudungdat-modal.component';
import { ViewTinhTrangSuDungDatModalComponent } from './tinhtrangsudungdat/view-tinhtrangsudungdat-modal.component';
import { TaiSanComponent } from './taisan/taisan.component';
import { ViewTaiSanModalComponent } from './taisan/view-taisan-modal.component';
import { CreateOrEditTaiSanModalComponent } from './taisan/create-or-edit-taisan-modal.component';
import { SelectTaiSanModalComponent } from './taisan/select-taisan-modal.component';
import { SuaChuaBatDongSanComponent } from './suachuabatdongsan/suachuabatdongsan.component';
import { CreateOrEditSuaChuaBatDongSanModalComponent } from './suachuabatdongsan/createSuachuabatdongsan-modal.component';
import { ViewSuaChuaBatDongSanModalComponent } from './suachuabatdongsan/view-suachuabatdongsan-modal.component';
import { KeHoachXayDungComponent } from './kehoachxaydung/kehoachxaydung.component';
import { CreateOrEditKeHoachXayDungModalComponent } from './kehoachxaydung/create-or-edit-kehoachxaydung-modal.component';
import { ViewKeHoachXayDungModalComponent } from './kehoachxaydung/view-kehoachxaydung-modal.component';
import { EditSuaChuaBatDongSanModalComponent } from './suachuabatdongsan/edit-suachuabatdongsan-modal.component';
import { DuyetBatDongSanModalComponent } from './suachuabatdongsan/duyet-suachuabatdongsan-modal.component';
import { CongTrinhComponent } from './congtrinhN13/congtrinh.component';
import { CreateOrEditCongTrinhModalComponent } from './congtrinhN13/create-or-edit-congtrinh-modal.component';
import { ViewCongTrinhModalComponent } from './congtrinhN13/view-congtrinh-modal.component';
import { SelectKeHoachXayDungModalComponent } from './kehoachxaydung/select-kehoachxaydung-modal.component';
import { SelectCongTrinhModalComponent } from './congtrinhN13/select-congtrinh-modal.component';
import { SelectKHCongTrinhModalComponent } from './kehoachxaydung/select-khcongtrinh-modal.component';
import { CreateCongTrinhModalComponent } from './congtrinhN13/create-congtrinh-modal.component';
import { HoSoThauN13Component } from './hosothauN13/hosothaun13.component';
import { CreateHoSoThauN13ModalComponent } from './hosothauN13/create-hosothau13-modal.component';

import { ComputerComponent } from './computer/computer.component';
import { CreateOrEditComputerModalComponent } from './computer/create-or-edit-computer-modal.component';
import { ViewComputerModalComponent } from './computer/view-computer-modal.component';
import { SoftwareComponent } from './software/software.component';
import { CreateOrEditSoftwareModalComponent } from './software/create-or-edit-software-modal.component';
import { ViewSoftwareModalComponent } from './software/view-software-modal.component';
import { FixedAssetComponent } from './fixed-asset/fixed-asset.component'
import { CreateOrEditFixedAssetModalComponent } from './fixed-asset/create-or-edit-fixed-asset-modal.component';
import { ViewFixedAssetModalComponent } from './fixed-asset/view-fixed-asset-modal.component';
import { AssetDashboardComponent } from './asset-dashboard/asset-dashboard.component';
import { AssetGroupComponent } from './asset-group/asset-group.component';
import { ViewAssetGroupModalComponent } from './asset-group/view-asset-group-modal.component';
import { CreateOrEditAssetGroupModalComponent } from './asset-group/create-or-edit-asset-group-modal.component';
import { CreateOrEditAssetModalComponent } from './asset/create-or-edit-asset-modal.component';
import { AssetComponent } from './asset/asset.component';
import { ViewAssetModalComponent } from './asset/view-asset-modal.component';

import { CreateOrEditRealEstateModalComponent } from './real-estate-management/create-or-edit-real-estate-management-modal.component';
import { RealEstateManagementComponent } from './real-estate-management/real-estate-management.component';
import { RealEstateTypeComponent } from './real-estate-type/real-estate-type.component';
import { CreateOrEditRealEstateTypeModalComponent } from './real-estate-type/create-or-edit-real-estate-type';
import { ViewRealEstateModalComponent } from './real-estate-management/view-real-estate-management-modal.component';
import { AssetComponent9 } from './real-estate-management/asset-component';
import { ViewRealEstateRepairModalComponent } from './real-estate-repair/view-real-estate-repair-modal.component';
import { CreateOrEditRealEstateRepairModalComponent } from './real-estate-repair/create-or-edit-real-estate-repair-modal.component';
import { RealEstateRepairComponent } from './real-estate-repair/real-estate-repair.component';
import { RealEstateModalComponent } from './real-estate-repair/real-estate-modal';
import { ApprovedRealEstateRepairModalComponent } from './real-estate-repair/approved-real-estate-repair';
import { UpdateRealEstateRepairModalComponent } from './real-estate-repair/update-real-estate-repair-modal.component';

import {
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
} from '@angular/material';

import { AssetActivityServiceProxy } from '@shared/service-proxies/service-proxies';
import { PurchasedAssetsComponent } from './asset-investment-efficiency/pages/purchased-assets/purchased-assets.component';
import { SoleAssetsComponent } from './asset-investment-efficiency/pages/sole-assets/sole-assets.component';
import { MaintainedAssetsComponent } from './asset-investment-efficiency/pages/maintained-assets/maintained-assets.component';
import { PlannedToSellAssetsComponent } from './asset-investment-efficiency/pages/planned-to-sell-assets/planned-to-sell-assets.component';
import { PlannedToPurchaseAssetsComponent } from './asset-investment-efficiency/pages/planned-to-purchase-assets/planned-to-purchase-assets.component';
import { PlannedToMaintainAssetsComponent } from './asset-investment-efficiency/pages/planned-to-maintain-assets/planned-to-maintain-assets.component';
import { OperatingAssetsComponent } from './asset-investment-efficiency/pages/operating-assets/operating-assets.component';
import { ChartsModule } from 'ng2-charts';

import { ShoppingPlanComponent } from './shoppingPlan/shoppingPlan.component';
import { ViewShoppingPlanModalComponent } from './shoppingPlan/view-shoppingPlan-modal.component';
import { CreateOrEditShoppingPlanModalComponent } from './shoppingPlan/create-or-edit-shoppingPlan-modal.component';

import { ShoppingPlanDetailComponent } from './shoppingPlan/shoppingPlanDetail.component';
import { CreateOrEditShoppingPlanDetailModalComponent } from './shoppingPlan/create-or-edit-shoppingPlanDetail-modal.component';

import { ConstructionPlanComponent } from './constructionPlan/constructionPlan.component';
import { ViewConstructionPlanModalComponent } from './constructionPlan/view-constructionPlan-modal.component';
import { CreateOrEditConstructionPlanModalComponent } from './constructionPlan/create-or-edit-constructionPlan-modal.component';

import { DisposalPlanComponent } from './disposalPlan/disposalPlan.component';
import { ViewDisposalPlanModalComponent } from './disposalPlan/view-disposalPlan-modal.component';
import { CreateOrEditDisposalPlanModalComponent } from './disposalPlan/create-or-edit-disposalPlan-modal.component';

import { DisposalPlanDetailComponent } from './disposalPlan/disposalPlanDetail.component';
import { CreateOrEditDisposalPlanDetailModalComponent } from './disposalPlan/create-or-edit-disposalPlanDetail-modal.component';

import { ConstructionPlanDetailComponent } from './constructionPlan/constructionPlanDetail.component';
import { CreateOrEditConstructionPlanDetailModalComponent } from './constructionPlan/create-or-edit-constructionPlanDetail-modal.component';

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule,
        MatAutocompleteModule,
        MatBadgeModule,
        MatBottomSheetModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatCheckboxModule,
        MatChipsModule,
        MatDatepickerModule,
        MatDialogModule,
        MatDividerModule,
        MatExpansionModule,
        MatGridListModule,
        MatIconModule,
        MatInputModule,
        MatListModule,
        MatMenuModule,
        MatNativeDateModule,
        MatPaginatorModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatRadioModule,
        MatRippleModule,
        MatSelectModule,
        MatSidenavModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        MatSortModule,
        MatStepperModule,
        MatTableModule,
        MatTabsModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTreeModule,
        ChartsModule,
    ],
    declarations: [
        DuAnComponent, CreateOrEditDuAnModalComponent, ViewDuAnModalComponent,
        HoSoThauComponent, CreateOrEditHoSoThauModalComponent, ViewHoSoThauModalComponent,
        NhaCungCapComponent, CreateOrEditNhaCungCapModalComponent, ViewNhaCungCapModalComponent,
        HopDongThauComponent, CreateOrEditHopDongThauModalComponent, ViewHopDongThauModalComponent,
        PhieuGoiHangComponent, CreateOrEditPhieuGoiHangModalComponent, ViewPhieuGoiHangModalComponent,
        HangHoaComponent, CreateOrEditHangHoaModalComponent, ViewHangHoaModalComponent,
        CategoryComponent, ViewCategoryModalComponent, CreateOrEditCategoryModalComponent,
        CategoryTypeComponent, ViewCategoryTypeModalComponent, CreateOrEditTypeModalComponent,
        ShoppingPlanComponent, ViewShoppingPlanModalComponent, CreateOrEditShoppingPlanModalComponent,
        DirectorShoppingPlanComponent, ViewDirectorShoppingPlanModalComponent, CreateOrEditDirectorShoppingPlanModalComponent,
        ShoppingPlanDetailComponent, CreateOrEditShoppingPlanDetailModalComponent,
        ConstructionPlanComponent, ViewConstructionPlanModalComponent, CreateOrEditConstructionPlanModalComponent,
        LoaiBatDongSanComponent, CreateOrEditLoaiBatDongSanModalComponent, ViewLoaiBatDongSanModalComponent,
        LoaiSoHuuComponent, CreateOrEditLoaiSoHuuModalComponent, ViewLoaiSoHuuModalComponent,
        BatDongSanComponent, CreateOrEditBatDongSanModalComponent, ViewBatDongSanModalComponent,
        HienTrangPhapLyComponent, ViewHienTrangPhapLyModalComponent,
        TinhTrangSuDungDatComponent, CreateOrEditTinhTrangSuDungDatModalComponent, ViewTinhTrangSuDungDatModalComponent,
        TaiSanComponent, CreateOrEditTaiSanModalComponent, ViewTaiSanModalComponent, SelectTaiSanModalComponent,
        SuaChuaBatDongSanComponent, CreateOrEditSuaChuaBatDongSanModalComponent, ViewSuaChuaBatDongSanModalComponent, EditSuaChuaBatDongSanModalComponent, DuyetBatDongSanModalComponent,
        KeHoachXayDungComponent, CreateOrEditKeHoachXayDungModalComponent, ViewKeHoachXayDungModalComponent, SelectKHCongTrinhModalComponent,
        CongTrinhComponent, CreateOrEditCongTrinhModalComponent, ViewCongTrinhModalComponent, SelectKeHoachXayDungModalComponent,
        CreateCongTrinhModalComponent, HoSoThauN13Component, CreateHoSoThauN13ModalComponent,
        ComputerComponent, CreateOrEditComputerModalComponent, ViewComputerModalComponent,
        SoftwareComponent, CreateOrEditSoftwareModalComponent, ViewSoftwareModalComponent,
        FixedAssetComponent, CreateOrEditFixedAssetModalComponent, ViewFixedAssetModalComponent,
        AssetDashboardComponent,
        AssetGroupComponent, CreateOrEditAssetGroupModalComponent, ViewAssetGroupModalComponent,
        AssetComponent, CreateOrEditAssetModalComponent, ViewAssetModalComponent,
        PurchasedAssetsComponent, SoleAssetsComponent, MaintainedAssetsComponent, PlannedToSellAssetsComponent, OperatingAssetsComponent,
        PlannedToPurchaseAssetsComponent, PlannedToMaintainAssetsComponent,
        RealEstateManagementComponent, CreateOrEditRealEstateModalComponent, ViewRealEstateModalComponent, AssetComponent9,
        RealEstateTypeComponent, CreateOrEditRealEstateTypeModalComponent,
        RealEstateRepairComponent, CreateOrEditRealEstateRepairModalComponent, ViewRealEstateRepairModalComponent,
        RealEstateModalComponent, ApprovedRealEstateRepairModalComponent, UpdateRealEstateRepairModalComponent,
        ShoppingPlanComponent, ViewShoppingPlanModalComponent, CreateOrEditShoppingPlanModalComponent,
        ShoppingPlanDetailComponent, CreateOrEditShoppingPlanDetailModalComponent,
        ConstructionPlanComponent, ViewConstructionPlanModalComponent, CreateOrEditConstructionPlanModalComponent,
        DisposalPlanComponent, ViewDisposalPlanModalComponent, CreateOrEditDisposalPlanModalComponent,
        DisposalPlanDetailComponent, CreateOrEditDisposalPlanDetailModalComponent,
        ConstructionPlanDetailComponent, CreateOrEditConstructionPlanDetailModalComponent,
    ],
    providers: [
        CategoryServiceProxy,
        CategoryTypeServiceProxy,
        ProjectServiceProxy,
        BidServiceProxy,
        SupplierServiceProxy,
        ContractServiceProxy,
        GoodsInvoiceServiceProxy,
        GoodsServiceProxy,
        ShoppingPlanServiceProxy,
        DirectorShoppingPlanServiceProxy,
        ShoppingPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        LoaiBatDongSanServiceProxy,
        LoaiSoHuuServiceProxy,
        MucDichSuDungDatServiceProxy,
        BatDongSanServiceProxy,
        HienTrangPhapLyServiceProxy,
        TinhTrangSuDungDatServiceProxy,
        TaiSanServiceProxy,
        SuaChuaBatDongSanServiceProxy,
        KeHoachXayDungServiceProxy,
        CongTrinhServiceProxy,
        HoSoThauN13ServiceProxy,
        ComputerServiceProxy,
        SoftwareServiceProxy,
        FixedAssetServiceProxy,
        AssetDashboardServiceProxy,
        AssetGroupController_05ServiceProxy,
        AssetController_05ServiceProxy,
        AssetActivityServiceProxy,
        RealEstateServiceProxy,
        AssetServiceProxy,
        RealEstateTypeServiceProxy,
        RealEstateRepairServiceProxy,
        CustomerServiceProxy,
        ShoppingPlanServiceProxy,
        ShoppingPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        ConstructionPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        DisposalPlanServiceProxy,
        DisposalPlanDetailServiceProxy
    ]
})
export class GWebsiteModule { }
