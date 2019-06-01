import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RentalAssetServiceProxy, RentalAssetInput, RentalAssetDto, ComboboxItemDto, TypeOfRentalAssetDto } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditRentalAssetModal',
    templateUrl: './create-or-edit-rental-asset-modal.component.html',
})

export class CreateOrEditRentalAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    //@ViewChild('rentalAssetCombobox') rentalAssetCombobox: ElementRef;
    @ViewChild('typeOfRentalAssetCombobox') typeOfRentalAssetCombobox: ElementRef;
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
    rentalAsset: RentalAssetInput = new RentalAssetInput();

    typeOfRentalAsset: TypeOfRentalAssetDto = new TypeOfRentalAssetDto();
    typeOfRentalAssets: ComboboxItemDto[] = [];

    //typeAssets = ["fixed assets", "labor assets"];
    // dangHoatDong = ["Có", "Không"];

    constructor(
        injector: Injector,
        private _rentalAssetService: RentalAssetServiceProxy
    ) {
        super(injector);
    }

    // ngOnInit(): void {
    //     this.selected = "fixed assets";
    // }

    show(rentalAssetId?: number | null | undefined): void {
        this.saving = false;
        this._rentalAssetService.getRentalAssetForEdit(rentalAssetId).subscribe(result => {
            this.rentalAsset = result;
            this.imageURL = this.rentalAsset.linkofImage;
            this.modal.show();
        })
        // if (rentalAssetId == null) {
            this._rentalAssetService.getTypeOfRentalAssetComboboxForEditAsync(rentalAssetId).subscribe(result => {
                //this.hopdongthau = result;      
                this.typeOfRentalAsset = result.typeOfRentalAsset;
                this.typeOfRentalAssets = result.typeOfRentalAssets;
                this.modal.show();
                setTimeout(() => {
                    $(this.typeOfRentalAssetCombobox.nativeElement).selectpicker('refresh');
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
        let input = this.rentalAsset;
        // this.rentalAsset.loaiTaiSan = this.selected;
        this.rentalAsset.linkofImage = this.imageURL;
        this.saving = true;
        this._rentalAssetService.createOrEditRentalAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}