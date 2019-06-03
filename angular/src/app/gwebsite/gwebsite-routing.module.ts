import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { FixedAssetComponent } from './fixed-asset/fixed-asset.component';
import { AssetDashboardComponent } from './asset-dashboard/asset-dashboard.component';
import { AssetGroupComponent } from "./asset-group/asset-group.component";
import { AssetComponent } from "./asset/asset.component";

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
                        path: 'fixed-asset', component: FixedAssetComponent,
                        data: { permission: 'Pages.Administration.FixedAsset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-dashboard', component: AssetDashboardComponent,
                        data: { permission: 'Pages.Administration.AssetDashboard' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-group', component: AssetGroupComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset', component: AssetComponent,
                        data: { permission: 'Pages.Administration.Asset_05' }
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
