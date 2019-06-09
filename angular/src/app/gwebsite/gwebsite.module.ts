import {
    CustomerServiceProxy, FixedAssetServiceProxy, AssetDashboardServiceProxy,
    AssetGroupController_05ServiceProxy, AssetController_05ServiceProxy, TransferringAssetServiceProxy, ExportingUsedAssetServiceProxy
} from './../../shared/service-proxies/service-proxies';
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
import { TransferringAssetComponent } from './transferring-asset/transferring-asset.component';
import { ViewTransferringAssetModalComponent } from './transferring-asset/view-transferring-asset-modal.component';
import { CreateOrEditTransferringAssetModalComponent } from './transferring-asset/create-or-edit-transferring-asset-modal.component';
import { SearchAssetComponent } from './transferring-asset/search-asset.component';
import { SearchUnitComponent } from './transferring-asset/search-unit.component';
import { SearchUserComponent } from './transferring-asset/search-user.component';
import { ExportingUsedAssetComponent } from './exporting-used-asset/exporting-used-asset.component';
import { SearchAssetComponent2 } from './exporting-used-asset/search-asset.component';
import { CreateOrEditExportingUsedAssetModalComponent } from './exporting-used-asset/create-or-edit-exporting-used-asset-modal.component';
import { ViewExportingUsedAssetModalComponent } from './exporting-used-asset/view-exporting-used-asset-modal.component';

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
        FixedAssetComponent, CreateOrEditFixedAssetModalComponent, ViewFixedAssetModalComponent,
        AssetDashboardComponent,
        AssetGroupComponent, CreateOrEditAssetGroupModalComponent, ViewAssetGroupModalComponent,
        AssetComponent, CreateOrEditAssetModalComponent, ViewAssetModalComponent, TransferringAssetComponent, CreateOrEditTransferringAssetModalComponent, ViewTransferringAssetModalComponent,
        SearchAssetComponent, SearchUnitComponent, SearchUserComponent,
        SearchAssetComponent2, ExportingUsedAssetComponent, CreateOrEditExportingUsedAssetModalComponent,
        ViewExportingUsedAssetModalComponent, 

    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        FixedAssetServiceProxy,
        AssetDashboardServiceProxy,
        AssetGroupController_05ServiceProxy,
        AssetController_05ServiceProxy,
        TransferringAssetServiceProxy,
        ExportingUsedAssetServiceProxy
    ]
})
export class GWebsiteModule { }
