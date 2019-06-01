import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { LoaiNhaCungCapComponent } from './LoaiNhaCungCap/LoaiNhaCungCap.component';
import{NhaCungCapHangHoaComponent} from './NhaCungCapHangHoa/NhaCungCapHangHoa.component';
import{ProductComponent} from './Product/Product.component';
import{ProductTypeComponent} from './ProductType/ProductType.component';


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
                        path: 'LoaiNhaCungCap', component: LoaiNhaCungCapComponent,
                        data: { permission: 'Pages.Administration.LoaiNhaCungCap' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'NhaCungCapHangHoa', component: NhaCungCapHangHoaComponent,
                        data: { permission: 'Pages.Administration.NhaCungCapHangHoa' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'Product', component: ProductComponent,
                        data: { permission: 'Pages.Administration.Product' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'ProductType', component: ProductTypeComponent,
                        data: { permission: 'Pages.Administration.ProductType' }
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
