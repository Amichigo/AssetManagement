import { DuAnForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { DuAnServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewDuAnModal',
    templateUrl: './view-duan-modal.component.html'
})

export class ViewDuAnModalComponent extends AppComponentBase {

    duan : DuAnForViewDto = new DuAnForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _duanService: DuAnServiceProxy
    ) {
        super(injector);
    }

    show(duanId?: number | null | undefined): void {
        this._duanService.getDuAnForView(duanId).subscribe(result => {
            this.duan = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
