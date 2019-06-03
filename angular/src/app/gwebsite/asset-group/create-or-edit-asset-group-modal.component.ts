import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import {
    AssetGroupController_05ServiceProxy, AssetTypeControler_05ServiceProxy,
    AssetGroupInput_05, AssetTypeDto_05, PagedResultDtoOfAssetTypeDto_05, AssetTypeViewDto_05,
    AssetGroupDto_05, ComboboxItemDto
} from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditAssetGroupModal',
    templateUrl: './create-or-edit-asset-group-modal.component.html',
})

export class CreateOrEditAssetGroupModalComponent extends AppComponentBase {

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
    assetGroup: AssetGroupDto_05 = new AssetGroupDto_05();
    fatherAssetGroup: AssetGroupInput_05 = new AssetGroupInput_05();
    assetType: AssetTypeDto_05 = new AssetTypeDto_05();
    assetGroups: ComboboxItemDto[] = [];
    assetTypes: ComboboxItemDto[] = [];
    private _assetTypeService: AssetTypeControler_05ServiceProxy;

    constructor(
        injector: Injector,

        private _assetGroupService: AssetGroupController_05ServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {

    }

    show(assetGroupId?: string | null | undefined): void {
        this.saving = false;
        this._assetGroupService.getAsseGroupEdit(assetGroupId).subscribe(result => {
            this.assetGroup = result.assetGroup;
            this.assetGroups = result.assetGroups;
            this.assetType = result.assetType;
            this.assetTypes = result.assetTypes;
            this.modal.show();
            setTimeout(() => {
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
                $(this.assetTypeCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    check(leveltemp?: number | null): number {
        if (leveltemp != null) {
            return (leveltemp + 1);
        }
        return 1;
    }
    //  show(assetGroupId?: string | null | undefined): void {
    //     this.saving = false;
    //     this._assetGroupService.getAssetGroupForEdit(assetGroupId).subscribe(result => {
    //         this.assetGroup = result;
    //         this.modal.show();
    //     });
    //}
    save(): void {
        if (this.assetGroup.selectedId = "") {
            this.assetGroup.level = 1;
        }
        else {
            this._assetGroupService.getAssetGroupForEdit(this.assetGroup.selectedId).subscribe(result => {
                this.fatherAssetGroup = result;
            });
            this.assetGroup.level = this.fatherAssetGroup.level + 1;
        }
        let input = this.assetGroup;
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