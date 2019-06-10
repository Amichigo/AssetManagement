import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CongTrinhServiceProxy, CongTrinhInput, KeHoachXayDungForViewDto } from '@shared/service-proxies/service-proxies';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { ActivatedRoute } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'createCongTrinhModal',
    templateUrl: './create-congtrinh-modal.component.html'
})
export class CreateCongTrinhModalComponent extends AppComponentBase {


    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('congtrinhCombobox') congtrinhCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('selectKeHoachXayDungModal') selectKeHoachXayDungModal: SelectKeHoachXayDungModalComponent;



    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    congtrinh: CongTrinhInput = new CongTrinhInput();
    keHoachForView: KeHoachXayDungForViewDto = new KeHoachXayDungForViewDto();
    idKeHoach: number;
    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(congtrinhId?: number | null | undefined): void {
        this.saving = false;
        this.idKeHoach = 0;
        this.keHoachForView.maKeHoach="";
        this._congtrinhService.getCongTrinhForEdit(congtrinhId).subscribe(result => {
            this.congtrinh = result;
        });
    }

    reset(): void {
        this.saving = false;
        this.congtrinh.id = null;
        this.congtrinh.tenCongTrinh = '';
        this.congtrinh.maLoaiCongTrinh = null;
        this.congtrinh.diaChiCongTrinh = '';
        this.congtrinh.dienTichCongTrinh = null;
        this.congtrinh.kinhPhiDuocDuyet = null;
        this.congtrinh.duKienXayDung = '';
        this.congtrinh.moTaCongTrinh = '';
        this.congtrinh.maCongTrinh = '';

    }

    save(): void {
        console.log("Tu dong luu");
        this.congtrinh.maDuAnXayDungCoBan = "DAXD" + this.congtrinh.maCongTrinh;
        this.congtrinh.tienDoThucHien = "Chưa xây dựng";
        this.congtrinh.chiPhiDaSuDung = 0;
        let input = this.congtrinh;
        this.saving = true;
        console.log("ID");
        this._congtrinhService.createOrEditCongTrinh(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            console.log("ID");
            this.close();
        })
        this.close();
    }
    setThongTinCongTrinh() {
        this._congtrinhService.getCongTrinhForEdit(this.selectKeHoachXayDungModal.selectedIDCongTrinh).subscribe(result => {
           this.congtrinh=result;
        })
        this.idKeHoach = this.selectKeHoachXayDungModal.selectedMaKH;
        this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView', this.idKeHoach).subscribe(result => {
            this.keHoachForView = result;

        });
    }

    close(): void {
        this.modalSave.emit(null);
    }
}
