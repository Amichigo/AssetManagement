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
    ShoppingPlanComponent, ViewShoppingPlanModalComponent, CreateOrEditShoppingPlanModalComponent,
    DirectorShoppingPlanComponent, ViewDirectorShoppingPlanModalComponent, CreateOrEditDirectorShoppingPlanModalComponent,
    ShoppingPlanDetailComponent, CreateOrEditShoppingPlanDetailModalComponent,
    ConstructionPlanComponent, ViewConstructionPlanModalComponent, CreateOrEditConstructionPlanModalComponent
} from './index';

import { CategoryServiceProxy, CategoryTypeServiceProxy,
    ProjectServiceProxy, BidServiceProxy, SupplierServiceProxy, ContractServiceProxy, GoodsInvoiceServiceProxy, GoodsServiceProxy,
    ShoppingPlanServiceProxy, DirectorShoppingPlanServiceProxy, ShoppingPlanDetailServiceProxy, ConstructionPlanServiceProxy,
    LoaiBatDongSanServiceProxy, NhomTaiSanServiceProxy, LoaiSoHuuServiceProxy, MucDichSuDungDatServiceProxy, BatDongSanServiceProxy,
    HienTrangPhapLyServiceProxy, TinhTrangSuDungDatServiceProxy, TaiSanServiceProxy, SuaChuaBatDongSanServiceProxy, KeHoachXayDungServiceProxy, CongTrinhServiceProxy, HoSoThauN13ServiceProxy,
    ComputerServiceProxy, SoftwareServiceProxy, FixedAssetServiceProxy, AssetDashboardServiceProxy,
    AssetGroupController_05ServiceProxy, AssetController_05ServiceProxy 
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
        AssetComponent, CreateOrEditAssetModalComponent, ViewAssetModalComponent
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
        AssetController_05ServiceProxy
    ]
})
export class GWebsiteModule { }
