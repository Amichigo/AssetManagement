import { ViewDisposalPlanModalComponent } from './view-disposalPlan-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { DisposalPlanServiceProxy,DisposalPlanInput, SessionServiceProxy,UserServiceProxy, GetCurrentLoginInformationsOutput, GetUserForEditOutput } from '@shared/service-proxies/service-proxies';
import { CreateOrEditDisposalPlanModalComponent } from './create-or-edit-disposalPlan-modal.component';
import { DisposalPlanDetailComponent } from './disposalPlanDetail.component';
import { userInfo } from 'os';
 
@Component({
    templateUrl: './disposalPlan.component.html',
    animations: [appModuleAnimation()],
    styles: [`.highlighted {
        background - color: #fff2ac;
        background-image: linear-gradient(to right, #ffe359 0 %, #fff2ac 100 %);}`,
            `.hide { display: none;}`]
})
export class DisposalPlanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditDisposalPlanModalComponent;
    @ViewChild('viewDisposalPlanModal') viewDisposalPlanModal: ViewDisposalPlanModalComponent;
    @ViewChild('viewDetailModal') viewDetailModal: DisposalPlanDetailComponent;

    halfChecked: boolean = false;
    role: any;
    showActions: boolean = false;
    /**
     * tạo các biến dể filters
     */
    disposalPlanKhuVuc: string;
    disposalPlanPhongBan: string;
    disposalPlanMaKeHoach: string;
    disposalPlanTinhTrang: string;
    /*
     * lấy user role hiện tại
     */
    currentSession: GetCurrentLoginInformationsOutput = new GetCurrentLoginInformationsOutput();
    currentUser: GetUserForEditOutput = new GetUserForEditOutput();
    /*
     * tạo biến để lưu và truyền qua form detail
     */
    selectedRow: DisposalPlanInput = new DisposalPlanInput();

    constructor(
        injector: Injector,
        private _disposalPlanService: DisposalPlanServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _userService: UserServiceProxy,
        private _sessionService: SessionServiceProxy,
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
     * Hàm get danh sách disposalPlans
     * @param event
     */
    getDisposalPlans(event?: LazyLoadEvent) {
        this._sessionService.getCurrentLoginInformations().subscribe(result => {
            this.currentSession = result;
            this._userService.getUserForEdit(this.currentSession.user.id).subscribe(user => {
                this.currentUser = user;

                if (!this.paginator || !this.dataTable) {
                       return;
                }
                this.primengTableHelper.showLoadingIndicator();
                for (let i = 0; i < this.currentUser.roles.length; i++) {
                    if (this.currentUser.roles[i].isAssigned == true && this.currentUser.roles[i].roleDisplayName == "hieu truong") {
                        this.halfChecked = true;
                        this.reloadList(null, null, null, "checking" && "checked", event);
                    }
                }
                console.log(this.halfChecked);
                if (this.halfChecked == false) this.reloadList(null, null, null,null, event);
            })
        })
    }

    reloadList(disposalPlanKhuVuc,disposalPlanPhongBan,disposalPlanMaKeHoach,disposalPlanTinhTrang, event?: LazyLoadEvent) {
        this._disposalPlanService.getDisposalPlansByFilter(disposalPlanKhuVuc, disposalPlanPhongBan,disposalPlanMaKeHoach,
            disposalPlanTinhTrang,this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
        console.log(this.primengTableHelper.records);
    }

    deleteDisposalPlan(id): void {
        this._disposalPlanService.deleteDisposalPlan(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.disposalPlanKhuVuc = params['khuVuc'] || '';
            this.disposalPlanPhongBan = params['phongBan'] || '';
            this.disposalPlanMaKeHoach = params['maKeHoach'] || '';
            this.disposalPlanTinhTrang = params['tinhTrang'] || '';
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.disposalPlanKhuVuc, this.disposalPlanPhongBan, this.disposalPlanMaKeHoach,
            this.disposalPlanTinhTrang, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    disposalPlanDetail():void {
        this.viewDetailModal.show();
    }

    //hàm show view create MenuClient
    createDisposalPlan():void {
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
        this.selectedRow.tinhTrang = userInput.tinhTrang;
        console.log(userInput);
    }

}