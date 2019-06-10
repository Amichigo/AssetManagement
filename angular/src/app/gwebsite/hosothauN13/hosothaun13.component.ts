
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ModalDirective } from 'ngx-bootstrap';
import { HoSoThauN13ServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateHoSoThauN13ModalComponent } from './create-hosothau13-modal.component';
import { EditHoSoThauN13ModalComponent } from './edit-hosothau13-modal.component';
import { SelectCongTrinhN13ModalComponent } from './select-congtrinhn13-modal.component';
@Component({

    templateUrl: './hosothaun13.component.html',
    animations: [appModuleAnimation()]
})
export class HoSoThauN13Component extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('HoSoThauN13Modal') modal: ModalDirective;
    @ViewChild('createHoSoThauN13Modal') createHoSoThauN13Modal: CreateHoSoThauN13ModalComponent;
    @ViewChild('editHoSoThauN13Modal') editHoSoThauN13Modal: EditHoSoThauN13ModalComponent;
    @ViewChild('selectCongTrinhN13Modal') selectCongTrinhN13Modal: SelectCongTrinhN13ModalComponent;
    /**
     * tạo các biến dể filters
     */
    maHoSoThau: string;
    hangMucThau: string;
    ngayPhat: string;
    ngayhetHan: string;
    hinhThucThau: string;
    duAnXD: string;
    idDuAn:number;

    /**
     * Tab values
     */
    activeTabHoSoThau = true;
    activeTabCreate = false;
    activeTabUpdate = false;
    activeTabView = false;
    activeTabSetActive = false;

    disableTabUpdate = true;
    disableTabView = true;
    disableTabSetActive = true;
    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauN13ServiceProxy,
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
     * Tab funtion
     */

    InitTabHoSoThau(): void {
        this.reloadPage();
        this.activeTabCreate = false;
        this.activeTabUpdate = false;
        this.activeTabView = false;
        this.activeTabSetActive = false;

        this.disableTabUpdate = true;
        this.disableTabView = true;
        this.disableTabSetActive = true;


    }
    InitTabCreate(): void {
        if (this.activeTabCreate == false) {

            console.log("Init create");
            this.activeTabHoSoThau = false;
            this.activeTabUpdate = false;
            this.activeTabView = false;
            this.activeTabSetActive = false;
            this.activeTabCreate = true;

            this.disableTabView = true;
            this.disableTabUpdate = true;
            this.disableTabSetActive = true;
            this.createHoSoThauN13Modal.show();

        }



    }

    InitTabView(idRecond: number): void {
        this.disableTabView = false;
        this.activeTabView = true;

        this.activeTabHoSoThau = false;
        this.activeTabUpdate = false;
        this.activeTabCreate = false;
        this.activeTabSetActive = false;

        this.disableTabSetActive = true;
        this.disableTabUpdate = true;
    }

    InitTabUpdate(idRecond: number) {
        if (this.activeTabUpdate == false) {
            this.disableTabUpdate = false;
            this.activeTabUpdate = true;
            this.disableTabView = true;
            this.disableTabSetActive = true;

            this.activeTabHoSoThau = false;
            this.activeTabView = false;
            this.activeTabCreate = false;
            this.activeTabSetActive = false;
            this.editHoSoThauN13Modal.show(idRecond);
        }


    }

    InitTabActive(idRecond: number) {
        console.log("ID recond" + idRecond);
        this.disableTabSetActive = false;
        this.activeTabSetActive = true;
        this.disableTabView = true;
        this.disableTabUpdate = true;

        this.activeTabHoSoThau = false;
        this.activeTabView = false;
        this.activeTabCreate = false;
        this.activeTabUpdate = false;
    }

    GetDisableTabView(): boolean {
        return this.disableTabView;
    }
    GetDisableTabUpdate(): boolean {
        return this.disableTabUpdate;
    }

    GetDisableTabActive(): boolean {
        return this.disableTabSetActive;
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
     * Hàm get danh sách HoSoThau
     * @param event
     */
    getHoSoThaus(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, null, null, null, event);

    }

    reloadList(mahst, mact, ngaynhap, ngayhethan, hanmuc, hinhthuc, event?: LazyLoadEvent) {
        this._hosothauService.getHoSoThausByFilter(mahst, mact, ngaynhap, ngayhethan, hanmuc, hinhthuc, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    ResetFilter() {
        this.maHoSoThau = "";
        this.hangMucThau = "";
        this.ngayPhat = "";
        this.ngayhetHan = "";
        this.hinhThucThau = "";
        this.duAnXD = "";
        this.idDuAn=null;
        this.reloadPage();
    }
    showSelectCongTrinh(){
        this.selectCongTrinhN13Modal.show();
    }

    setThongTin():void{
        this.duAnXD=this.selectCongTrinhN13Modal.congtrinhForView.maCongTrinh;
        this.idDuAn=this.selectCongTrinhN13Modal.congtrinhForView.id;
    }
    SaveNew() {
        this.activeTabHoSoThau = true;
    }
    deleteHoSoThau(id): void {
        this._hosothauService.deleteHoSoThau(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.maHoSoThau = params['TenHoSoThau'] || '';
            this.hinhThucThau = params['MaHoSoThau'] || '';
            this.hangMucThau = params['MamaKeHoach'] || '';
            this.ngayPhat = params['MaLoaiHoSoThau'] || '';
            this.ngayhetHan = '';
            this.duAnXD = '';
            this.idDuAn=null;
            this.reloadList(this.maHoSoThau, this.idDuAn, this.ngayPhat, this.ngayhetHan, this.hangMucThau, this.hinhThucThau);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.maHoSoThau, this.idDuAn, this.ngayPhat, this.ngayhetHan, this.hangMucThau, this.hinhThucThau, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient


    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
