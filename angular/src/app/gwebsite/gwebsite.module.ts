import { CustomerServiceProxy, RealEstateServiceProxy, AssetServiceProxy, LandServiceProxy, BuildingServiceProxy, LocationTypeServiceProxy, LegalStatusTypeServiceProxy, RealEstateTypeServiceProxy, RealEstateRepairServiceProxy } from './../../shared/service-proxies/service-proxies';
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
import { RealEstateManagementComponent } from './real-estate-management/real-estate-management.component';
import { CreateOrEditRealEstateModalComponent } from './real-estate-management/create-or-edit-real-estate-management-modal.component';
import { RealEstateTypeComponent } from './real-estate-type/real-estate-type.component';
import { CreateOrEditRealEstateTypeModalComponent } from './real-estate-type/create-or-edit-real-estate-type';
import { LegalStatusTypeComponent } from './legal-status-type/legal-status-type.component';
import { CreateOrEditLegalStatusTypeModalComponent } from './legal-status-type/create-or-edit-legal-status-type';
import { LocationTypeComponent } from './location-type/location-type.component';
import { CreateOrEditLocationTypeModalComponent } from './location-type/create-or-edit-location-type';
import { ViewRealEstateModalComponent } from './real-estate-management/view-real-estate-management-modal.component';
import { AssetComponent } from './real-estate-management/asset-component';
import { RealEstateRepairComponent } from './real-estate-repair/real-estate-repair.component';
import { CreateOrEditRealEstateRepairModalComponent } from './real-estate-repair/create-or-edit-real-estate-repair-modal.component';
import { ViewRealEstateRepairModalComponent } from './real-estate-repair/view-real-estate-repair-modal.component';
import { RealEstateModalComponent } from './real-estate-repair/real-estate-modal';
import { UpdateRealEstateRepairModalComponent } from './real-estate-repair/update-real-estate-repair-modal.component';
import { ApprovedRealEstateRepairModalComponent } from './real-estate-repair/approved-real-estate-repair';

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
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        RealEstateManagementComponent, CreateOrEditRealEstateModalComponent, ViewRealEstateModalComponent, AssetComponent,
        RealEstateTypeComponent, CreateOrEditRealEstateTypeModalComponent,
        LegalStatusTypeComponent, CreateOrEditLegalStatusTypeModalComponent,
        LocationTypeComponent, CreateOrEditLocationTypeModalComponent,
        RealEstateRepairComponent, CreateOrEditRealEstateRepairModalComponent, ViewRealEstateRepairModalComponent,
        RealEstateModalComponent, ApprovedRealEstateRepairModalComponent, UpdateRealEstateRepairModalComponent,
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        RealEstateServiceProxy,
        AssetServiceProxy,
        LandServiceProxy,
        BuildingServiceProxy,
        RealEstateTypeServiceProxy,
        LegalStatusTypeServiceProxy,
        LocationTypeServiceProxy,
        RealEstateRepairServiceProxy
    ]
})
export class GWebsiteModule { }
