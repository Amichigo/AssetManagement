import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild } from "@angular/core";
import { AssetGroupServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { AssetGroupDto } from './dto/asset-group-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'viewAssetGroupModal',
    templateUrl: './view-asset-group-modal.component.html'
})

export class ViewAssetGroupModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;

    assetGroup: AssetGroupDto = new AssetGroupDto();

    constructor(
        injector: Injector,
        private assetGroupId: AssetGroupServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(assetGroupId?: number | null | undefined): void {
        this._apiService.getForEdit('api/AssetGroup/GetAssetGroupForEdit', assetGroupId
        ).subscribe(async result => {
            await this.setAssetGroups(result);
            this.assetGroup = result;
            this.modal.show();
        });
    }

    setAssetGroups(assetGroup: AssetGroupDto): void {
        this._apiService.get('api/TypeOfAsset/GetTypeOfAssetsByFilter'
        ).subscribe(result => {
            for (let assetType of result.items) {
                if (assetType.id.toString() === assetGroup.assetType) {
                    assetGroup.assetType = { ...assetType };
                }
            }
        });
    }

    close(): void {
        this.modal.hide();
    }
}