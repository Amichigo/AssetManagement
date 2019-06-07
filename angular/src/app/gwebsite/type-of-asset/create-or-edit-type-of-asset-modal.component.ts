import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TypeOfAssetServiceProxy, TypeOfAssetInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditTypeOfAssetModal',
    templateUrl: './create-or-edit-type-of-asset-modal.component.html'
})
export class CreateOrEditTypeOfAssetModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('typeOfAssetCombobox') typeOfAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    // @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    typeOfAsset: TypeOfAssetInput = new TypeOfAssetInput();

    constructor(
        injector: Injector,
        private _typeOfAssetService: TypeOfAssetServiceProxy
    ) {
        super(injector);
    }

    show(typeOfAssetId?: number | null | undefined): void {
        this.saving = false;


        this._typeOfAssetService.getTypeOfAssetForEdit(typeOfAssetId).subscribe(result => {
            this.typeOfAsset = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.typeOfAsset;
        this.saving = true;
        this._typeOfAssetService.createOrEditTypeOfAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
