import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { TypeOfAssetComponent } from './type-of-asset/type-of-asset.component';
import { AssetGroupComponent } from './asset-group/asset-group.component';
import { Asset7Component } from './asset/asset7.component';
import { RentalAssetComponent } from './rental-asset/rental-asset.component';

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
                        path: 'type-of-asset', component: TypeOfAssetComponent,
                        data: { permission: 'Pages.Administration.TypeOfAsset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-group', component: AssetGroupComponent,
                        data: { permission: 'Pages.Administration.AssetGroup' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset', component: Asset7Component,
                        data: { permission: 'Pages.Administration.Asset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'rental-asset', component: RentalAssetComponent,
                        data: { permission: 'Pages.Administration.RentalAsset' }
                    },
                ]
            },
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
