import { PhieuGoiHangForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { PhieuGoiHangServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewPhieuGoiHangModal',
    templateUrl: './view-phieugoihang-modal.component.html'
})

export class ViewPhieuGoiHangModalComponent extends AppComponentBase {

    phieugoihang : PhieuGoiHangForViewDto = new PhieuGoiHangForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _phieugoihangService: PhieuGoiHangServiceProxy
    ) {
        super(injector);
    }

    show(phieugoihangId?: number | null | undefined): void {
        this._phieugoihangService.getPhieuGoiHangForView(phieugoihangId).subscribe(result => {
            this.phieugoihang = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
