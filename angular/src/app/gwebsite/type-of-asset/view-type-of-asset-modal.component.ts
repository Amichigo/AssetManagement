import { TypeOfAssetForViewDto } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { TypeOfAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewTypeOfAssetModal',
    templateUrl: './view-type-of-asset-modal.component.html'
})

export class ViewTypeOfAssetModalComponent extends AppComponentBase {

    typeOfAsset : TypeOfAssetForViewDto = new TypeOfAssetForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _typeOfAssetService: TypeOfAssetServiceProxy
    ) {
        super(injector);
    }

    show(typeOfAssetId?: number | null | undefined): void {
        this._typeOfAssetService.getTypeOfAssetForView(typeOfAssetId).subscribe(result => {
            this.typeOfAsset = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
