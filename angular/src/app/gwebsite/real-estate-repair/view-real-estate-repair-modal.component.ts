import { RealEstateRepairForViewDto_9 } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { RealEstateRepairServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewRealEstateRepairModal',
    templateUrl: './view-real-estate-repair-modal.component.html'
})

export class ViewRealEstateRepairModalComponent extends AppComponentBase {

    realEstateRepair: RealEstateRepairForViewDto_9 = new RealEstateRepairForViewDto_9();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _realEstateRepairService: RealEstateRepairServiceProxy
    ) {
        super(injector);
    }

    show(customerId?: number | null | undefined): void {
        this._realEstateRepairService.getRealEstateRepairForView(customerId).subscribe(result => {
            this.realEstateRepair = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();

    }
}
