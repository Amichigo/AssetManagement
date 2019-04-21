import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BatDongSanServiceProxy, BatDongSanInput } from '@shared/service-proxies/service-proxies';
    
@Component({
    selector: 'createOrEditBatDongSanModal',
    templateUrl: './create-or-edit-batdongsan-modal.component.html'
})
export class CreateOrEditBatDongSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('batdongsanCombobox') batdongsanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    batdongsan: BatDongSanInput = new BatDongSanInput();

    constructor(
        injector: Injector,
        private _batdongsanService: BatDongSanServiceProxy
    ) {
        super(injector);
    }

    show(batdongsanId?: number | null | undefined): void {
        this.saving = false;


        this._batdongsanService.getBatDongSanForEdit(batdongsanId).subscribe(result => {
            this.batdongsan = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.batdongsan;
        this.saving = true;
        this._batdongsanService.createOrEditBatDongSan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
