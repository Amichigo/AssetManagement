import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { ShoppingPlanComponent } from './shoppingPlan/shoppingPlan.component';
import { ShoppingPlanDetailComponent } from './shoppingPlan/shoppingPlanDetail.component';
import { ConstructionPlanComponent } from './constructionPlan/constructionPlan.component';
import { DisposalPlanComponent } from './disposalPlan/disposalPlan.component';
import { DisposalPlanDetailComponent } from './disposalPlan/disposalPlanDetail.component';

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
                        path: 'shoppingPlan', component: ShoppingPlanComponent,
                        data: { permission: 'Pages.Administration.ShoppingPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'ShoppingPlan', component: ShoppingPlanDetailComponent,
                        data: { permission: 'Pages.Administration.ShoppingPlanDetail' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'constructionPlan', component: ConstructionPlanComponent,
                        data: { permission: 'Pages.Administration.ConstructionPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'disposalPlan', component: DisposalPlanComponent,
                        data: { permission: 'Pages.Administration.DisposalPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'DisposalPlan', component: DisposalPlanDetailComponent,
                        data: { permission: 'Pages.Administration.DisposalPlanDetail' }
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
