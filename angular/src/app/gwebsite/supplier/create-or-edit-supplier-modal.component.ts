import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SupplierServiceProxy, SupplierInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditSupplierModal',
    templateUrl: './create-or-edit-supplier-modal.component.html'
})
export class CreateOrEditSupplierModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('supplierCombobox') supplierCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
    * @Output dùng để public event cho component khác xử lý
    */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    supplier: SupplierInput = new SupplierInput();

    constructor(
        injector: Injector,
        private _supplierService: SupplierServiceProxy
    ) {
        super(injector);
    }

    show(supplierId?: number | null | undefined): void {
        this.saving = false;


        this._supplierService.getSupplierForEdit(supplierId).subscribe(result => {
            this.supplier = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.supplier;
        this.saving = true;
        this._supplierService.createOrEditSupplier(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}