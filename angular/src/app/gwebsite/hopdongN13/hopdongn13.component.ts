
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params} from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ModalDirective } from 'ngx-bootstrap';
import { HopDongN13ServiceProxy, CongTrinhForViewDto, HoSoThauN13ForViewDto, HopDongN13Input } from '@shared/service-proxies/service-proxies';
import { CreateHopDongN13ModalComponent } from './create-hopdong13-modal.component';
@Component({

    templateUrl: './hopdongn13.component.html',
    animations: [appModuleAnimation()]
})
export class HopDongN13Component extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('HopDongN13Modal') modal: ModalDirective;
    @ViewChild('createHopDongN13Modal') createHopDongN13Modal: CreateHopDongN13ModalComponent;
    /**
     * tạo các biến dể filters
     */
    soToTrinh: string;
    soHopDong: string;
    duAnXayDung: string;
    goiThau: string;
    
    /**
     * Tab values
     */
    activeTabHopDong = true;
    activeTabCreate = false;
    activeTabUpdate = false;
    activeTabView = false;
    activeTabSetActive = false;

    disableTabUpdate = true;
    disableTabView = true;
    disableTabSetActive = true;
    constructor(
        injector: Injector,
        private _hopDongServiceProxy:HopDongN13ServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }
    SaveNew() {
     
        this.activeTabHopDong = true;
    }
    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Tab funtion
     */

    InitTabHopDong(): void {

        this.reloadList(null, null, null);
        this.activeTabCreate = false;
        this.activeTabUpdate = false;
        this.activeTabView = false;
        this.activeTabSetActive = false;

        this.disableTabUpdate = true;
        this.disableTabView = true;
        this.disableTabSetActive = true;


    }
    InitTabCreate(): void {
        if(this.activeTabCreate==false)
        {

            console.log("Init create");
            this.activeTabHopDong = false;
            this.activeTabUpdate = false;
            this.activeTabView = false;
            this.activeTabSetActive = false;
            this.activeTabCreate=true;

            this.disableTabView = true;
            this.disableTabUpdate = true;
            this.disableTabSetActive = true;
            this.createHopDongN13Modal.show();

        }
      
        
      
    }

    InitTabView(idRecond: number): void {
        this.disableTabView = false;
        this.activeTabView = true;

        this.activeTabHopDong = false;
        this.activeTabUpdate = false;
        this.activeTabCreate = false;
        this.activeTabSetActive = false;

        this.disableTabSetActive = true;
        this.disableTabUpdate = true;
    }

    InitTabUpdate(idRecond: number) {
        if(this.activeTabUpdate==false)
        {
            this.disableTabUpdate = false;
            this.activeTabUpdate = true;
            this.disableTabView = true;
            this.disableTabSetActive = true;
    
            this.activeTabHopDong = false;
            this.activeTabView = false;
            this.activeTabCreate = false;
            this.activeTabSetActive = false;
        }

   
    }

    InitTabActive(idRecond: number) {
        console.log("ID recond" + idRecond);
        this.disableTabSetActive = false;
        this.activeTabSetActive = true;
        this.disableTabView = true;
        this.disableTabUpdate = true;

        this.activeTabHopDong = false;
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
     * Hàm get danh sách HopDong
     * @param event
     */
    getHopDongs(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, event);

    }

    reloadList(hosothauName, mahosothau, maKeHoach, event?: LazyLoadEvent) {
        this._hopDongServiceProxy.getHopDongsByFilter(mahosothau,null,null,this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteHopDong(id): void {
        this._hopDongServiceProxy.deleteHopDong(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.soToTrinh = params['TenHopDong'] || '';
            this.soHopDong = params['MaHopDong'] || '';
            this.duAnXayDung = params['MamaKeHoach'] || '';
            this.goiThau = params['MaLoaiHopDong'] || '';
            this.reloadList(this.soToTrinh, this.soHopDong, this.duAnXayDung, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.soToTrinh, this.soHopDong, this.duAnXayDung, null);

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
