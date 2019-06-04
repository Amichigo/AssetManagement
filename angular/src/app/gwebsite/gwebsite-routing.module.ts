import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { RentalAssetComponent } from './rental-asset/rental-asset.component';
import { TypeOfRentalAssetComponent } from './type-of-rental-asset/type-of-rental-asset.component';
import { FormOfRentingAssetComponent } from './form-of-renting-asset/form-of-renting-asset.component';
import { AssetRentingFileComponent } from './asset-renting-file/asset-renting-file.component';
import { AssetRentingContractComponent } from './asset-renting-contract/asset-renting-contract.component';

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
                        path: 'rental-asset', component: RentalAssetComponent,
                        data: { permission: 'Pages.Administration.RentalAsset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'type-of-rental-asset', component: TypeOfRentalAssetComponent,
                        data: { permission: 'Pages.Administration.TypeOfRentalAsset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'form-of-renting-asset', component: FormOfRentingAssetComponent,
                        data: { permission: 'Pages.Administration.FormOfRentingAsset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-renting-file', component: AssetRentingFileComponent,
                        data: { permission: 'Pages.Administration.AssetRentingFile' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-renting-contract', component: AssetRentingContractComponent,
                        data: { permission: 'Pages.Administration.AssetRentingContract' }
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
