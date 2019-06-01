import { BidForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { BidServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewHoSoThauModal',
    templateUrl: './view-hosothau-modal.component.html'
})

export class ViewHoSoThauModalComponent extends AppComponentBase {

    hosothau: BidForViewDto = new BidForViewDto();
    @ViewChild('viewHoSoThauModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _hosothauService: BidServiceProxy
    ) {
        super(injector);
    }

    show(hosothauId?: number | null | undefined): void {
        this._hosothauService.getBidForView(hosothauId).subscribe(result => {
            this.hosothau = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
