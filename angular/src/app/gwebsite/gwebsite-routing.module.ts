import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { PurchasedAssetsComponent } from './asset-investment-efficiency/pages/purchased-assets/purchased-assets.component';
import { SoleAssetsComponent } from './asset-investment-efficiency/pages/sole-assets/sole-assets.component';
import { MaintainedAssetsComponent } from './asset-investment-efficiency/pages/maintained-assets/maintained-assets.component';
import { PlannedToSellAssetsComponent } from './asset-investment-efficiency/pages/planned-to-sell-assets/planned-to-sell-assets.component';
import { OperatingAssetsComponent } from './asset-investment-efficiency/pages/operating-assets/operating-assets.component';
import { PlannedToPurchaseAssetsComponent } from './asset-investment-efficiency/pages/planned-to-purchase-assets/planned-to-purchase-assets.component';
import { PlannedToMaintainAssetsComponent } from './asset-investment-efficiency/pages/planned-to-maintain-assets/planned-to-maintain-assets.component';

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
                        path: 'asset-investment-efficiency/purchased-assets', component: PurchasedAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/sole-assets', component: SoleAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/maintained-assets', component: MaintainedAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/planned-to-sell-assets', component: PlannedToSellAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/operating-assets', component: OperatingAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/planned-to-purchase-assets', component: PlannedToPurchaseAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/planned-to-maintain-assets', component: PlannedToMaintainAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
