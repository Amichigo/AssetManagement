
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
import { EditHopDongN13ModalComponent } from './edit-hopdong13-modal.component';
import { ViewHopDongN13ModalComponent } from './view-hopdong13-modal.component';
import { SelectCongTrinhN13ModalComponent } from '../hosothauN13/select-congtrinhn13-modal.component';
import { SelectHoSoThauModalComponent } from './select-hosothau-modal.component';
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
    @ViewChild('viewHopDongN13Modal') viewHopDongN13Modal: ViewHopDongN13ModalComponent;
    @ViewChild('editHopDongN13Modal') editHopDongN13Modal: EditHopDongN13ModalComponent;
    @ViewChild('selectCongTrinhN13Modal') selectCongTrinhN13Modal: SelectCongTrinhN13ModalComponent;
    
    @ViewChild('selectHoSoThauModal') selectHoSoThauModal: SelectHoSoThauModalComponent;
    /**
     * tạo các biến dể filters
     */
    soToTrinh: string;
    soHopDong: string;
    duAnXayDung: string;
    goiThau: string;

    idDuaAn:number;
    idGoiThau:number;
    
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
        console.log("Init InitTabHopDong");
        
        this.activeTabCreate = false;
        this.activeTabUpdate = false;
        this.activeTabView = false;
        this.activeTabSetActive = false;

        this.disableTabUpdate = true;
        this.disableTabView = true;
        this.disableTabSetActive = true;

        this.reloadPage();
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
        if(  this.activeTabView ==false){
            this.disableTabView = false;
            this.activeTabView = true;
    
            this.activeTabHopDong = false;
            this.activeTabUpdate = false;
            this.activeTabCreate = false;
            this.activeTabSetActive = false;
    
            this.disableTabSetActive = true;
            this.disableTabUpdate = true;
            this.viewHopDongN13Modal.show(idRecond);
        }
    
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
            this.editHopDongN13Modal.show(idRecond);
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

        this.reloadList(null, null, null,null, event);

    }
    showSelectCongTrinh():void{
        this.selectCongTrinhN13Modal.show();
    }
    showHoSoThau():void{
        this.selectHoSoThauModal.show();
    }
    setHoSoThau():void{
        this.idGoiThau=this.selectHoSoThauModal.selecTedGoiThau.id;
        this.goiThau=this.selectHoSoThauModal.selecTedGoiThau.maHoSoThau;
        console.log("set ho so");
    }
resetFilter():void{
    this.soToTrinh="";
    this.soHopDong="";
    this.duAnXayDung="";
    this.goiThau="";

    this.idDuaAn=null;
    this.idGoiThau=null;
    this.reloadPage();
}
    reloadList(sohopdong, sototrinh, idhosothau,idcongtrinh, event?: LazyLoadEvent) {
        this._hopDongServiceProxy.getHopDongsByFilter(sohopdong,sototrinh,idhosothau,idcongtrinh,this.primengTableHelper.getSorting(this.dataTable),
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
            this.idDuaAn=null;
            this.idGoiThau=null;
            this.reloadList(this.soHopDong, this.soToTrinh, this.idGoiThau,this.idDuaAn, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.soHopDong, this.soToTrinh, this.idGoiThau,this.idDuaAn, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    setThongTin():void{
        this.duAnXayDung=this.selectCongTrinhN13Modal.congtrinhForView.maCongTrinh;
        this.idDuaAn=this.selectCongTrinhN13Modal.congtrinhForView.id;
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
