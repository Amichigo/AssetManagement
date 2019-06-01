import { TypeOfRentalAssetForViewDto } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { TypeOfRentalAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewTypeOfRentalAssetModal',
    templateUrl: './view-type-of-rental-asset-modal.component.html'
})

export class ViewTypeOfRentalAssetModalComponent extends AppComponentBase {

    typeOfRentalAsset : TypeOfRentalAssetForViewDto = new TypeOfRentalAssetForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _typeOfRentalAssetService: TypeOfRentalAssetServiceProxy
    ) {
        super(injector);
    }

    show(typeOfRentalAssetId?: number | null | undefined): void {
        this._typeOfRentalAssetService.getTypeOfRentalAssetForView(typeOfRentalAssetId).subscribe(result => {
            this.typeOfRentalAsset = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
