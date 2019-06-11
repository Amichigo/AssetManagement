import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { HoSoThauN13Input, HoSoThauN13ServiceProxy, CongTrinhInput, CongTrinhForViewDto, CongTrinhServiceProxy, DonViThauN13ServiceProxy, DonViThauN13Input, KeHoachXayDungForViewDto } from '@shared/service-proxies/service-proxies';
import { SelectCongTrinhN13ModalComponent } from './select-congtrinhn13-modal.component';
import { CreateDonViThauN13Component } from './create-donvithaun13-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
    
@Component({
    selector: 'viewHoSoThauN13Modal',
    templateUrl: './view-hosothau13-modal.component.html'
})
export class ViewHoSoThauN13ModalComponent extends AppComponentBase {

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
    
    hosothau: HoSoThauN13Input = new HoSoThauN13Input();
    congTrinhForView:CongTrinhForViewDto=new CongTrinhForViewDto();
    keHoachForView:KeHoachXayDungForViewDto=new KeHoachXayDungForViewDto();
    dsDonViThau: Array<DonViThauN13Input>=[];
    donVitest:DonViThauN13Input=new DonViThauN13Input()
    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauN13ServiceProxy,
        private _congtrinhService: CongTrinhServiceProxy,
        private _donViThauService:DonViThauN13ServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(id:number): void {
        this.dsDonViThau=[];
        this.saving = false;
        this._hosothauService.getHoSoThauForEdit(id).subscribe(result => {
            this.hosothau = result;
            this._congtrinhService.getCongTrinhForView(this.hosothau.idCongTrinh).subscribe(result => {
                this.congTrinhForView = result;
                if(this.congTrinhForView.idKeHoach!=null){
                    this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView',this.congTrinhForView.idKeHoach).subscribe(result => {
                        this.keHoachForView=result;
            
                    });
                }
            });
            this.reloadList(null,this.hosothau.id,null);
            this.modal.show();
        });
        
    }

  

    reset():void{
        this.dsDonViThau=[];
    }


      /**
     * Hàm get danh sách HoSoThau
     * @param event
     */
    getDonViThaus(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, this.hosothau.id, null, event);

    }

    reloadList(hosothauName, mahosothau, maKeHoach, event?: LazyLoadEvent) {
        this._donViThauService.getDonViThausByFilter(null,mahosothau, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteHoSoThau(id): void {
        this._hosothauService.deleteHoSoThau(id).subscribe(() => {
            this.reloadPage();
        })
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
  
    save(): void {

            this.close();
      
    }

    deleteDonViThau(id): void {
        this._donViThauService.deleteDonViThau(id).subscribe(() => {
            this.reloadPage();
        })
    }

    close(): void {
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
