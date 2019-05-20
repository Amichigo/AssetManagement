import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateOrEditCategoryModalComponent } from './create-or-edit-category-general-modal.component';
import { ViewCategoryModalComponent } from './view-category-modal.component';
import { CategoryTypeDto } from '../category-type/dto/category-type.dto';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { CategoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

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
    @ViewChild('viewCategoryModal') viewCategoryModal: ViewCategoryModalComponent;
    @ViewChild('categoryTable') categoryTable: Table;
    @ViewChild('paginatorCategory') paginatorCategory: Paginator;
    @ViewChild('typeCombobox') typeCombobox: ElementRef;


    primengTableHelperCategories = new PrimengTableHelper();

    /**
     * tạo các biến dể filters
     */
    public filters: {
        filterType: string,
        filterId: string,
        filterName: string,
        filterSymbol: string,
        filterStatus: string
    } = <any>{};

    // Categorytype dropdown list
    public listItems: Array<CategoryTypeDto> = [];

    constructor(
        injector: Injector,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _apiService: WebApiServiceProxy,
        private _categoryService: CategoryServiceProxy
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.filters.filterType = 'All types',
        this.filters.filterId = '',
        this.filters.filterName = '',
        this.filters.filterSymbol = '',
        this.filters.filterStatus = 'All status',

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

    getListTypes(event?: LazyLoadEvent): void {
        // get category type
        this._apiService.get('api/CategoryType/GetCategoryTypesByFilter')
        .subscribe(result => {
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
        this._categoryService.getCategoriesByFilter(
            this.filters.filterType === 'All types' ? '' : this.filters.filterType,
            this.filters.filterId,
            this.filters.filterName,
            this.filters.filterSymbol,
            this.filters.filterStatus,
            this.primengTableHelperCategories.getSorting(this.categoryTable),
            this.primengTableHelperCategories.getMaxResultCount(this.paginatorCategory, event),
            this.primengTableHelperCategories.getSkipCount(this.paginatorCategory, event),
        ).subscribe(result => {
            this.primengTableHelperCategories.totalRecordsCount = result.totalCount;
            this.primengTableHelperCategories.records = result.items;
            this.primengTableHelperCategories.hideLoadingIndicator();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.filters.filterType = params['filterType'] || '';
            this.filters.filterId = params['filterId'] || '';
            this.filters.filterName = params['filterName'] || '';
            this.filters.filterSymbol = params['filterSymbol'] || '';
            this.filters.filterStatus = params['filterStatus'] || 'All status';

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
            filterSymbol: this.filters.filterSymbol,
            filterStatus: this.filters.filterStatus
        }]);

        // if (this.paginatorCategory.getPage() !== 0) {
        //     this.paginatorCategory.changePage(0);
        //     return;
        // }
        this.getCategories(event);
    }

    categoryRefresh(event?: LazyLoadEvent): void {
        this.filters.filterType = 'All types',
        this.filters.filterId = '',
        this.filters.filterName = '',
        this.filters.filterSymbol = '',
        this.filters.filterStatus = 'All status',
        $(this.typeCombobox.nativeElement).selectpicker('refresh');

        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category', {
            filterType: this.filters.filterType,
            filterId: this.filters.filterId,
            filterName: this.filters.filterName,
            filterSymbol: this.filters.filterSymbol,
            filterStatus: this.filters.filterStatus
        }]);

        // if (this.paginatorCategory.getPage() !== 0) {
        //     this.paginatorCategory.changePage(0);
        //     return;
        // }
        this.getCategories(event);
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
        } else {
            this.reloadPage();
        }
    }

    createCategory(): void {
        this.createOrEditCategoryModal.show();
    }

    editCategory(id: number): void {
        this.createOrEditCategoryModal.show(id);
    }

    viewCategory(id: number): void {
        this.viewCategoryModal.show(id);
    }

    deleteCategory(id: number): void {
        this._categoryService.deleteCategory(id).subscribe(() => {
            this.categoryRefresh();
        });
    }

    exportToExcelCategories(): void {
        const self = this;
        self._categoryService.getCategoriesToExcel(
            self.filters.filterType === 'All types' ? '' : self.filters.filterType,
            self.filters.filterId,
            self.filters.filterName,
            self.filters.filterSymbol,
            self.filters.filterStatus,
            undefined,
            1,
            0)
            .subscribe(result => {
                self._fileDownloadService.downloadTempFile(result);
            });
    }
}