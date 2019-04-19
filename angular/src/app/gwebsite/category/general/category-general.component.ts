import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { WebApiServiceProxy, IFilter } from '@shared/service-proxies/webapi.service';
import { CreateOrEditCategoryModalComponent } from './create-or-edit-category-general-modal.component';
import { CreateOrEditTypeModalComponent } from './create-or-edit-category-type-general-modal.component';
import { CategoryTypeDto } from './dto/category-type.dto';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';

@Component({
    templateUrl: './category-general.component.html',
    animations: [appModuleAnimation()],
})
export class CategoryComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('createOrEditCategoryModal') createOrEditCategoryModal: CreateOrEditCategoryModalComponent;
    @ViewChild('createOrEditTypeModal') createOrEditTypeModal: CreateOrEditTypeModalComponent;
    @ViewChild('categoryTable') categoryTable: Table;
    @ViewChild('typeTable') typeTable: Table;
    @ViewChild('paginatorCategory') paginatorCategory: Paginator;
    @ViewChild('paginatorType') paginatorType: Paginator;
    @ViewChild('typeCombobox') typeCombobox: ElementRef;


    primengTableHelperCategories = new PrimengTableHelper();
    primengTableHelperTypes = new PrimengTableHelper();

    /**
     * tạo các biến dể filters
     */
    public filters: {
        filterType: string,
        filterId: string,
        filterName: string,
        filterSymbol: string
    } = <any>{};

    public filterTypes: {
        filterTypeName: string,
        filterTypePrefix: string
    } = <any>{};

    // Categorytype dropdown list
    public listItems: Array<CategoryTypeDto> = [];

    constructor(
        injector: Injector,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.filters.filterType = '',
        this.filters.filterId = '',
        this.filters.filterName = '',
        this.filters.filterSymbol = '',

        this.filterTypes.filterTypeName = '',
        this.filterTypes.filterTypePrefix = '',

        this.getListTypes();
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    getListTypes(): void {
        // get category type
        this._apiService.get('api/CategoryType/GetCategoryTypesByFilter').subscribe(result => {
            this.listItems = result.items;
        });
    }

    /**
     * Hàm get danh sách Category
     * @param event
     */
    getCategories(event?: LazyLoadEvent) {
        if (this.primengTableHelperCategories.shouldResetPaging(event)) {
            this.paginatorCategory.changePage(0);

            return;
        }

        //show loading trong gridview
        this.primengTableHelperCategories.showLoadingIndicator();

        /**
         * Sử dụng _apiService để call các api của backend
         */

        // filter
        this._apiService.get('api/Category/GetCategoriesByFilter',
            [{ fieldName: 'CategoryType', value: this.filters.filterType },
            { fieldName: 'CategoryId', value: this.filters.filterId},
            { fieldName: 'Name', value: this.filters.filterName},
            { fieldName: 'Symbol', value: this.filters.filterSymbol }],
            this.primengTableHelperCategories.getSorting(this.categoryTable),
            this.primengTableHelperCategories.getMaxResultCount(this.paginatorCategory, event),
            this.primengTableHelperCategories.getSkipCount(this.paginatorCategory, event),
        ).subscribe(result => {
            this.primengTableHelperCategories.totalRecordsCount = result.totalCount;
            this.primengTableHelperCategories.records = result.items;
            this.primengTableHelperCategories.hideLoadingIndicator();
        });
    }

    getTypes(event?: LazyLoadEvent) {
        if (this.primengTableHelperTypes.shouldResetPaging(event)) {
            this.paginatorType.changePage(0);

            return;
        }

        //show loading trong gridview
        this.primengTableHelperTypes.showLoadingIndicator();

        /**
         * Sử dụng _apiService để call các api của backend
         */

        // filter
        this._apiService.get('api/CategoryType/GetCategoryTypesByFilter',
            [{ fieldName: 'Name', value: this.filterTypes.filterTypeName },
            { fieldName: 'PrefixWord', value: this.filterTypes.filterTypePrefix }],
            this.primengTableHelperTypes.getSorting(this.typeTable),
            this.primengTableHelperTypes.getMaxResultCount(this.paginatorType, event),
            this.primengTableHelperTypes.getSkipCount(this.paginatorType, event),
        ).subscribe(result => {
            this.primengTableHelperTypes.totalRecordsCount = result.totalCount;
            this.primengTableHelperTypes.records = result.items;
            this.primengTableHelperTypes.hideLoadingIndicator();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.filters.filterType = params['filterType'] || '';
            this.filters.filterId = params['filterId'] || '';
            this.filters.filterName = params['filterName'] || '';
            this.filters.filterSymbol = params['filterSymbol'] || '';
            this.filterTypes.filterTypeName = params['filterTypeName'] || '';
            this.filterTypes.filterTypePrefix = params['filterTypePrefix'] || '';

            //reload lại gridview
            this.reloadPage();
        });
    }

    reloadPage(): void {
        this.paginatorCategory.changePage(this.paginatorCategory.getPage());
    }

    applyCategoryFilters(event?: LazyLoadEvent): void {
        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category', {
            filterType: this.filters.filterType,
            filterId: this.filters.filterId,
            filterName: this.filters.filterName,
            filterSymbol: this.filters.filterSymbol
        }]);

        // if (this.paginatorCategory.getPage() !== 0) {
        //     this.paginatorCategory.changePage(0);
        //     return;
        // }
        this.getCategories(event);
    }

    applyTypeFilters(event?: LazyLoadEvent): void {
        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category', {
            filterTypeName: this.filterTypes.filterTypeName,
            filterTypePrefix: this.filterTypes.filterTypePrefix,
        }]);

        this.getTypes(event);
    }

    categoryRefresh(event?: LazyLoadEvent): void {
        this.filters.filterType = '',
        this.filters.filterId = '',
        this.filters.filterName = '',
        this.filters.filterSymbol = '',
        $(this.typeCombobox.nativeElement).selectpicker('refresh');

        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category', {
            filterType: this.filters.filterType,
            filterId: this.filters.filterId,
            filterName: this.filters.filterName,
            filterSymbol: this.filters.filterSymbol
        }]);

        // if (this.paginatorCategory.getPage() !== 0) {
        //     this.paginatorCategory.changePage(0);
        //     return;
        // }
        this.getCategories(event);
        this.getListTypes();
    }

    typeRefresh(event?: LazyLoadEvent): void {
        this.filterTypes.filterTypeName = '',
        this.filterTypes.filterTypePrefix = '',

        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category', {
            filterTypeName: this.filterTypes.filterTypeName,
            filterTypePrefix: this.filterTypes.filterTypePrefix,
        }]);

        // if (this.paginatorType.getPage() !== 0) {
        //     this.paginatorType.changePage(0);
        //     return;
        // }
        this.getTypes(event);
        this.getListTypes();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text: string): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    //Refresh grid khi thực hiện create or edit thành công
    refreshValueFromCategoryModal(): void {
        if (this.createOrEditCategoryModal.category.id) {
            for (let i = 0; i < this.primengTableHelperCategories.records.length; i++) {
                if (this.primengTableHelperCategories.records[i].id === this.createOrEditCategoryModal.category.id) {
                    this.primengTableHelperCategories.records[i] = this.createOrEditCategoryModal.category;
                    return;
                }
            }
        } else { this.reloadPage(); }
    }

    refreshValueFromTypeModal(): void {
        if (this.createOrEditTypeModal.categoryType.id) {
            for (let i = 0; i < this.primengTableHelperTypes.records.length; i++) {
                if (this.primengTableHelperTypes.records[i].id === this.createOrEditTypeModal.categoryType.id) {
                    this.primengTableHelperTypes.records[i] = this.createOrEditTypeModal.categoryType;
                    return;
                }
            }
        } else { this.reloadPage(); }
    }

    createCategory(): void {
        this.createOrEditCategoryModal.show();
    }

    createType(): void {
        this.createOrEditTypeModal.show();
    }

    editCategory(id: number): void {
        this.createOrEditCategoryModal.show(id);
    }

    editType(id: number): void {
        this.createOrEditTypeModal.show(id);
    }

    deleteCategory(id: number): void {
        this._apiService.delete('api/Category/DeleteCategory/', id).subscribe(() => {
            this.categoryRefresh();
        });
    }

    deleteType(id: number) {
        this._apiService.delete('api/CategoryType/DeleteCategoryType/', id).subscribe(() => {
            this.typeRefresh();
        });
    }
}
