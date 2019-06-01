import { ViewFormOfRentingAssetModalComponent } from './view-form-of-renting-asset-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { FormOfRentingAssetServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditFormOfRentingAssetModalComponent } from './create-or-edit-form-of-renting-asset-modal.component';

@Component({
    templateUrl: './form-of-renting-asset.component.html',
    animations: [appModuleAnimation()]
})
export class FormOfRentingAssetComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditFormOfRentingAssetModalComponent;
    @ViewChild('viewFormOfRentingAssetModal') viewFormOfRentingAssetModal: ViewFormOfRentingAssetModalComponent;

    /**
     * tạo các biến dể filters
     */
    formOfRentingAssetName: string;
    Id: string;
    constructor(
        injector: Injector,
        private _formOfRentingAssetService: FormOfRentingAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách FormOfRentingAsset
     * @param event
     */
    getFormOfRentingAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);

    }

    reloadList(formOfRentingAssetName, event?: LazyLoadEvent) {
        this._formOfRentingAssetService.getFormOfRentingAssetsByFilter(formOfRentingAssetName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteFormOfRentingAsset(id): void {
        this._formOfRentingAssetService.deleteFormOfRentingAsset(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.formOfRentingAssetName = params['name'] || '';
           
            this.reloadList(this.formOfRentingAssetName, null);
        });
    }

    getId(): string {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.Id = params['Id'] || '';
        })
     return this.Id;
    };
    


    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.formOfRentingAssetName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createFormOfRentingAsset() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
