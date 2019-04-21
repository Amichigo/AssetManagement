import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { HienTrangPhapLyServiceProxy, HienTrangPhapLyInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditHienTrangPhapLyModal',
    templateUrl: './create-or-edit-hientrangphaply-modal.component.html'
})
export class CreateOrEditHienTrangPhapLyModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hientrangphaplyCombobox') hientrangphaplyCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hientrangphaply: HienTrangPhapLyInput = new HienTrangPhapLyInput();

    constructor(
        injector: Injector,
        private _hientrangphaplyService: HienTrangPhapLyServiceProxy
    ) {
        super(injector);
    }

    show(hientrangphaplyId?: number | null | undefined): void {
        this.saving = false;


        this._hientrangphaplyService.getHienTrangPhapLyForEdit(hientrangphaplyId).subscribe(result => {
            this.hientrangphaply = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.hientrangphaply;
        this.saving = true;
        this._hientrangphaplyService.createOrEditHienTrangPhapLy(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
