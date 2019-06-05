import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CongTrinhServiceProxy, CongTrinhInput, DonViThauInput, DonViThauServiceProxy } from '@shared/service-proxies/service-proxies';
    
@Component({
    selector: 'createDonViThauN13Modal',
    templateUrl: './create-donvithaun13-modal.component.html'
})
export class CreateDonViThauN13Component extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('congtrinhCombobox') congtrinhCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    checkbox:any;
     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    isActive:boolean=false;
    donViThauIp:DonViThauInput=new DonViThauInput();

    constructor(
        injector: Injector,
        private _donViThauAppService: DonViThauServiceProxy,
    ) {
        super(injector);
    }
    reset():void{
        this.donViThauIp.maDonViThau="";
        this.donViThauIp.giaChaoThau=null;
        this.donViThauIp.hinhThucBaoLanh='';
        this.donViThauIp.isTrungThau=null;
        this.donViThauIp.id=null;
        this.donViThauIp.ngayNopHoSoThau=null;
    }

    show(congtrinhId?: number | null | undefined): void {   
        this.donViThauIp=new DonViThauInput();
        this.saving=false;
        this._donViThauAppService.getDonViThauForEdit(congtrinhId).subscribe(result => {
            this.donViThauIp = result;
            this.modal.show();

        })
     
    }

    save(): void {
        // let input = this.congtrinh;
        // this.saving = true;
        // this._congtrinhService.createOrEditCongTrinh(input).subscribe(result => {
        //     this.notify.info(this.l('SavedSuccessfully'));
        //     this.close();
        // })
        this.saving = true;
        this.modal.hide(); 
        this.modalSave.emit(null);
    }

    close(): void {
        this.modal.hide(); 
    }

}
