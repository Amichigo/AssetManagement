import { SuaChuaBatDongSanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { SuaChuaBatDongSanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewSuaChuaBatDongSanModal',
    templateUrl: './view-suachuabatdongsan-modal.component.html'
})

export class ViewSuaChuaBatDongSanModalComponent extends AppComponentBase {

    suachuabatdongsan : SuaChuaBatDongSanForViewDto = new SuaChuaBatDongSanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy
    ) {
        super(injector);
    }

    show(suachuabatdongsanId?: number | null | undefined): void {
        this._suachuabatdongsanService.getSuaChuaBatDongSanForView(suachuabatdongsanId).subscribe(result => {
            this.suachuabatdongsan = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
