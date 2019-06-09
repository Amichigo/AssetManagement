import { CustomerServiceProxy, TypeOfAssetServiceProxy, AssetGroupServiceProxy, AssetServiceProxy, RentalAssetServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ViewDemoModelModalComponent } from './demo-model/view-demo-model-modal.component';
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

import { MenuClientComponent, CreateOrEditMenuClientModalComponent } from './index';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { TypeOfAssetComponent } from './type-of-asset/type-of-asset.component'
import { CreateOrEditTypeOfAssetModalComponent } from './type-of-asset/create-or-edit-type-of-asset-modal.component';
import { ViewTypeOfAssetModalComponent } from './type-of-asset/view-type-of-asset-modal.component';
import { AssetGroup7Component } from './asset-group/asset-group-7.component'
import { CreateOrEditAssetGroupModalComponent } from './asset-group/create-or-edit-asset-group-modal.component';
import { ViewAssetGroupModalComponent } from './asset-group/view-asset-group-modal.component';
import { Asset7Component } from './asset/asset7.component'
import { CreateOrEditAssetModalComponent } from './asset/create-or-edit-asset-modal.component';
import { ViewAssetModalComponent } from './asset/view-asset-modal.component';
import { SelectAssetModalComponent } from './asset/select-asset-modal.component';
import { RentalAssetComponent } from './rental-asset/rental-asset.component'
import { CreateOrEditRentalAssetModalComponent } from './rental-asset/create-or-edit-rental-asset-modal.component';
import { ViewRentalAssetModalComponent } from './rental-asset/view-rental-asset-modal.component';
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
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        TypeOfAssetComponent, CreateOrEditTypeOfAssetModalComponent, ViewTypeOfAssetModalComponent,
        AssetGroup7Component, CreateOrEditAssetGroupModalComponent, ViewAssetGroupModalComponent,
        Asset7Component, CreateOrEditAssetModalComponent, ViewAssetModalComponent, SelectAssetModalComponent,
        RentalAssetComponent, CreateOrEditRentalAssetModalComponent, ViewRentalAssetModalComponent,
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        TypeOfAssetServiceProxy,
        AssetGroupServiceProxy,
        AssetServiceProxy,
        RentalAssetServiceProxy,
    ]
})
export class GWebsiteModule { }
