import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RealEstateServiceProxy, RealEstateInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditRealEstateManagementModal',
    templateUrl: './create-or-edit-real-estate-management-modal.component.html'
})
export class CreateOrEditRealEstateManagementModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('realEstateCombobox') realEstateCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    realEstate: RealEstateInput = new RealEstateInput();

    constructor(
        injector: Injector,
        private _realEstateService: RealEstateServiceProxy
    ) {
        super(injector);
    }

    show(realEstateId?: number | null | undefined): void {
        this.saving = false;


        this._realEstateService.getRealEstateForEdit(realEstateId).subscribe(result => {
            this.realEstate = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.realEstate;
        this.saving = true;
        this._realEstateService.createOrEditRealEstate(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
