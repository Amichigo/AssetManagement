import { ContractForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ContractServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewHopDongThauModal',
    templateUrl: './view-hopdongthau-modal.component.html'
})

export class ViewHopDongThauModalComponent extends AppComponentBase {

    hopdongthau: ContractForViewDto = new ContractForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _hopdongthauService: ContractServiceProxy
    ) {
        super(injector);
    }

    show(hopdongthauId?: number | null | undefined): void {
        this._hopdongthauService.getContractForView(hopdongthauId).subscribe(result => {
            this.hopdongthau = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
