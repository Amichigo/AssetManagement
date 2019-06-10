import { CongTrinhForViewDto, KeHoachXayDungForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { CongTrinhServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewCongTrinhModal',
    templateUrl: './view-congtrinh-modal.component.html'
})

export class ViewCongTrinhModalComponent extends AppComponentBase {

    congtrinh : CongTrinhForViewDto = new CongTrinhForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;
    keHoachForView: KeHoachXayDungForViewDto = new KeHoachXayDungForViewDto();
    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(congtrinhId?: number | null | undefined): void {
        this._congtrinhService.getCongTrinhForView(congtrinhId).subscribe(result => {
            this.congtrinh = result;
            this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView', this.congtrinh.idKeHoach).subscribe(result => {
                this.keHoachForView = result;
            });
        })
    }

    close() : void{
     
    }
}
