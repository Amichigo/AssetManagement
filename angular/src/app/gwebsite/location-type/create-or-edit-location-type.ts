import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LocationTypeServiceProxy, LocationTypeInput_9 } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditLocationTypeModal',
    templateUrl: './create-or-edit-location-type.html'
})
export class CreateOrEditLocationTypeModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('LocationTypeCombobox') LocationTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    LocationType: LocationTypeInput_9 = new LocationTypeInput_9();

    constructor(
        injector: Injector,
        private _LocationTypeService: LocationTypeServiceProxy
    ) {
        super(injector);
    }

    show(customerId?: number | null | undefined): void {
        this.saving = false;


        this._LocationTypeService.getLocationTypeForEdit(customerId).subscribe(result => {
            this.LocationType = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.LocationType;
        this.saving = true;
        this._LocationTypeService.createOrEditLocationType(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
