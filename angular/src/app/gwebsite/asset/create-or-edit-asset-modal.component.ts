import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import {
    AssetController_05ServiceProxy, AssetTypeControler_05ServiceProxy,
    AssetGroupInput_05, AssetTypeDto_05, PagedResultDtoOfAssetTypeDto_05, AssetTypeViewDto_05,
    AssetDto_05, ComboboxItemDto
} from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditAssetModal',
    templateUrl: './create-or-edit-asset-modal.component.html',
})

export class CreateOrEditAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('assetTypeCombobox') assetTypeCombobox: ElementRef;


    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    messageUpload: string;
    imageURL: any;
    selected: string;
    asset: AssetDto_05 = new AssetDto_05();
    fatherAssetGroup: AssetGroupInput_05 = new AssetGroupInput_05();
    assetType: AssetTypeDto_05 = new AssetTypeDto_05();
    assetGroups: ComboboxItemDto[] = [];
    assetTypes: ComboboxItemDto[] = [];
    assetStatus = ["true", "false"];
    private _assetTypeService: AssetTypeControler_05ServiceProxy;

    constructor(
        injector: Injector,

        private _assetService: AssetController_05ServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {

    }

    show(assetId?: string | null | undefined): void {
        this.saving = false;
        this._assetService.getAsseEdit(assetId).subscribe(result => {
            this.asset = result.asset;
            this.assetGroups = result.assetGroups;
            this.assetTypes = result.assetTypes;
            this.imageURL = this.asset.linkofImage;
            this.modal.show();
            setTimeout(() => {
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
                $(this.assetTypeCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
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

    check(leveltemp?: number | null): number {
        if (leveltemp != null) {
            return (leveltemp + 1);
        }
        return 1;
    }

    save(): void {
        this.asset.linkofImage = this.imageURL;
        let input = this.asset;
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