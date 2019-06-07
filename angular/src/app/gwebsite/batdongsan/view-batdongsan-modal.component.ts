import { BatDongSanForViewDto, SuaChuaBatDongSanServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { BatDongSanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';

@Component({
    selector: 'viewBatDongSanModal',
    templateUrl: './view-batdongsan-modal.component.html'
})

export class ViewBatDongSanModalComponent extends AppComponentBase {

    batdongsan : BatDongSanForViewDto = new BatDongSanForViewDto();
    mataisan:string;
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('dataTable') dataTable: Table;
    constructor(
        injector: Injector,
        private _batdongsanService: BatDongSanServiceProxy,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy,
    ) {
        super(injector);
    }

    show(batdongsanId?: number | null | undefined): void {
        this._batdongsanService.getBatDongSanForView(batdongsanId).subscribe(result => {
            this.batdongsan = result;
            this.mataisan=this.batdongsan.maTaiSan;
            this.reloadList(this.mataisan,null,null,null);
            this.modal.show();
        })
    }
    
    getSuaChuaBatDongSans(event?: LazyLoadEvent) {
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

    reloadList(maTaiSan, ngayDeXuat, ngaySuaXong, event?: LazyLoadEvent) {
        this._suachuabatdongsanService.getSuaChuaBatDongSansByFilter(maTaiSan, null, null, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
  
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    close() : void{
        this.modal.hide();
    }
}
