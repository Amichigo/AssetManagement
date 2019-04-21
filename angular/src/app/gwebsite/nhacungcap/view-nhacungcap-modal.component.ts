import { NhaCungCapForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { NhaCungCapServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewNhaCungCapModal',
    templateUrl: './view-nhacungcap-modal.component.html'
})

export class ViewNhaCungCapModalComponent extends AppComponentBase {

    nhacungcap : NhaCungCapForViewDto = new NhaCungCapForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _nhacungcapService: NhaCungCapServiceProxy
    ) {
        super(injector);
    }

    show(nhacungcapId?: number | null | undefined): void {
        this._nhacungcapService.getNhaCungCapForView(nhacungcapId).subscribe(result => {
            this.nhacungcap = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
