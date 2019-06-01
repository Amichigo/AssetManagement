import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LegalStatusTypeServiceProxy, LegalStatusTypeInput_9 } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditLegalStatusTypeModal',
    templateUrl: './create-or-edit-legal-status-type.html'
})
export class CreateOrEditLegalStatusTypeModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('LegalStatusTypeCombobox') LegalStatusTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    LegalStatusType: LegalStatusTypeInput_9 = new LegalStatusTypeInput_9();

    constructor(
        injector: Injector,
        private _LegalStatusTypeService: LegalStatusTypeServiceProxy
    ) {
        super(injector);
    }

    show(customerId?: number | null | undefined): void {
        this.saving = false;


        this._LegalStatusTypeService.getLegalStatusTypeForEdit(customerId).subscribe(result => {
            this.LegalStatusType = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.LegalStatusType;
        this.saving = true;
        this._LegalStatusTypeService.createOrEditLegalStatusType(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
