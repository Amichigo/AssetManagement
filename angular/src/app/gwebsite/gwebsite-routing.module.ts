import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { LoaiBatDongSanComponent } from './loaibatdongsan/loaibatdongsan.component';
import { LoaiSoHuuComponent } from './loaisohuu/loaisohuu.component';
import { HienTrangPhapLyComponent } from './hientrangphaply/hientrangphaply.component';
import { BatDongSanComponent } from './batdongsan/batdongsan.component';
import { TinhTrangSuDungDatComponent } from './tinhtrangsudungdat/tinhtrangsudungdat.component';
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
                        path: 'loaibatdongsan', component: LoaiBatDongSanComponent,
                        data: { permission: 'Pages.QuanLyBatDongSan.LoaiBatDongSan' }
                    },
                ]
            },
    
            {
                path: '',
                children: [
                    {
                        path: 'loaisohuu', component: LoaiSoHuuComponent,
                        data: { permission: 'Pages.QuanLyBatDongSan.LoaiSoHuu' }
                    },
                ]
            },
            //{
            //    path: '',
            //    children: [
            //        {
            //            path: 'mucdichsudungdat', component: MucDichSuDungDatComponent,
            //            data: { permission: 'Pages.Administration.MucDichSuDungDat' }
            //        },
            //    ]

            //},
            {
                path: '',
                children: [
                    {
                        path: 'batdongsan', component: BatDongSanComponent,
                        data: { permission: 'Pages.QuanLyBatDongSan.BatDongSan' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'hientrangphaply', component: HienTrangPhapLyComponent,
                        data: { permission: 'Pages.QuanLyBatDongSan.HienTrangPhapLy' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'tinhtrangsudungdat', component: TinhTrangSuDungDatComponent,
                        data: { permission: 'Pages.QuanLyBatDongSan.TinhTrangSuDungDat' }
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
