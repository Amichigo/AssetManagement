import { CustomerServiceProxy, LoaiNhaCungCapServiceProxy, NhaCungCapHangHoaServiceProxy, ProductTypeServiceProxy, ProductServiceProxy } from './../../shared/service-proxies/service-proxies';
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
import { ExcelService } from './services/excel.service';

import { MenuClientComponent, CreateOrEditMenuClientModalComponent } from './index';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { LoaiNhaCungCapComponent } from './LoaiNhaCungCap/LoaiNhaCungCap.component';
import { ViewLoaiNhaCungCapModalComponent } from './LoaiNhaCungCap/view-LoaiNhaCungCap-modal.component';
import { CreateOrEditLoaiNhaCungCapModalComponent } from './LoaiNhaCungCap/create-or-edit-LoaiNhaCungCap-modal.component';
import { NhaCungCapHangHoaComponent } from './NhaCungCapHangHoa/NhaCungCapHangHoa.component';
import { CreateOrEditNhaCungCapHangHoaModalComponent } from './NhaCungCapHangHoa/create-or-edit-NhaCungCapHangHoa-modal.component';
import { ViewNhaCungCapHangHoaModalComponent } from './NhaCungCapHangHoa/view-NhaCungCapHangHoa-modal.component';
import { ProductComponent } from './Product/Product.component';
import { CreateOrEditProductModalComponent } from './Product/create-or-edit-Product-modal.component';
import { ViewProductModalComponent } from './Product/view-Product-modal.component';
import { ProductTypeComponent } from './ProductType/ProductType.component';
import { ViewProductTypeModalComponent } from './ProductType/view-ProductType-modal.component';
import { CreateOrEditProductTypeModalComponent } from './ProductType/create-or-edit-ProductType-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import {NgxPaginationModule} from 'ngx-pagination';
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
        NgxPaginationModule
    ],
    declarations: [
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        LoaiNhaCungCapComponent, CreateOrEditLoaiNhaCungCapModalComponent, ViewLoaiNhaCungCapModalComponent,
        ProductComponent,CreateOrEditProductModalComponent,ViewProductModalComponent,
        ProductTypeComponent,CreateOrEditProductTypeModalComponent,ViewProductTypeModalComponent,
        NhaCungCapHangHoaComponent, CreateOrEditNhaCungCapHangHoaModalComponent, ViewNhaCungCapHangHoaModalComponent
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        LoaiNhaCungCapServiceProxy,
        NhaCungCapHangHoaServiceProxy,
        ProductServiceProxy,
        ProductTypeServiceProxy,
        ExcelService,
        WebApiServiceProxy
    ]
})
export class GWebsiteModule { }
