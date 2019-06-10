import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CongTrinhServiceProxy, CongTrinhInput, DonViThauN13ServiceProxy, DonViThauN13Input} from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createDonViThauN13Modal',
    templateUrl: './create-donvithaun13-modal.component.html'
})
export class CreateDonViThauN13Component extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('congtrinhCombobox') congtrinhCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    checkbox: any;
    isSaveToDatabase: boolean = false;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    isActive: boolean = false;
    donViThauIp: DonViThauN13Input = new DonViThauN13Input();

    constructor(
        injector: Injector,
        private _donViThauAppService: DonViThauN13ServiceProxy,
    ) {
        super(injector);
    }
    reset(): void {
        this.donViThauIp.maDonViThau = "";
        this.donViThauIp.giaChaoThau = null;
        this.donViThauIp.hinhThucBaoLanh = '';
        this.donViThauIp.isTrungThau = null;
        this.donViThauIp.id = null;
        this.donViThauIp.ngayNopHoSoThau = null;
    }

    show(mahst:number,congtrinhId?: number | null | undefined): void {
        this.saving = false;
        this._donViThauAppService.getDonViThauForEdit(congtrinhId).subscribe(result => {
            this.donViThauIp = result;
            if(this.isSaveToDatabase==true){
                this.donViThauIp.idHoSoThau=mahst;
            }
            this.modal.show();

        })
       

    }

    save(): void {

        if (this.isSaveToDatabase == true) {
            let input = this.donViThauIp;
            this.saving = true;
            this._donViThauAppService.createOrEditDonViThau(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })
        }
        this.saving = true;
        this.modal.hide();
        this.modalSave.emit(null);
    }

    close(): void {
        this.modal.hide();
    }

}
