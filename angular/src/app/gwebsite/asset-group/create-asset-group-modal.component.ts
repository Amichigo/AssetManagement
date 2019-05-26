import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ComboboxItemDto, AssetGroupInput_05 } from '@shared/service-proxies/service-proxies';
import { AssetGroupController_05ServiceProxy } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetGroupDto_05 } from '@shared/service-proxies/service-proxies'

@Component({
    selector: 'createAssetGroupModal',
    templateUrl: './create-asset-group-modal.component.html',
})

export class CreateAssetGroupModalComponent extends AppComponentBase {

    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    assetGroup: AssetGroupDto_05 = new AssetGroupDto_05();
    assetGroups: ComboboxItemDto[] = [];
    leveltemp: any;
    selected: string;
    typeAssets = ["fixed assets", "labor assets"];

    constructor(
        injector: Injector,
        private assetGroupService: AssetGroupController_05ServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.selected = "fixed assets";
        this.leveltemp = 1;
    }

    show(assetGroupId?: string | null | undefined): void {
        this.saving = false;
        this.assetGroupService.getAssetGroupForEdit(assetGroupId).subscribe(result => {
            this.assetGroup = result.assetGroup;
            this.assetGroups = result.assetGroups;
            this.modal.show();
            setTimeout(() => {
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    check(leveltemp?: number | null): number {
        if (leveltemp != null) {
            return (leveltemp + 1);
        }
        return 1;
    }

    save(): void {
        let input = this.assetGroup;
        this.assetGroup.assetTypeId = this.selected;
        this.assetGroup.level = this.check(this.leveltemp);
        this.saving = true;
        this.assetGroupService.createAssetGroup(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}