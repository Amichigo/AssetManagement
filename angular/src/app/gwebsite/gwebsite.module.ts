import { CustomerServiceProxy, RentalAssetServiceProxy, TypeOfRentalAssetServiceProxy, FormOfRentingAssetServiceProxy, AssetRentingFileServiceProxy, AssetRentingContractServiceProxy } from './../../shared/service-proxies/service-proxies';
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
import { RentalAssetComponent } from './rental-asset/rental-asset.component'
import { CreateOrEditRentalAssetModalComponent } from './rental-asset/create-or-edit-rental-asset-modal.component';
import { ViewRentalAssetModalComponent } from './rental-asset/view-rental-asset-modal.component';
import { TypeOfRentalAssetComponent } from './type-of-rental-asset/type-of-rental-asset.component'
import { CreateOrEditTypeOfRentalAssetModalComponent } from './type-of-rental-asset/create-or-edit-type-of-rental-asset-modal.component';
import { ViewTypeOfRentalAssetModalComponent } from './type-of-rental-asset/view-type-of-rental-asset-modal.component';
import { FormOfRentingAssetComponent } from './form-of-renting-asset/form-of-renting-asset.component'
import { CreateOrEditFormOfRentingAssetModalComponent } from './form-of-renting-asset/create-or-edit-form-of-renting-asset-modal.component';
import { ViewFormOfRentingAssetModalComponent } from './form-of-renting-asset/view-form-of-renting-asset-modal.component';
import { AssetRentingFileComponent } from './asset-renting-file/asset-renting-file.component'
import { CreateOrEditAssetRentingFileModalComponent } from './asset-renting-file/create-or-edit-asset-renting-file-modal.component';
import { ViewAssetRentingFileModalComponent } from './asset-renting-file/view-asset-renting-file-modal.component';
import { AssetRentingContractComponent } from './asset-renting-contract/asset-renting-contract.component'
import { CreateOrEditAssetRentingContractModalComponent } from './asset-renting-contract/create-or-edit-asset-renting-contract-modal.component';
import { ViewAssetRentingContractModalComponent } from './asset-renting-contract/view-asset-renting-contract-modal.component';
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
        RentalAssetComponent, CreateOrEditRentalAssetModalComponent, ViewRentalAssetModalComponent,
        TypeOfRentalAssetComponent, CreateOrEditTypeOfRentalAssetModalComponent, ViewTypeOfRentalAssetModalComponent,
        FormOfRentingAssetComponent, CreateOrEditFormOfRentingAssetModalComponent, ViewFormOfRentingAssetModalComponent,
        AssetRentingFileComponent, CreateOrEditAssetRentingFileModalComponent, ViewAssetRentingFileModalComponent,
        AssetRentingContractComponent, CreateOrEditAssetRentingContractModalComponent, ViewAssetRentingContractModalComponent,
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        RentalAssetServiceProxy,
        TypeOfRentalAssetServiceProxy,
        FormOfRentingAssetServiceProxy,
        AssetRentingFileServiceProxy,
        AssetRentingContractServiceProxy,
    ]
})
export class GWebsiteModule { }
