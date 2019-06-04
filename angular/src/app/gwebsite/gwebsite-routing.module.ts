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
import { ComputerComponent } from './computer/computer.component';
import { SoftwareComponent } from './software/software.component';
import { FixedAssetComponent } from './fixed-asset/fixed-asset.component';
import { AssetDashboardComponent } from './asset-dashboard/asset-dashboard.component';
import { AssetGroupComponent } from "./asset-group/asset-group.component";
import { AssetComponent } from "./asset/asset.component";
import { RealEstateManagementComponent } from './real-estate-management/real-estate-management.component';
import { RealEstateTypeComponent } from './real-estate-type/real-estate-type.component';
import { RealEstateRepairComponent } from './real-estate-repair/real-estate-repair.component';

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
                        path: 'real-estate-management', component: RealEstateManagementComponent,
                        data: { permission: 'Pages.Administration.RealEstate9' }
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
                        path: 'real-estate-type', component: RealEstateTypeComponent,
                        data: { permission: 'Pages.Administration.RealEstateType9' }
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
                        path: 'asset-group', component: AssetGroupComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05' }
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
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'computer', component: ComputerComponent,
                        data: { permission: 'Pages.Administration.Computer'}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'software', component: SoftwareComponent,
                        data: { permission: 'Pages.Administration.Software'}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset', component: AssetComponent,
                        data: { permission: 'Pages.Administration.Asset_05' }
                    }
                ]
            },
            {
                path: '',
                children: [ 
                    {                  
                        path: 'real-estate-repair', component: RealEstateRepairComponent,
                        data: { permission: 'Pages.Administration.RealEstateRepair9' }
                    }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
