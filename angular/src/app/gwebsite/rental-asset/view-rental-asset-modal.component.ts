import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild } from "@angular/core";
import { RentalAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { RentalAssetDto } from './dto/rental-asset-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'viewRentalAssetModal',
    templateUrl: './view-rental-asset-modal.component.html'
})

export class ViewRentalAssetModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;

    rentalAsset: RentalAssetDto = new RentalAssetDto();

    constructor(
        injector: Injector,
        private rentalAssetId: RentalAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(rentalAssetId?: number | null | undefined): void {
        this._apiService.getForEdit('api/RentalAsset/GetRentalAssetForEdit', rentalAssetId
        ).subscribe(async result => {
            await this.setRentalAssets(result);
            this.rentalAsset = result;
            this.modal.show();
        });
    }

    setRentalAssets(rentalAsset: RentalAssetDto): void {
        this._apiService.get('api/TypeOfRentalAsset/GetTypeOfRentalAssetsByFilter'
        ).subscribe(result => {
            for (let typeOfAsset of result.items) {
                if (typeOfAsset.id.toString() === rentalAsset.typeOfAsset) {
                    rentalAsset.typeOfAsset = { ...typeOfAsset };
                }
            }
        });
    }

    close(): void {
        this.modal.hide();
    }
}