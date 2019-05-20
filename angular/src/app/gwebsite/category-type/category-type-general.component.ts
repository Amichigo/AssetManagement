import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateOrEditTypeModalComponent } from './create-or-edit-category-type-general-modal.component';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { CategoryTypeServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './category-type-general.component.html',
    animations: [appModuleAnimation()],
})
export class CategoryTypeComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('createOrEditTypeModal') createOrEditTypeModal: CreateOrEditTypeModalComponent;
    @ViewChild('typeTable') typeTable: Table;
    @ViewChild('paginatorType') paginatorType: Paginator;

    primengTableHelperTypes = new PrimengTableHelper();

    /**
     * tạo các biến dể filters
     */

    public filterTypes: {
        filterTypeName: string,
        filterTypePrefix: string,
        filterTypeStatus: string,
    } = <any>{};

    constructor(
        injector: Injector,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _categoryTypeService: CategoryTypeServiceProxy,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.filterTypes.filterTypeName = '',
        this.filterTypes.filterTypePrefix = '',
        this.filterTypes.filterTypeStatus = 'All status'
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
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
        this._categoryTypeService.getCategoryTypesByFilter(
            this.filterTypes.filterTypeName,
            this.filterTypes.filterTypePrefix,
            this.filterTypes.filterTypeStatus,
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
            this.filterTypes.filterTypeName = params['filterTypeName'] || '';
            this.filterTypes.filterTypePrefix = params['filterTypePrefix'] || '';
            this.filterTypes.filterTypeStatus = params['filterTypeStatus'] || 'All status';

            //reload lại gridview
            this.reloadPage();
        });
    }

    reloadPage(): void {
        this.paginatorType.changePage(this.paginatorType.getPage());
    }

    applyTypeFilters(event?: LazyLoadEvent): void {
        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category-type', {
            filterTypeName: this.filterTypes.filterTypeName,
            filterTypePrefix: this.filterTypes.filterTypePrefix,
            filterTypeStatus: this.filterTypes.filterTypeStatus
        }]);

        this.getTypes(event);
    }

    typeRefresh(event?: LazyLoadEvent): void {
        this.filterTypes.filterTypeName = '',
        this.filterTypes.filterTypePrefix = '',
        this.filterTypes.filterTypeStatus = 'All status',

        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category-type', {
            filterTypeName: this.filterTypes.filterTypeName,
            filterTypePrefix: this.filterTypes.filterTypePrefix,
            filterTypeStatus: this.filterTypes.filterTypeStatus
        }]);

        // if (this.paginatorType.getPage() !== 0) {
        //     this.paginatorType.changePage(0);
        //     return;
        // }
        this.getTypes(event);
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text: string): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    //Refresh grid khi thực hiện create or edit thành công
    refreshValueFromTypeModal(): void {
        if (this.createOrEditTypeModal.categoryType.id) {
            for (let i = 0; i < this.primengTableHelperTypes.records.length; i++) {
                if (this.primengTableHelperTypes.records[i].id === this.createOrEditTypeModal.categoryType.id) {
                    this.primengTableHelperTypes.records[i] = this.createOrEditTypeModal.categoryType;
                    return;
                }
            }
        } else {
            this.reloadPage();
        }
    }

    createType(): void {
        this.createOrEditTypeModal.show();
    }

    editType(id: number): void {
        this.createOrEditTypeModal.show(id);
    }

    deleteType(id: number) {
        this._categoryTypeService.deleteCategoryType(id).subscribe(() => {
            this.typeRefresh();
        });
    }

    // exportToExcelCategories(): void {
    //     const self = this;
    //     self._categoryService.getCategoriesToExcel(
    //         self.filters.filterType === 'All types' ? '' : self.filters.filterType,
    //         self.filters.filterId,
    //         self.filters.filterName,
    //         self.filters.filterSymbol,
    //         self.filters.filterStatus,
    //         undefined,
    //         1,
    //         0)
    //         .subscribe(result => {
    //             self._fileDownloadService.downloadTempFile(result);
    //         });
    // }
}
