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
    ShoppingPlanServiceProxy, DirectorShoppingPlanServiceProxy, ShoppingPlanDetailServiceProxy, ConstructionPlanServiceProxy
} from '@shared/service-proxies/service-proxies';


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
        InputMaskModule
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
        ConstructionPlanServiceProxy
    ]
})
export class GWebsiteModule { }
