import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';
import { AssetDto } from './dto/asset-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewAssetModal',
    templateUrl: './view-asset-modal.component.html'
})

export class ViewAssetModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;

    asset: AssetDto = new AssetDto();
    defaultImage = "https://dummyimage.com/100";

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(assetId?: number | null | undefined): void {
        this._apiService.getForEdit('api/Asset/GetAssetForEdit', assetId
        ).subscribe(async result => {
            await this.setAssetsToGetAssetType(result);
            await this.setAssetsToGetAssetGroupName(result);
            this.asset = result;
            this.modal.show();
        })
    }

    setAssetsToGetAssetType(asset: AssetDto): void {
        this._apiService.get('api/TypeOfAsset/GetTypeOfAssetsByFilter'
        ).subscribe(result => {
            for (let assetType of result.items) {
                if (assetType.id.toString() === asset.assetType) {
                    asset.assetType = { ...assetType };
                }
            }
        });
    }

    setAssetsToGetAssetGroupName(asset: AssetDto): void {
        this._apiService.get('api/AssetGroup/GetAssetGroupsByFilter'
        ).subscribe(result => {
            for (let assetGroupName of result.items) {
                if (assetGroupName.id.toString() === asset.assetGroupName) {
                    asset.assetGroupName = { ...assetGroupName };
                }
            }
        });
    }

    close(): void {
        this.modal.hide();
    }
}