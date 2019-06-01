import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild } from "@angular/core";
import { AssetRentingContractServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { AssetRentingContractDto } from './dto/asset-renting-contract-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'viewAssetRentingContractModal',
    templateUrl: './view-asset-renting-contract-modal.component.html'
})

export class ViewAssetRentingContractModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;

    assetRentingContract: AssetRentingContractDto = new AssetRentingContractDto();

    constructor(
        injector: Injector,
        private assetRentingContractId: AssetRentingContractServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(assetRentingContractId?: number | null | undefined): void {
        this._apiService.getForEdit('api/AssetRentingContract/GetAssetRentingContractForEdit', assetRentingContractId
        ).subscribe(async result => {
            await this.setAssetRentingContracts(result);
            this.assetRentingContract = result;
            this.modal.show();
        });
    }

    setAssetRentingContracts(assetRentingContract: AssetRentingContractDto): void {
        this._apiService.get('api/AssetRentingFile/GetAssetRentingFilesByFilter'
        ).subscribe(result => {
            for (let fileCode of result.items) {
                if (fileCode.id.toString() === assetRentingContract.fileCode) {
                    assetRentingContract.fileCode = { ...fileCode };
                }
            }
        });
    }

    close(): void {
        this.modal.hide();
    }
}