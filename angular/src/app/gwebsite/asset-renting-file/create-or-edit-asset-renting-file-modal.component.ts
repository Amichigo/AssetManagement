import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetRentingFileServiceProxy, AssetRentingFileInput, AssetRentingFileDto, ComboboxItemDto, RentalAssetDto, FormOfRentingAssetDto } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditAssetRentingFileModal',
    templateUrl: './create-or-edit-asset-renting-file-modal.component.html',
})

export class CreateOrEditAssetRentingFileModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    //@ViewChild('assetRentingFileCombobox') assetRentingFileCombobox: ElementRef;
    @ViewChild('rentalAssetCombobox') rentalAssetCombobox: ElementRef;
    @ViewChild('formOfRentingAssetCombobox') formOfRentingAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('fileCreatedDate') fileCreatedDate: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    messageUpload: string;
    imageURL: any;
    saving = false;
    selected: string;
    assetRentingFile: AssetRentingFileInput = new AssetRentingFileInput();

    rentalAsset: RentalAssetDto = new RentalAssetDto();
    rentalAssets: ComboboxItemDto[] = [];
    formOfRentingAsset: FormOfRentingAssetDto = new FormOfRentingAssetDto();
    formOfRentingAssets: ComboboxItemDto[] = [];

    //typeAssets = ["fixed assets", "labor assets"];
    // dangHoatDong = ["Có", "Không"];

    constructor(
        injector: Injector,
        private _assetRentingFileService: AssetRentingFileServiceProxy
    ) {
        super(injector);
    }

    // ngOnInit(): void {
    //     this.selected = "fixed assets";
    // }

    show(assetRentingFileId?: number | null | undefined): void {
        this.saving = false;
        this._assetRentingFileService.getAssetRentingFileForEdit(assetRentingFileId).subscribe(result => {
            this.assetRentingFile = result;
            this.imageURL = this.assetRentingFile.linkofImage;
            this.modal.show();
        })
        // if (assetRentingFileId == null) {
            this._assetRentingFileService.getRentalAssetComboboxForEditAsync(assetRentingFileId).subscribe(result => {
                //this.hopdongthau = result;      
                this.rentalAsset = result.rentalAsset;
                this.rentalAssets = result.rentalAssets;
                this.modal.show();
                setTimeout(() => {
                    $(this.rentalAssetCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })

            this._assetRentingFileService.getFormOfRentingAssetComboboxForEditAsync(assetRentingFileId).subscribe(result => {
                //this.hopdongthau = result;      
                this.formOfRentingAsset = result.formOfRentingAsset;
                this.formOfRentingAssets = result.formOfRentingAssets;
                this.modal.show();
                setTimeout(() => {
                    $(this.formOfRentingAssetCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        // }

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
        let input = this.assetRentingFile;
        // this.assetRentingFile.loaiTaiSan = this.selected;
        this.assetRentingFile.linkofImage = this.imageURL;
        this.saving = true;
        this._assetRentingFileService.createOrEditAssetRentingFile(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}