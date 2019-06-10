import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CongTrinhServiceProxy, CongTrinhInput, KeHoachXayDungForViewDto } from '@shared/service-proxies/service-proxies';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
    
@Component({
    selector: 'editCongTrinhModal',
    templateUrl: './edit-congtrinh-modal.component.html'
})
export class EditCongTrinhModalComponent extends AppComponentBase {


    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('congtrinhCombobox') congtrinhCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    keHoachForView: KeHoachXayDungForViewDto = new KeHoachXayDungForViewDto();
    congtrinh: CongTrinhInput = new CongTrinhInput();


    makh:string;
    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(congtrinhId?: number | null | undefined): void {
        this.saving = false;
        this._congtrinhService.getCongTrinhForEdit(congtrinhId).subscribe(result => {
            this.congtrinh = result;
            this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView', this.congtrinh.idKeHoach).subscribe(result => {
                this.keHoachForView = result;
            });
            this.modal.show();
        });

     
    }

    reset():void{
        this.saving = false;
        this.congtrinh.id=null;
        this.congtrinh.tenCongTrinh='';
        this.congtrinh.maLoaiCongTrinh=null;
        this.congtrinh.diaChiCongTrinh='';
        this.congtrinh.dienTichCongTrinh=null;
        this.congtrinh.kinhPhiDuocDuyet=null;
        this.congtrinh.duKienXayDung='';
        this.congtrinh.moTaCongTrinh='';
        this.congtrinh.maCongTrinh='';
        this.makh='';
    }

    save(): void {
        console.log("Tu dong luu");
        let input = this.congtrinh;
        this.saving = true;
        this._congtrinhService.createOrEditCongTrinh(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modalSave.emit(null);
    }
}
