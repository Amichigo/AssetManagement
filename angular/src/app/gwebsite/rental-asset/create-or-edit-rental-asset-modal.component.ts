import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RentalAssetServiceProxy, RentalAssetInput, AssetInput, AssetDto } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import * as moment from 'moment';
import { ViewRentalAssetModalComponent } from './view-rental-asset-modal.component';
import { SelectAssetModalComponent } from '../asset/select-asset-modal.component';
import { Constain } from '../constain/constain';
@Component({
    selector: 'createOrEditRentalAssetModal',
    templateUrl: './create-or-edit-rental-asset-modal.component.html'
})
export class CreateOrEditRentalAssetModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('rentalAssetCombobox') rentalAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('SampleDateTimePicker') sampleDateTimePicker: ElementRef;
    @ViewChild('viewRentalAssetModal') viewRentalAssetModal: ViewRentalAssetModalComponent;
    @ViewChild('selectAssetModel') selectAssetModel: SelectAssetModalComponent;

    selectedAsset: number;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    rentalAsset: RentalAssetInput = new RentalAssetInput();
    asset: AssetInput = new AssetInput();


    constructor(
        injector: Injector,
        private _rentalAssetService: RentalAssetServiceProxy,
        private _apiService: WebApiServiceProxy,

    ) {
        super(injector);
        this.getListAsset();

    }


    listAssets: Array<AssetDto> = [];
    static test: number;
    


    getListAsset(): void {

        this._apiService.get('api/Asset/GetAssetsByFilter').subscribe(result => {
            this.listAssets = result.items;

        });
    }

    onChangeAsset(): void {

        this._apiService.getForEdit('api/Asset/GetAssetForView', this.selectedAsset).subscribe(result => {
            // this.batdongsan.maTaiSan = result.maTaiSan;
            this.asset.assetName = result.assetName;
            this.asset.assetCode = result.assetCode;
            this.asset.assetType = result.assetType;
            this.asset.assetGroupName = result.assetGroupName;
            this.asset.assetStatus = result.assetStatus;
            this.asset.assetValue = result.assetValue;
            this.asset.note = result.note;
            this.asset.linkofImage = result.linkofImage;
        });
    }

    updateAsset(): void {
        console.log("update data");
        if (this.selectAssetModel.selectedAssetCode != -1) {
            this.selectedAsset = this.selectAssetModel.selectedAssetCode;
            this._apiService.getForEdit('api/Asset/GetAssetForView', this.selectedAsset).subscribe(result => {
                // this.batdongsan.maTaiSan = result.maTaiSan;
            this.asset.assetName = result.assetName;
            this.asset.assetCode = result.assetCode;
            this.asset.assetType = result.assetType;
            this.asset.assetGroupName = result.assetGroupName;
            this.asset.assetStatus = result.assetStatus;
            this.asset.assetValue = result.assetValue;
            this.asset.note = result.note;
            this.asset.linkofImage = result.linkofImage;
            });
        }

    }



    // onChangeLSH(): void {
    //     this._apiService.getForEdit('api/LoaiSoHuu/GetLoaiSoHuuForView', this.selectedLSH).subscribe(result => {
    //         this.batdongsan.maLoaiSoHuu = result.name;

    //     });
    // }



    show(rentalAssetId?: number | null | undefined): void {
        this.saving = false;


        this._rentalAssetService.getRentalAssetForEdit(rentalAssetId).subscribe(result => {
            this.rentalAsset = result;
            if (this.rentalAsset.rentalAssetCode != "") {

                // this.selectedLBDS= Number(this.batdongsan.maLoaiBDS);
                for (let item of this.listAssets) {
                    if (item.assetCode == this.rentalAsset.assetCode) {
                        this.selectedAsset = item.id;
                        this.onChangeAsset();
                        break;
                    }

                }





            }
            this.modal.show();

        })
    }

    selectAsset() {
        console.log("mo modal");
        this.selectAssetModel.show();

    }


    save(): void {
        if (Constain.showConsoleLog)
            console.log("tu dong luu");
        this.rentalAsset.assetCode = this.asset.assetCode;
        let input = this.rentalAsset;
        this.saving = true;
        this._rentalAssetService.createOrEditRentalAsset(input, this.selectedAsset).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })


    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
