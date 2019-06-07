import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { HoSoThauN13Input, HoSoThauN13ServiceProxy, CongTrinhInput, CongTrinhForViewDto, CongTrinhServiceProxy, DonViThauN13ServiceProxy, DonViThauN13Input } from '@shared/service-proxies/service-proxies';
import { SelectCongTrinhN13ModalComponent } from './select-congtrinhn13-modal.component';
import { CreateDonViThauN13Component } from './create-donvithaun13-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
    
@Component({
    selector: 'editHoSoThauN13Modal',
    templateUrl: './edit-hosothau13-modal.component.html'
})
export class EditHoSoThauN13ModalComponent extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;    
    @ViewChild('selectCongTrinhN13Modal') selectCongTrinhN13Modal: SelectCongTrinhN13ModalComponent;
    @ViewChild('createDonViThauN13Modal') createDonViThauN13Modal:CreateDonViThauN13Component;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    
    hosothau: HoSoThauN13Input = new HoSoThauN13Input();
    congTrinhForView:CongTrinhForViewDto=new CongTrinhForViewDto();
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
            this._congtrinhService.getCongTrinhForViewByMCT(this.hosothau.maCongTrinh).subscribe(result => {
                this.congTrinhForView = result;
            });
            this.reloadList(null,this.hosothau.maHoSoThau,null);
            this.modal.show();
        });
        
    }

    showSelectCongTrinh(){
        this.selectCongTrinhN13Modal.show();
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

        this.reloadList(null, this.hosothau.maHoSoThau, null, event);

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
    ShowDonViThau():void{
        
        this.createDonViThauN13Modal.isSaveToDatabase=true;
        this.createDonViThauN13Modal.show(this.hosothau.maHoSoThau);
    }
    UpdateDonViThau(id:number){
        this.createDonViThauN13Modal.isSaveToDatabase=true;
        this.createDonViThauN13Modal.show(this.hosothau.maHoSoThau,id);
    }
    save(): void {
        let input = this.hosothau;
        this.saving = true;

        this._hosothauService.createOrEditHoSoThau(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            // for(let item of this.dsDonViThau){
            //     item.maGoiThau=this.hosothau.maHoSoThau+"_"+this.hosothau.maCongTrinh;
            //     let dv=item;
            //     this._donvithauService.createOrEditDonViThau(dv).subscribe(rs=>{
            //         this.notify.info(this.l('Lưu đơn vị thành công'));
            //     })
            // }
            this.close();
        })
        // this.close();
    }

    deleteDonViThau(id): void {
        this._donViThauService.deleteDonViThau(id).subscribe(() => {
            this.reloadPage();
        })
    }
    SetThongTinCongTrinh():void{
        this.congTrinhForView=this.selectCongTrinhN13Modal.congtrinhForView;
        console.log(this.congTrinhForView.maCongTrinh);
    }
    close(): void {
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
