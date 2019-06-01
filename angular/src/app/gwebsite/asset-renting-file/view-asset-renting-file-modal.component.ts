import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';
import { AssetRentingFileDto } from './dto/asset-renting-file-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewAssetRentingFileModal',
    templateUrl: './view-asset-renting-file-modal.component.html'
})

export class ViewAssetRentingFileModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;

    assetRentingFile: AssetRentingFileDto = new AssetRentingFileDto();

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(assetRentingFileId?: number | null | undefined): void {
        this._apiService.getForEdit('api/AssetRentingFile/GetAssetRentingFileForEdit', assetRentingFileId
        ).subscribe(async result => {
            await this.setAssetRentingFilesToGetAssetCode(result);
            await this.setAssetRentingFilesToGetFormOfRenting(result);
            this.assetRentingFile = result;
            this.modal.show();
        })
    }

    setAssetRentingFilesToGetAssetCode(assetRentingFile: AssetRentingFileDto): void {
        this._apiService.get('api/RentalAsset/GetRentalAssetsByFilter'
        ).subscribe(result => {
            for (let assetCode of result.items) {
                if (assetCode.id.toString() === assetRentingFile.assetCode) {
                    assetRentingFile.assetCode = { ...assetCode };
                }
            }
        });
    }

    setAssetRentingFilesToGetFormOfRenting(assetRentingFile: AssetRentingFileDto): void {
        this._apiService.get('api/FormOfRentingAsset/GetFormOfRentingAssetsByFilter'
        ).subscribe(result => {
            for (let formOfRenting of result.items) {
                if (formOfRenting.id.toString() === assetRentingFile.formOfRenting) {
                    assetRentingFile.formOfRenting = { ...formOfRenting };
                }
            }
        });
    }

    close(): void {
        this.modal.hide();
    }
}