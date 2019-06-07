import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { CustomerComponent } from './customer/customer.component';
import { DuAnComponent } from './duan/duan.component';
import { HoSoThauComponent } from './hosothau/hosothau.component';
import { CreateOrEditHoSoThauModalComponent } from './hosothau/create-or-edit-hosothau-modal.component';
import { ViewHoSoThauModalComponent } from './hosothau/view-hosothau-modal.component';
import { NhaCungCapComponent } from './nhacungcap/nhacungcap.component';
import { HopDongThauComponent } from './hopdongthau/hopdongthau.component';
import { CreateOrEditHopDongThauModalComponent } from './hopdongthau/create-or-edit-hopdongthau-modal.component';
import { ViewHopDongThauModalComponent } from './hopdongthau/view-hopdongthau-modal.component';
import { PhieuGoiHangComponent } from './phieugoihang/phieugoihang.component';
import { CreateOrEditPhieuGoiHangModalComponent } from './phieugoihang/create-or-edit-phieugoihang-modal.component';
import { ViewPhieuGoiHangModalComponent } from './phieugoihang/view-phieugoihang-modal.component';
import { HangHoaComponent } from './hanghoa/hanghoa.component';

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
                        data: { permission: 'Pages.Administration.Project' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothau', component: HoSoThauComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothau_modal', component: CreateOrEditHoSoThauModalComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'view_hosothau_modal', component: ViewHoSoThauModalComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'nhacungcap', component: NhaCungCapComponent,
                        data: { permission: 'Pages.Administration.Supplier' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hopdongthau', component: HopDongThauComponent,
                        data: { permission: 'Pages.Administration.Contract' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hopdongthau_modal', component: CreateOrEditHopDongThauModalComponent,
                        data: { permission: 'Pages.Administration.Contract' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'view_hopdongthau_modal', component: ViewHopDongThauModalComponent,
                        data: { permission: 'Pages.Administration.Contract' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'phieugoihang', component: PhieuGoiHangComponent,
                        data: { permission: 'Pages.Administration.GoodsInvoice' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'phieugoihang_modal', component: CreateOrEditPhieuGoiHangModalComponent,
                        data: { permission: 'Pages.Administration.GoodsInvoice' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'view_phieugoihang_modal', component: ViewPhieuGoiHangModalComponent,
                        data: { permission: 'Pages.Administration.GoodsInvoice' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hanghoa', component: HangHoaComponent,
                        data: { permission: 'Pages.Administration.Goods' }
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
