import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { FixedAssetServiceProxy, FixedAssetInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditFixedAssetModal',
    templateUrl: './create-or-edit-fixed-asset-modal.component.html',
})

export class CreateOrEditFixedAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('fixedAssetCombobox') fixedAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    fixedAsset: FixedAssetInput = new FixedAssetInput();
    typeAssets = ["fixed assets", "labor assets"];
    statusAsset = ["true", "false"];

    constructor(
        injector: Injector,
        private _fixedAssetService: FixedAssetServiceProxy
    ) {
        super(injector);
        this.fixedAsset.typeofAsset = "fixed assets";
    }

    show(fixedAssetId?: number | null | undefined): void {
        this.saving = false;

        this._fixedAssetService.getFixedAssetForEdit(fixedAssetId).subscribe(result => {
            this.fixedAsset = result;
            this.modal.show();
        });
    }

    save(): void {
        let input = this.fixedAsset;
        this.saving = true;
        this._fixedAssetService.createOrEditFixedAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
