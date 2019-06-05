import { ViewConstructionPlanModalComponent } from './view-constructionPlan-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ConstructionPlanServiceProxy,ConstructionPlanInput } from '@shared/service-proxies/service-proxies';
import { CreateOrEditConstructionPlanModalComponent } from './create-or-edit-constructionPlan-modal.component';
import { ConstructionPlanDetailComponent } from './constructionPlanDetail.component';
import { userInfo } from 'os';

@Component({
    templateUrl: './constructionPlan.component.html',
    animations: [appModuleAnimation()],
    styles: [`.highlighted {
    background - color: #fff2ac;
    background-image: linear-gradient(to right, #ffe359 0 %, #fff2ac 100 %);}`]
})
export class ConstructionPlanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditConstructionPlanModalComponent;
    @ViewChild('viewConstructionPlanModal') viewConstructionPlanModal: ViewConstructionPlanModalComponent;
    @ViewChild('viewDetailModal') viewDetailModal: ConstructionPlanDetailComponent;

    /**
     * tạo các biến dể filters
     */
    constructionPlanKhuVuc: string;
    constructionPlanPhongBan: string;
    constructionPlanMaKeHoach: string;
    constructionPlanTinhTrang: string;
    /*
     * tạo biến để lưu và truyền qua form detail
     */
    selectedRow: ConstructionPlanInput = new ConstructionPlanInput();

    constructor(
        injector: Injector,
        private _constructionPlanService: ConstructionPlanServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách constructionPlans
     * @param event
     */
    getConstructionPlans(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null,null,null,event);

    }

    reloadList(constructionPlanKhuVuc,constructionPlanPhongBan,constructionPlanMaKeHoach,constructionPlanTinhTrang, event?: LazyLoadEvent) {
        this._constructionPlanService.getConstructionPlansByFilter(constructionPlanKhuVuc, constructionPlanPhongBan,constructionPlanMaKeHoach,
            constructionPlanTinhTrang,this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteConstructionPlan(id): void {
        this._constructionPlanService.deleteConstructionPlan(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.constructionPlanKhuVuc = params['khuVuc'] || '';
            this.constructionPlanPhongBan = params['phongBan'] || '';
            this.constructionPlanMaKeHoach = params['maKeHoach'] || '';
            this.constructionPlanTinhTrang = params['tinhTrang'] || '';
            this.reloadList(this.constructionPlanKhuVuc, this.constructionPlanPhongBan, this.constructionPlanMaKeHoach,
                this.constructionPlanTinhTrang, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.constructionPlanKhuVuc, this.constructionPlanPhongBan, this.constructionPlanMaKeHoach,
            this.constructionPlanTinhTrang, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    constructionPlanDetail():void {
        this.viewDetailModal.show();
    }

    //hàm show view create MenuClient
    createConstructionPlan():void {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    rowSelected(userInput: any):void {
        this.selectedRow.id = userInput.id;
        this.selectedRow.khuVuc = userInput.khuVuc;
        this.selectedRow.kinhPhi = userInput.kinhPhi;
        this.selectedRow.maKeHoach = userInput.maKeHoach;
        this.selectedRow.nam = userInput.nam;
        this.selectedRow.ngayHieuLuc = userInput.ngayHieuLuc;
        this.selectedRow.phongBan = userInput.phongBan;
        this.selectedRow.soLanThayDoi = userInput.soLanThayDoi;
        this.selectedRow.trangThai = userInput.trangThai;
        console.log(userInput);
    }

}
