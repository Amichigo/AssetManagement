import { RentalAssetForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { RentalAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewRentalAssetModal',
    templateUrl: './view-rental-asset-modal.component.html'
})

export class ViewRentalAssetModalComponent extends AppComponentBase {

    rentalAsset : RentalAssetForViewDto = new RentalAssetForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _rentalAssetService: RentalAssetServiceProxy
    ) {
        super(injector);
    }

    show(rentalAssetId?: number | null | undefined): void {
        this._rentalAssetService.getRentalAssetForView(rentalAssetId).subscribe(result => {
            this.rentalAsset = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
