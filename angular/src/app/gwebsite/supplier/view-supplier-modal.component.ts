import { SupplierForViewDto } from './../../../shared/service-proxies/service-proxies';
    import { AppComponentBase } from "@shared/common/app-component-base";
    import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
    import { SupplierServiceProxy } from "@shared/service-proxies/service-proxies";
    import { ModalDirective } from 'ngx-bootstrap';

    @Component({
        selector: 'viewSupplierModal',
        templateUrl: './view-supplier-modal.component.html'
    })

    export class ViewSupplierModalComponent extends AppComponentBase {

        supplier : SupplierForViewDto = new SupplierForViewDto();
        @ViewChild('viewModal') modal: ModalDirective;

        constructor(
            injector: Injector,
            private _supplierService: SupplierServiceProxy
        ) {
            super(injector);
        }

        show(supplierId?: number | null | undefined): void {
            this._supplierService.getSupplierForView(supplierId).subscribe(result => {
                this.supplier = result;
                this.modal.show();
            })
        }

        close() : void{
            this.modal.hide();
        }
    }