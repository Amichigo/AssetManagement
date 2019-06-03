import { GoodsInvoiceForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { GoodsInvoiceServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewPhieuGoiHangModal',
    templateUrl: './view-phieugoihang-modal.component.html'
})

export class ViewPhieuGoiHangModalComponent extends AppComponentBase {

    phieugoihang: GoodsInvoiceForViewDto = new GoodsInvoiceForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _phieugoihangService: GoodsInvoiceServiceProxy
    ) {
        super(injector);
    }

    show(phieugoihangId?: number | null | undefined): void {
        this._phieugoihangService.getGoodsInvoiceForView(phieugoihangId).subscribe(result => {
            this.phieugoihang = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
