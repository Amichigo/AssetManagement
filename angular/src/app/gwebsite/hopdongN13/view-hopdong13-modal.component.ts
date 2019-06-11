import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

import { HoSoThauN13Input, HoSoThauN13ServiceProxy, CongTrinhInput, CongTrinhForViewDto, HopDongN13ServiceProxy, HoSoThauN13ForViewDto, HopDongN13Input, ThanhToanN13Input, ThanhToanN13ServiceProxy, KeHoachXayDungForViewDto, DonViThauN13ForViewDto } from '@shared/service-proxies/service-proxies';

import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';

@Component({
    selector: 'viewHopDongN13Modal',
    templateUrl: './view-hopdong13-modal.component.html'
})
export class ViewHopDongN13ModalComponent extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    inputvalue: string;
    dsThanhToan: Array<ThanhToanN13Input> = [];
    congtrinhForView: CongTrinhForViewDto = new CongTrinhForViewDto();
    goiThauForView: HoSoThauN13ForViewDto = new HoSoThauN13ForViewDto();
    keHoachForView: KeHoachXayDungForViewDto = new KeHoachXayDungForViewDto();
    donViThauForView: DonViThauN13ForViewDto = new DonViThauN13ForViewDto();
    madvtt: string;
    tendvtt: string;
    hopDongInput: HopDongN13Input = new HopDongN13Input();
    constructor(
        injector: Injector,
        private _hopDong: HopDongN13ServiceProxy,
        private _thanhtoanService: ThanhToanN13ServiceProxy,
        private _apiService: WebApiServiceProxy,

    ) {
        super(injector);
    }

    show(id: number): void {

        this.saving = false;
        this.dsThanhToan = [];
        this.saving = false;
        this._hopDong.getHopDongForEdit(id).subscribe(result => {
            this.hopDongInput = result;
            if (this.hopDongInput.id == null) return;
            this._apiService.getForEdit('api/HoSoThauN13/GetHoSoThauByIdHopDongForView', this.hopDongInput.id).subscribe(result => {
                this.goiThauForView = result;
                console.log(this.goiThauForView.id);
                if (this.goiThauForView.idCongTrinh == null) return;
                this._apiService.getForEdit('api/CongTrinh/GetCongTrinhForView', this.goiThauForView.idCongTrinh).subscribe(result => {
                    this.congtrinhForView = result;
                    console.log(this.congtrinhForView.idKeHoach);
                    if (this.congtrinhForView.idKeHoach == null) return;
                    this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView', this.congtrinhForView.idKeHoach).subscribe(rs => {
                        this.keHoachForView = rs;
                        console.log("Chay toi day 1");
                        if (this.goiThauForView.id == null) return;
                        this._apiService.getForEdit('api/DonViThauN13/GetDonViThauByIdGoiThauForView', this.goiThauForView.id).subscribe(rt => {
                            this.donViThauForView = rt;
                            console.log("Chay toi day 2");
                        });
                    });
                });
            
                this.reloadList(this.hopDongInput.id);
            });
            this.modal.show();
        })

    }

  

    reset(): void {
    }


    save(): void {

        this.close();
    }
    SetThongTinCongTrinh(): void {

        if (this.congtrinhForView.idKeHoach == null) return;
        this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView', this.congtrinhForView.idKeHoach).subscribe(result => {
            this.keHoachForView = result;

        });
        if (this.goiThauForView.id == null) return;
        this._apiService.getForEdit('api/DonViThauN13/GetDonViThauByIdGoiThauForView', this.goiThauForView.id).subscribe(result => {
            this.donViThauForView = result;
        });

    }
    close(): void {
        this.modalSave.emit(null);
    }
    reloadList(idHopDong, event?: LazyLoadEvent) {
        this._thanhtoanService.getThanhToanN13sByFilter(idHopDong, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }
    getThanhToans(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.hopDongInput.id, event);

    }

   
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
