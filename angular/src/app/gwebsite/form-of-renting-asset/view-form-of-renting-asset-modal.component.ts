import { FormOfRentingAssetForViewDto } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { FormOfRentingAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewFormOfRentingAssetModal',
    templateUrl: './view-form-of-renting-asset-modal.component.html'
})

export class ViewFormOfRentingAssetModalComponent extends AppComponentBase {

    formOfRentingAsset : FormOfRentingAssetForViewDto = new FormOfRentingAssetForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _formOfRentingAssetService: FormOfRentingAssetServiceProxy
    ) {
        super(injector);
    }

    show(formOfRentingAssetId?: number | null | undefined): void {
        this._formOfRentingAssetService.getFormOfRentingAssetForView(formOfRentingAssetId).subscribe(result => {
            this.formOfRentingAsset = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
