import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetActivityServiceProxy, AssetActivityInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditAssetActivityModal',
    templateUrl: './create-or-edit-asset-activity-modal.component.html'
})
export class CreateOrEditAssetActivityModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('assetActivityCombobox') assetActivityCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    assetActivity: AssetActivityInput = new AssetActivityInput();

    constructor(
        injector: Injector,
        private _assetActivityService: AssetActivityServiceProxy
    ) {
        super(injector);
    }

    pad(n, width) {
        n = n + '';
        return n.length >= width ? n : new Array(width - n.length + 1).join('0') + n;
    }

    show(assetActivityId?: number | null | undefined): void {
        this.saving = false;


        this._assetActivityService.getAssetActivityForEdit(assetActivityId).subscribe(result => {
            this.assetActivity = result;
            const executionTime = new Date(this.assetActivity.executionTime);
            this.assetActivity.executionTime = `${ executionTime.getFullYear() }-${ this.pad(executionTime.getMonth() + 1, 2) }-${ this.pad(executionTime.getDate(), 2) }`;;
            this.modal.show();

        })
    }

    save(): void {

        let input = this.assetActivity;
        console.log(input);
        this.saving = true;
        this._assetActivityService.createOrEditAssetActivity(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
