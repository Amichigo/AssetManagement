import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { CategoryTypeDto } from './dto/category-type.dto';
import { CategoryDto } from './dto/category.dto';

@Component({
    selector: 'createOrEditCategoryModal',
    templateUrl: './create-or-edit-category-general-modal.component.html'
})
export class CreateOrEditCategoryModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('categoryCombobox') categoryCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    savingType = false;

    category: CategoryDto = new CategoryDto();
    categoryType: CategoryTypeDto = new CategoryTypeDto();
    selectedType: number;
    categoryTypes: Array<CategoryTypeDto> = [];

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
        this.getTypes();
    }

    getTypes(): void {
        // get category type
        this._apiService.get('api/CategoryType/GetCategoryTypesByFilter').subscribe(result => {
            this.categoryTypes = result.items;
        });
    }

    show(categoryId?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/Category/GetCategoryForEdit', categoryId).subscribe(result => {
            this.category = result;
            this.modal.show();
            setTimeout(() => {
                $(this.categoryCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    onChangeType(): void {
        this._apiService.getForEdit('api/CategoryType/GetCategoryTypeForView', this.selectedType).subscribe(result => {
            this.category.categoryType = result.name;
            this.category.categoryId = result.prefixWord; // get prefix word to create id
        });
    }

    save(): void {
        let input = this.category;
        this.saving = true;
        if (input.id) {
            this.updateCategory();
        } else {
            this.insertCategory();
        }
    }

    insertCategory() {
        this._apiService.post('api/Category/CreateCategory', this.category)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateCategory() {
        this._apiService.put('api/Category/EditCategory', this.category)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    addType(): void {
        this.savingType = true;
        this._apiService.post('api/CategoryType/CreateCategoryType', this.categoryType)
            .pipe(finalize(() => this.savingType = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}