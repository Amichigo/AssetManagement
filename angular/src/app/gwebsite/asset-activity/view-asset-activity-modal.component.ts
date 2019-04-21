import { AssetActivityForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { AssetActivityServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewAssetActivityModal',
    templateUrl: './view-asset-activity-modal.component.html'
})

export class ViewAssetActivityModalComponent extends AppComponentBase {

    assetActivity : AssetActivityForViewDto = new AssetActivityForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _assetActivityService: AssetActivityServiceProxy
    ) {
        super(injector);
    }

    show(assetActivityId?: number | null | undefined): void {
        this._assetActivityService.getAssetActivityForView(assetActivityId).subscribe(result => {
            this.assetActivity = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}