import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TypeOfRentalAssetServiceProxy, TypeOfRentalAssetInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditTypeOfRentalAssetModal',
    templateUrl: './create-or-edit-type-of-rental-asset-modal.component.html'
})
export class CreateOrEditTypeOfRentalAssetModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('typeOfRentalAssetCombobox') typeOfRentalAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    // @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    typeOfRentalAsset: TypeOfRentalAssetInput = new TypeOfRentalAssetInput();

    constructor(
        injector: Injector,
        private _typeOfRentalAssetService: TypeOfRentalAssetServiceProxy
    ) {
        super(injector);
    }

    show(typeOfRentalAssetId?: number | null | undefined): void {
        this.saving = false;


        this._typeOfRentalAssetService.getTypeOfRentalAssetForEdit(typeOfRentalAssetId).subscribe(result => {
            this.typeOfRentalAsset = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.typeOfRentalAsset;
        this.saving = true;
        this._typeOfRentalAssetService.createOrEditTypeOfRentalAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
