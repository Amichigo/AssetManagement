import { HoSoThauForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { HoSoThauServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewHoSoThauModal',
    templateUrl: './view-hosothau-modal.component.html'
})

export class ViewHoSoThauModalComponent extends AppComponentBase {

    hosothau : HoSoThauForViewDto = new HoSoThauForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauServiceProxy
    ) {
        super(injector);
    }

    show(hosothauId?: number | null | undefined): void {
        this._hosothauService.getHoSoThauForView(hosothauId).subscribe(result => {
            this.hosothau = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
