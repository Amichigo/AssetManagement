import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { CustomerComponent } from './customer/customer.component';
import { DuAnComponent } from './duan/duan.component';
import { HoSoThauComponent } from './hosothau/hosothau.component';
import { NhaCungCapComponent } from './nhacungcap/nhacungcap.component';
import { HopDongThauComponent } from './hopdongthau/hopdongthau.component';
import { PhieuGoiHangComponent } from './phieugoihang/phieugoihang.component';

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
                        path: 'customer', component: CustomerComponent,
                        data: { permission: 'Pages.Administration.Customer' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'duan', component: DuAnComponent,
                        data: { permission: 'Pages.Administration.DuAn' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothau', component: HoSoThauComponent,
                        data: { permission: 'Pages.Administration.HoSoThau' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'nhacungcap', component: NhaCungCapComponent,
                        data: { permission: 'Pages.Administration.NhaCungCap' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hopdongthau', component: HopDongThauComponent,
                        data: { permission: 'Pages.Administration.HopDongThau' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'phieugoihang', component: PhieuGoiHangComponent,
                        data: { permission: 'Pages.Administration.PhieuGoiHang' }
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
