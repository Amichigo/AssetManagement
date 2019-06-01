import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { FormOfRentingAssetServiceProxy, FormOfRentingAssetInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditFormOfRentingAssetModal',
    templateUrl: './create-or-edit-form-of-renting-asset-modal.component.html'
})
export class CreateOrEditFormOfRentingAssetModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('formOfRentingAssetCombobox') formOfRentingAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    // @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    formOfRentingAsset: FormOfRentingAssetInput = new FormOfRentingAssetInput();

    constructor(
        injector: Injector,
        private _formOfRentingAssetService: FormOfRentingAssetServiceProxy
    ) {
        super(injector);
    }

    show(formOfRentingAssetId?: number | null | undefined): void {
        this.saving = false;


        this._formOfRentingAssetService.getFormOfRentingAssetForEdit(formOfRentingAssetId).subscribe(result => {
            this.formOfRentingAsset = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.formOfRentingAsset;
        this.saving = true;
        this._formOfRentingAssetService.createOrEditFormOfRentingAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
