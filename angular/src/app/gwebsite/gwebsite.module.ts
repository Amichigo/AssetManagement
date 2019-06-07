import { CustomerServiceProxy, ShoppingPlanServiceProxy,  ShoppingPlanDetailServiceProxy, ConstructionPlanServiceProxy, 
            DisposalPlanServiceProxy, DisposalPlanDetailServiceProxy } from './../../shared/service-proxies/service-proxies';
import { CustomerServiceProxy, ShoppingPlanServiceProxy,  ShoppingPlanDetailServiceProxy, ConstructionPlanServiceProxy,ConstructionPlanDetailServiceProxy} from './../../shared/service-proxies/service-proxies';
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
        InputMaskModule
    ],
    declarations: [
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        ShoppingPlanComponent, ViewShoppingPlanModalComponent, CreateOrEditShoppingPlanModalComponent,
        ShoppingPlanDetailComponent, CreateOrEditShoppingPlanDetailModalComponent,
        ConstructionPlanComponent, ViewConstructionPlanModalComponent, CreateOrEditConstructionPlanModalComponent,
        DisposalPlanComponent, ViewDisposalPlanModalComponent, CreateOrEditDisposalPlanModalComponent,
        DisposalPlanDetailComponent, CreateOrEditDisposalPlanDetailModalComponent,
        ConstructionPlanDetailComponent, CreateOrEditConstructionPlanDetailModalComponent,
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        ShoppingPlanServiceProxy,
        ShoppingPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        ConstructionPlanDetailServiceProxy
        ConstructionPlanServiceProxy,
        DisposalPlanServiceProxy,
        DisposalPlanDetailServiceProxy
    ]
})
export class GWebsiteModule { }
