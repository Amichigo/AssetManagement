import {  TaiSanN13ServiceProxy, TaiSanN13ForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewTaiSanModal',
    templateUrl: './view-taisan-modal.component.html'
})

export class ViewTaiSanModalComponent extends AppComponentBase {

    taisan : TaiSanN13ForViewDto = new TaiSanN13ForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _taisanService: TaiSanN13ServiceProxy
    ) {
        super(injector);
    }

    show(taisanId?: number | null | undefined): void {
        this._taisanService.getTaiSanForView(taisanId).subscribe(result => {
            this.taisan = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
