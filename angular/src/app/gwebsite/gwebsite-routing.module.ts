import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { RealEstateManagementComponent } from './real-estate-management/real-estate-management.component';
import { RealEstateTypeComponent } from './real-estate-type/real-estate-type.component';
import { RealEstateRepairComponent } from './real-estate-repair/real-estate-repair.component';
import { PlanComponent, ConstructionComponent, BidManagerComponent } from '.';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'menu-client', component: MenuClientComponent,
                        data: { permission: 'Pages.Administration.MenuClient' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'demo-model', component: DemoModelComponent,
                        data: { permission: 'Pages.Administration.DemoModel' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'customer', component: CustomerComponent,
                        data: { permission: 'Pages.Administration.Customer' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-management', component: RealEstateManagementComponent,
                        data: { permission: 'Pages.Administration.RealEstate9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-type', component: RealEstateTypeComponent,
                        data: { permission: 'Pages.Administration.RealEstateType9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-repair', component: RealEstateRepairComponent,
                        data: { permission: 'Pages.Administration.RealEstateRepair9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'plan', component: PlanComponent,
                        data: { permission: 'Pages.Administration.Plan9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'construction', component: ConstructionComponent,
                        data: { permission: 'Pages.Administration.Construction9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'bid-manager', component: BidManagerComponent,
                        data: { permission: 'Pages.Administration.BidManager9' }
                    },
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
