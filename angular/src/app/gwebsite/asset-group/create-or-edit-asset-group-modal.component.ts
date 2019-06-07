import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetGroupServiceProxy, AssetGroupInput, AssetGroupDto, ComboboxItemDto, TypeOfAssetDto } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditAssetGroupModal',
    templateUrl: './create-or-edit-asset-group-modal.component.html',
})

export class CreateOrEditAssetGroupModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    //@ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('typeOfAssetCombobox') typeOfAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('rentalDate') rentalDate: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    messageUpload: string;
    imageURL: any;
    saving = false;
    selected: string;
    assetGroup: AssetGroupInput = new AssetGroupInput();

    typeOfAsset: TypeOfAssetDto = new TypeOfAssetDto();
    typeOfAssets: ComboboxItemDto[] = [];

    //typeAssets = ["fixed assets", "labor assets"];
    // dangHoatDong = ["Có", "Không"];

    constructor(
        injector: Injector,
        private _assetGroupService: AssetGroupServiceProxy
    ) {
        super(injector);
    }

    // ngOnInit(): void {
    //     this.selected = "fixed assets";
    // }

    show(assetGroupId?: number | null | undefined): void {
        this.saving = false;
        this._assetGroupService.getAssetGroupForEdit(assetGroupId).subscribe(result => {
            this.assetGroup = result;
            // this.imageURL = this.assetGroup.linkofImage;
            this.modal.show();
        })
        // if (assetGroupId == null) {
            this._assetGroupService.getTypeOfAssetComboboxForEditAsync(assetGroupId).subscribe(result => {
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

    // chooseImage(files: any) {
    //     var fileType = files[0].type;
    //     var fileReader = new FileReader();

    //     if (files.length === 0)
    //         return;

    //     if (fileType.match(/image\/*/) == null) {
    //         this.messageUpload = "This images is not supported!";
    //         return;
    //     }
    //     fileReader.readAsDataURL(files[0]);
    //     fileReader.onload = (_event) => {
    //         this.imageURL = fileReader.result;
    //     }
    // }

    save(): void {
        let input = this.assetGroup;
        // this.assetGroup.loaiTaiSan = this.selected;
        // this.assetGroup.linkofImage = this.imageURL;
        this.saving = true;
        this._assetGroupService.createOrEditAssetGroup(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}