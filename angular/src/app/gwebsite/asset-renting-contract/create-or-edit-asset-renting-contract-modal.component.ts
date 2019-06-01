import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetRentingContractServiceProxy, AssetRentingContractInput, AssetRentingContractDto, ComboboxItemDto, AssetRentingFileDto } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditAssetRentingContractModal',
    templateUrl: './create-or-edit-asset-renting-contract-modal.component.html',
})

export class CreateOrEditAssetRentingContractModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    //@ViewChild('assetRentingContractCombobox') assetRentingContractCombobox: ElementRef;
    @ViewChild('assetRentingFileCombobox') assetRentingFileCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('signDate') signDate: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    messageUpload: string;
    imageURL: any;
    saving = false;
    selected: string;
    assetRentingContract: AssetRentingContractInput = new AssetRentingContractInput();

    assetRentingFile: AssetRentingFileDto = new AssetRentingFileDto();
    assetRentingFiles: ComboboxItemDto[] = [];

    //typeAssets = ["fixed assets", "labor assets"];
    // dangHoatDong = ["Có", "Không"];

    constructor(
        injector: Injector,
        private _assetRentingContractService: AssetRentingContractServiceProxy
    ) {
        super(injector);
    }

    // ngOnInit(): void {
    //     this.selected = "fixed assets";
    // }

    show(assetRentingContractId?: number | null | undefined): void {
        this.saving = false;
        this._assetRentingContractService.getAssetRentingContractForEdit(assetRentingContractId).subscribe(result => {
            this.assetRentingContract = result;
            this.imageURL = this.assetRentingContract.linkofImage;
            this.modal.show();
        })
        // if (assetRentingContractId == null) {
            this._assetRentingContractService.getAssetRentingFileComboboxForEditAsync(assetRentingContractId).subscribe(result => {
                //this.hopdongthau = result;      
                this.assetRentingFile = result.assetRentingFile;
                this.assetRentingFiles = result.assetRentingFiles;
                this.modal.show();
                setTimeout(() => {
                    $(this.assetRentingFileCombobox.nativeElement).selectpicker('refresh');
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
        let input = this.assetRentingContract;
        // this.assetRentingContract.loaiTaiSan = this.selected;
        this.assetRentingContract.linkofImage = this.imageURL;
        this.saving = true;
        this._assetRentingContractService.createOrEditAssetRentingContract(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}