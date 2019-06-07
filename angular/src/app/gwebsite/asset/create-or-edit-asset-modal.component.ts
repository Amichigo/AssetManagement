import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetServiceProxy, AssetInput, AssetDto, ComboboxItemDto, TypeOfAssetDto, AssetGroupDto, AssetGroupServiceProxy } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditAssetModal',
    templateUrl: './create-or-edit-asset-modal.component.html',
})

export class CreateOrEditAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    //@ViewChild('assetCombobox') assetCombobox: ElementRef;
    @ViewChild('typeOfAssetCombobox') typeOfAssetCombobox: ElementRef;
    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('addDate') addDate: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    messageUpload: string;
    imageURL: any;
    saving = false;
    selected: string;
    asset: AssetInput = new AssetInput();

    typeOfAsset: TypeOfAssetDto = new TypeOfAssetDto();
    typeOfAssets: ComboboxItemDto[] = [];
    assetGroup: AssetGroupDto = new AssetGroupDto();
    assetGroups: ComboboxItemDto[] = [];

    //typeAssets = ["fixed assets", "labor assets"];
    // dangHoatDong = ["Có", "Không"];

    constructor(
        injector: Injector,
        private _assetService: AssetServiceProxy,
        private _assetGroupService: AssetGroupServiceProxy
    ) {
        super(injector);
    }

    // ngOnInit(): void {
    //     this.selected = "fixed assets";
    // }

    show(assetId?: number | null | undefined): void {
        this.saving = false;
        this._assetService.getAssetForEdit(assetId).subscribe(result => {
            this.asset = result;
            this.imageURL = this.asset.linkofImage;
            this.modal.show();
        })
        // if (assetId == null) {
            this._assetService.getTypeOfAssetComboboxForEditAsync(assetId).subscribe(result => {
                //this.hopdongthau = result;      
                this.typeOfAsset = result.typeOfAsset;
                this.typeOfAssets = result.typeOfAssets;
                this.modal.show();
                setTimeout(() => {
                    $(this.typeOfAssetCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        // }

    }

    changeValueCbbAssetType(assetTypeID: string): void {
        this._assetGroupService.getAssetGroupsByFilterId(assetTypeID).subscribe(result => {
            //this.hopdongthau = result;      
            this.assetGroup = result.assetGroup;
            this.assetGroups = result.assetGroups;
            this.modal.show();
            setTimeout(() => {
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        })
    }

    chooseImage(files: any) {
        var fileType = files[0].type;
        var fileReader = new FileReader();

        if (files.length === 0)
            return;

        if (fileType.match(/image\/*/) == null) {
            this.messageUpload = "This images is not supported!";
            return;
        }
        fileReader.readAsDataURL(files[0]);
        fileReader.onload = (_event) => {
            this.imageURL = fileReader.result;
        }
    }

    save(): void {
        let input = this.asset;
        // this.asset.loaiTaiSan = this.selected;
        this.asset.linkofImage = this.imageURL;
        this.saving = true;
        this._assetService.createOrEditAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}