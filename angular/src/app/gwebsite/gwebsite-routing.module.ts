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
import { TaiSanComponent } from './taisan/taisan.component';
import { SuaChuaBatDongSanComponent } from './suachuabatdongsan/suachuabatdongsan.component';
import { KeHoachXayDungComponent } from './kehoachxaydung/kehoachxaydung.component';
import { CongTrinhComponent } from './congtrinhN13/congtrinh.component';
import { HoSoThauN13Component } from './hosothauN13/hosothaun13.component';
import { HopDongN13Component } from './hopdongN13/hopdongn13.component';
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
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.LoaiBatDongSan' }
                    },
                ]
            },
    
            {
                path: '',
                children: [
                    {
                        path: 'loaisohuu', component: LoaiSoHuuComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.LoaiSoHuu' }
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
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.BatDongSan' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'hientrangphaply', component: HienTrangPhapLyComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.HienTrangPhapLy' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'tinhtrangsudungdat', component: TinhTrangSuDungDatComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.TinhTrangSuDungDat' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'taisan', component: TaiSanComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.TaiSan' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'suachuabatdongsan', component: SuaChuaBatDongSanComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.SuaChuaBatDongSan' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'kehoachxaydung', component: KeHoachXayDungComponent,
                        data: { permission: 'Pages.Administration.QuanLyKeHoachXayDung.KeHoachXayDung' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'congtrinh', component: CongTrinhComponent,
                        data: { permission: 'Pages.Administration.QuanLyCongTrinhDoDang.CongTrinhDoDang' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothaun13', component: HoSoThauN13Component,
                        data: { permission: 'Pages.Administration.QuanLyCongTrinhDoDang.HoSoThau' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'hopdongn13', component: HopDongN13Component,
                        data: { permission: 'Pages.Administration.QuanLyCongTrinhDoDang.HopDong' }
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
