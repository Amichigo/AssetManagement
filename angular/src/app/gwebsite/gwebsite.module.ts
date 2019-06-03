import { CustomerServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { VehicleServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { TypeVehicleServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { BrandVehicleServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { ModelVehicleServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { OperateVehicleServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { AssetServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { ViewDemoModelModalComponent } from "./demo-model/view-demo-model-modal.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AppCommonModule } from "@app/shared/common/app-common.module";
import { UtilsModule } from "@shared/utils/utils.module";
import { FileUploadModule } from "ng2-file-upload";
import {
    ModalModule,
    PopoverModule,
    TabsModule,
    TooltipModule
} from "ngx-bootstrap";
import {
    AutoCompleteModule,
    EditorModule,
    FileUploadModule as PrimeNgFileUploadModule,
    InputMaskModule,
    PaginatorModule
} from "primeng/primeng";
import { TableModule } from "primeng/table";
import { GWebsiteRoutingModule } from "./gwebsite-routing.module";

import {
    MenuClientComponent,
    CreateOrEditMenuClientModalComponent
} from "./index";
import { DemoModelComponent } from "./demo-model/demo-model.component";
import { CreateOrEditDemoModelModalComponent } from "./demo-model/create-or-edit-demo-model-modal.component";
import { DemoModelServiceProxy } from "@shared/service-proxies/service-proxies";
import { CustomerComponent } from "./customer/customer.component";
import { ViewCustomerModalComponent } from "./customer/view-customer-modal.component";
import { CreateOrEditCustomerModalComponent } from "./customer/create-or-edit-customer-modal.component";

import { VehicleComponent } from "./vehicle/vehicle.component";
import { ViewVehicleModalComponent } from "./vehicle/view-vehicle-modal.componenent";
import { CreateOrEditVehicleModalComponent } from "./vehicle/create-or-edit-vehicle-modal.components";

import { ModelVehicleComponent } from "./modelvehicle/modelvehicle.component";
import { ViewModelVehicleModalComponent } from "./modelvehicle/view-modelvehicle-modal.component";
import { CreateOrEditModelVehicleModalComponent } from "./modelvehicle/create-or-edit-modelvehicle-modal.component";

import { TypeVehicleComponent } from "./typevehicle/typevehicle.component";
import { ViewTypeVehicleModalComponent } from "./typevehicle/view-typevehicle-modal.componenent";
import { CreateOrEditTypeVehicleModalComponent } from "./typevehicle/create-or-edit-typevehicle-modal.components";

import { AssetComponent } from "./asset/asset.component";
import { ViewAssetModalComponent } from "./asset/view-asset-modal.component";
import { CreateOrEditAssetModalComponent } from "./asset/create-or-edit-asset-modal.component";
import { SelectAssetModalComponent } from "./asset/select-asset-modal.component";

import { BrandVehicleComponent } from "./brandvehicle/brandvehicle.component";
import { ViewBrandVehicleModalComponent } from "./brandvehicle/view-brandvehicle-modal.component";
import { CreateOrEditBrandVehicleModalComponent } from "./brandvehicle/create-or-edit-brandvehicle-modal.component";

import { OperateVehicleComponent } from "./operatevehicle/operatevehicle.component";
import { ViewOperateVehicleModalComponent } from "./operatevehicle/view-operatevehicle-modal.component";
import { CreateOrEditOperateVehicleModalComponent } from "./operatevehicle/create-or-edit-operatevehicle-modal.component";
import { SelectVehicleModalComponent } from "./vehicle/select-vehicle-modal.component";
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
        MenuClientComponent,
        CreateOrEditMenuClientModalComponent,
        DemoModelComponent,
        CreateOrEditDemoModelModalComponent,
        ViewDemoModelModalComponent,
        CustomerComponent,
        CreateOrEditCustomerModalComponent,
        ViewCustomerModalComponent,
        VehicleComponent,
        CreateOrEditVehicleModalComponent,
        ViewVehicleModalComponent,
        TypeVehicleComponent,
        CreateOrEditTypeVehicleModalComponent,
        ViewTypeVehicleModalComponent,
        AssetComponent,
        CreateOrEditAssetModalComponent,
        ViewAssetModalComponent,
        SelectAssetModalComponent,
        BrandVehicleComponent,
        CreateOrEditBrandVehicleModalComponent,
        ViewBrandVehicleModalComponent,
        ModelVehicleComponent,
        CreateOrEditModelVehicleModalComponent,
        ViewModelVehicleModalComponent,
        OperateVehicleComponent,
        CreateOrEditOperateVehicleModalComponent,
        ViewOperateVehicleModalComponent,
        SelectVehicleModalComponent
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        VehicleServiceProxy,
        TypeVehicleServiceProxy,
        AssetServiceProxy,
        BrandVehicleServiceProxy,
        ModelVehicleServiceProxy,
        OperateVehicleServiceProxy
    ]
})
export class GWebsiteModule {}
