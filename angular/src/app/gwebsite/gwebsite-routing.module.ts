import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CategoryComponent } from './category/category-general.component';
import { CategoryTypeComponent } from './category-type/category-type-general.component';
import { DuAnComponent } from './duan/duan.component';
import { HoSoThauComponent } from './hosothau/hosothau.component';
import { NhaCungCapComponent } from './nhacungcap/nhacungcap.component';
import { HopDongThauComponent } from './hopdongthau/hopdongthau.component';
import { PhieuGoiHangComponent } from './phieugoihang/phieugoihang.component';
import { HangHoaComponent } from './hanghoa/hanghoa.component';
import { ShoppingPlanComponent } from './shoppingPlan/shoppingPlan.component';
import { DirectorShoppingPlanComponent } from './directorShoppingPlan/directorShoppingPlan.component';
import { ShoppingPlanDetailComponent } from './shoppingPlan/shoppingPlanDetail.component';
import { ConstructionPlanComponent } from './constructionPlan/constructionPlan.component';

@NgModule({
    imports: [
        RouterModule.forChild([
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
                        path: 'phieugoihang', component: PhieuGoiHangComponent,
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
            },
            {
                path: '',
                children: [
                    {
                        path: 'category', component: CategoryComponent,
                        data: { permission: 'Pages.Categories.General' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'category-type', component: CategoryTypeComponent,
                        data: { permission: 'Pages.CategoryTypes.General' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'shoppingPlan', component: ShoppingPlanComponent,
                        data: { permission: 'Pages.Administration.ShoppingPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'ShoppingPlan', component: ShoppingPlanDetailComponent,
                        data: { permission: 'Pages.Administration.ShoppingPlanDetail' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'directorShoppingPlan', component: DirectorShoppingPlanComponent,
                        data: { permission: 'Pages.Administration.DirectorShoppingPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'constructionPlan', component: ConstructionPlanComponent,
                        data: { permission: 'Pages.Administration.ConstructionPlan' }
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
