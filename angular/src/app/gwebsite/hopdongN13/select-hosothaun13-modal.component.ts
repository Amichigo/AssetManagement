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
    selector: 'selectHoSoThauN13Modal',
    templateUrl: './select-hosothaun13-modal.component.html'
})

export class SelectHoSoThauN13ModalComponent extends AppComponentBase {

    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauN13ServiceProxy,
        private _congtrinhService:CongTrinhServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }


    hosothauName: string;
    mahosothau: string;
    maKeHoach: string;
    loaihosothau: string;

    maDVTrungThau:string;
    tenDVTrungThau:string;
   public selectedCongTrinh:CongTrinhForViewDto=new CongTrinhForViewDto(); 
   public selecTedGoiThau: HoSoThauN13ForViewDto=new HoSoThauN13ForViewDto();

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(): void {
        this.maDVTrungThau='';
        this.tenDVTrungThau='';
        console.log("Show");
        // this._congtrinhService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter

        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.hosothauName = params['TenHoSoThau'] || '';
            this.mahosothau = params['MaHoSoThau'] || '';
            this.maKeHoach = params['MamaKeHoach'] || '';
            this.loaihosothau = params['MaLoaiHoSoThau'] || '';
            this.reloadList(this.hosothauName, this.mahosothau, this.maKeHoach, null);
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

        this.reloadList(null, null, null, event);

    }

    reloadList(hosothauName, mahosothau, maKeHoach, event?: LazyLoadEvent) {
        this._hosothauService.getDSHoSoThauChoHopDong(mahosothau, maKeHoach, hosothauName, null, null, null, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }



    SetThongTin(id:number,idct:number,madktt:string,tenDVTrungThau:string):void{
        console.log("id"+id+ "    IdCT"+idct);
        this._hosothauService.getHoSoThauForView(id).subscribe(result => {
            this.selecTedGoiThau = result;
            this._congtrinhService.getCongTrinhForView(idct).subscribe(rs => {
                this.selectedCongTrinh = rs;
                this.maDVTrungThau=madktt;
                this.tenDVTrungThau=tenDVTrungThau;
                this.close();
            })
        })
       
     
        // this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
        //     this.listItems = result.items;
        // });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.hosothauName, this.mahosothau, this.maKeHoach, null);

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
