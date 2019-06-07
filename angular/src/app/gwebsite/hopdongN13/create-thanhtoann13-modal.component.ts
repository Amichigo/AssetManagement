import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CongTrinhServiceProxy, CongTrinhInput, ThanhToanN13ServiceProxy, ThanhToanN13Input} from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createThanhToan13Modal',
    templateUrl: './create-thanhtoann13-modal.component.html'
})
export class CreateThanhToanN13Component extends AppComponentBase {


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
    ThanhToanIp: ThanhToanN13Input = new ThanhToanN13Input();

    constructor(
        injector: Injector,
        private _ThanhToanAppService: ThanhToanN13ServiceProxy,
    ) {
        super(injector);
    }
    reset(): void {
       
    }

    show(mahst:string,congtrinhId?: number | null | undefined): void {
        this.saving = false;
        this._ThanhToanAppService.getThanhToanN13ForEdit(congtrinhId).subscribe(result => {
            this.ThanhToanIp = result;
            if(this.isSaveToDatabase==true){
                this.ThanhToanIp.maHopDong=mahst;
            }
            this.modal.show();

        })
       

    }

    save(): void {

        if (this.isSaveToDatabase == true) {
            let input = this.ThanhToanIp;
            this.saving = true;
            this._ThanhToanAppService.createOrEditThanhToanN13(input).subscribe(result => {
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
