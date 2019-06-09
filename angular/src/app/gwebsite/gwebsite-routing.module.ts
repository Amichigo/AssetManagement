import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { FixedAssetComponent } from './fixed-asset/fixed-asset.component';
import { AssetDashboardComponent } from './asset-dashboard/asset-dashboard.component';
import { AssetGroupComponent } from "./asset-group/asset-group.component";
import { AssetComponent } from "./asset/asset.component";
import { CreateOrEditAssetModalComponent } from "./asset/create-or-edit-asset-modal.component"
import { CreateOrEditAssetGroupModalComponent } from "./asset-group/create-or-edit-asset-group-modal.component"
import { TransferringAssetComponent } from './transferring-asset/transferring-asset.component';
import { CreateOrEditTransferringAssetModalComponent } from './transferring-asset/create-or-edit-transferring-asset-modal.component';
import { CreateOrEditExportingUsedAssetModalComponent } from './exporting-used-asset/create-or-edit-exporting-used-asset-modal.component';
import { ExportingUsedAssetComponent } from './exporting-used-asset/exporting-used-asset.component';

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
            },
            {
                path: 'asset-group',
                children: [
                    {
                        path: 'create-or-edit-asset-group', component: CreateOrEditAssetGroupModalComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05.Create' }
                    },
                ]
            },
            {
                path: 'asset',
                children: [
                    {
                        path: 'create-or-edit-asset', component: CreateOrEditAssetModalComponent,
                        data: { permission: 'Pages.Administration.Asset_05.Create' }
                    },
                ]
            },
            {
                path: 'asset-group',
                children: [
                    {
                        path: 'create-or-edit-asset-group/:assetGroupId/:readOnly', component: CreateOrEditAssetGroupModalComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05.Create' }
                    },
                ]
            },
            {
                path: 'asset',
                children: [
                    {
                        path: 'create-or-edit-asset/:assetId/:readOnly', component: CreateOrEditAssetModalComponent,
                        data: { permission: 'Pages.Administration.Asset_05.Create' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'transferring-asset', component: TransferringAssetComponent,
                        data: { permission: 'Pages.Administration.TransferringAsset' }
                    },
                ]
            },
            {
                path: 'transferring-asset',
                children: [
                    {
                        path: 'create-or-edit-transferring-asset', component: CreateOrEditTransferringAssetModalComponent,
                        data: { permission: 'Pages.Administration.TransferringAsset.Create' }
                    },
                ]
            },
            {
                path: 'transferring-asset',
                children: [
                    {
                        path: 'create-or-edit-transferring-asset/:transferringAssetId', component: CreateOrEditTransferringAssetModalComponent,
                        data: { permission: 'Pages.Administration.TransferringAsset.Edit' }
                    },
                ]
            },
               {
                path: '',
                children: [
                    {
                        path: 'exporting-used-asset', component:ExportingUsedAssetComponent ,
                        data: { permission: 'Pages.Administration.ExportingUsedAsset' }
                    },
                ]
            },
            {
                path: 'exporting-used-asset',
                children: [
                {
                    path: 'create-or-edit-exporting-used-asset', component: CreateOrEditExportingUsedAssetModalComponent,
                    data: { permission: 'Pages.Administration.ExportingUsedAsset.Create' }
                },
            ]
            },
           {
                path: 'exporting-used-asset',
                children: [
                {
                    path: 'create-or-edit-exporting-used-asset/:exportingUsedId', component: CreateOrEditExportingUsedAssetModalComponent,
                    data: { permission: 'Pages.Administration.ExportingUsedAsset.Edit' }
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
