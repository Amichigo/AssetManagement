import { ViewCongTrinhModalComponent } from './view-congtrinh-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CongTrinhServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditCongTrinhModalComponent } from './create-or-edit-congtrinh-modal.component';
import { ModalDirective } from 'ngx-bootstrap';

@Component({

    templateUrl: './congtrinh.component.html',
    selector: 'CongTrinhModal',
    animations: [appModuleAnimation()]
})
export class CongTrinhComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditCongTrinhModalComponent;
    @ViewChild('viewCongTrinhModal') viewCongTrinhModal: ViewCongTrinhModalComponent;
    @ViewChild('CongTrinhModal') modal: ModalDirective;
    /**
     * tạo các biến dể filters
     */
    congtrinhName: string;
    macongtrinh:string;
    maKeHoach:string;
    loaicongtrinh:string;
    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        
    }



    show():void{
        this.modal.show();
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
     * Hàm get danh sách CongTrinh
     * @param event
     */
    getCongTrinhs(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null,null, event);

    }

    reloadList(congtrinhName,macongtrinh,maKeHoach, event?: LazyLoadEvent) {
        this._congtrinhService.getDsCongTrinhThuocDuAnByFilter(macongtrinh,maKeHoach,congtrinhName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteCongTrinh(id): void {
        this._congtrinhService.deleteCongTrinh(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.congtrinhName = params['TenCongTrinh'] || '';
            this.macongtrinh = params['MaCongTrinh'] || '';
            this.maKeHoach= params['MamaKeHoach'] || '';
            this.loaicongtrinh= params['MaLoaiCongTrinh'] || '';
            this.reloadList(this.congtrinhName,this.macongtrinh,this.maKeHoach, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.congtrinhName,this.macongtrinh,this.maKeHoach, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createCongTrinh() {
        
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
