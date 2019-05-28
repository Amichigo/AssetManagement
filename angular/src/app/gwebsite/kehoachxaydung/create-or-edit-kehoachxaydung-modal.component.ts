import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { KeHoachXayDungServiceProxy, KeHoachXayDungInput } from '@shared/service-proxies/service-proxies';
    
@Component({
    selector: 'createOrEditKeHoachXayDungModal',
    templateUrl: './create-or-edit-kehoachxaydung-modal.component.html'
})
export class CreateOrEditKeHoachXayDungModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('kehoachxaydungCombobox') kehoachxaydungCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    kehoachxaydung: KeHoachXayDungInput = new KeHoachXayDungInput();

    constructor(
        injector: Injector,
        private _kehoachxaydungService: KeHoachXayDungServiceProxy
    ) {
        super(injector);
    }

    show(kehoachxaydungId?: number | null | undefined): void {
        this.saving = false;


        this._kehoachxaydungService.getKeHoachXayDungForEdit(kehoachxaydungId).subscribe(result => {
            this.kehoachxaydung = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.kehoachxaydung;
        this.saving = true;
        this._kehoachxaydungService.createOrEditKeHoachXayDung(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
