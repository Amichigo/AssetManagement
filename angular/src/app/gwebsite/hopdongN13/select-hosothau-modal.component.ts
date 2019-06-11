import { CustomerForViewDto, TaiSanN13ServiceProxy, CongTrinhServiceProxy, CongTrinhForViewDto, HoSoThauN13ServiceProxy, HoSoThauN13ForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'selectHoSoThauModal',
    templateUrl: './select-hosothau-modal.component.html'
})

export class SelectHoSoThauModalComponent extends AppComponentBase {

    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauN13ServiceProxy,
        private _congtrinhService: CongTrinhServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }


    /**
   * tạo các biến dể filters
   */
    maHoSoThau: string;
    hangMucThau: string;
    ngayPhat: string;
    ngayhetHan: string;
    hinhThucThau: string;
    duAnXD: string;
    idDuAn: number;

    maDVTrungThau: string;
    tenDVTrungThau: string;
    public selectedCongTrinh: CongTrinhForViewDto = new CongTrinhForViewDto();
    public selecTedGoiThau: HoSoThauN13ForViewDto = new HoSoThauN13ForViewDto();

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(): void {
        this.maDVTrungThau = '';
        this.tenDVTrungThau = '';
        console.log("Show");
        // this._congtrinhService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter

        //get params từ url để thực hiện filter
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.maHoSoThau = params['TenHoSoThau'] || '';
            this.hinhThucThau = params['MaHoSoThau'] || '';
            this.hangMucThau = params['MamaKeHoach'] || '';
            this.ngayPhat = params['MaLoaiHoSoThau'] || '';
            this.ngayhetHan = '';
            this.duAnXD = '';
            this.idDuAn = null;
            this.reloadList(this.maHoSoThau, this.idDuAn, this.ngayPhat, this.ngayhetHan, this.hangMucThau, this.hinhThucThau);

        });
        this.modal.show();

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

        this.reloadList(null, null, null, null, null,null, event);

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
    SetThongTin(id: number): void {
        console.log(id);
        this._hosothauService.getHoSoThauForView(id).subscribe(result => {
            this.selecTedGoiThau = result;
            this.close();
        })


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


    close(): void {

        this.modalSave.emit(null);
        this.modal.hide();
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
