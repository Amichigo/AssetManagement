import { RealEstateForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { RealEstateServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewRealEstateModal',
    templateUrl: './view-real-estate-management-modal.component.html'
})

export class ViewRealEstateManagementModalComponent extends AppComponentBase {

    realEstate: RealEstateForViewDto = new RealEstateForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _realEstateService: RealEstateServiceProxy
    ) {
        super(injector);
    }

    show(realEstateId?: number | null | undefined): void {
        this._realEstateService.getRealEstateForView(realEstateId).subscribe(result => {
            this.realEstate = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}
