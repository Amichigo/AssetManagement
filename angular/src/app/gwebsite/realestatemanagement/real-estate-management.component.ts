import { ViewRealEstateManagementModalComponent } from './view-real-estate-management-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { WebApiServiceProxy, IFilter } from '@shared/service-proxies/webapi.service';
import { RealEstateServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditRealEstateManagementModalComponent } from './create-or-edit-real-estate-management-modal.component';

@Component({
    templateUrl: './real-estate-management.component.html',
    animations: [appModuleAnimation()]
})
export class RealEstateManagementComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditRealEstateManagementModalComponent;
    @ViewChild('viewRealEstateModal') viewRealEstateModal: ViewRealEstateManagementModalComponent;

    /**
     * tạo các biến dể filters
     */
    filters: {
        MaBatDongSan: string;
        LoaiBatDongSan: string;
        DiaChi: string;
        LoaiSoHuu: string;
    } = <any>{};
    

    constructor(
        injector: Injector,
        private _realEstateService: RealEstateServiceProxy,
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
        this.filters.LoaiSoHuu = '',
        this.filters.MaBatDongSan = '',
        this.filters.DiaChi = '',
        this.filters.LoaiBatDongSan = ''
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
     * Hàm get danh sách DemoModel
     * @param event
     */
    getRealEstates(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * Sử dụng _apiService để call các api của backend
         */
        //this._apiService.get('/api/RealEstate/GetRealEstatesByFilter',
        //    [{ fieldName: 'MaBatDongSan', value: this.filters.MaBatDongSan },
        //        { fieldName: 'LoaiBatDongSan', value: this.filters.LoaiBatDongSan },
        //        { fieldName: 'DiaChi', value: this.filters.DiaChi },
        //        { fieldName: 'LoaiSoHuu', value: this.filters.LoaiSoHuu }],
        //    this.primengTableHelper.getSorting(this.dataTable),
        //    this.primengTableHelper.getMaxResultCount(this.paginator, event),
        //    this.primengTableHelper.getSkipCount(this.paginator, event),
        //    ).subscribe(result => {
        //        this.primengTableHelper.totalRecordsCount = result.totalCount;
        //        this.primengTableHelper.records = result.items;
        //        this.primengTableHelper.hideLoadingIndicator();
        //    });
        //this._realEstateService.getRealEstatesByFilter(null,null,null, null, this.primengTableHelper.getSorting(this.dataTable),
        //    this.primengTableHelper.getMaxResultCount(this.paginator, event),
        //    this.primengTableHelper.getSkipCount(this.paginator, event),
        //).subscribe(result => {
        //    this.primengTableHelper.totalRecordsCount = result.totalCount;
        //    this.primengTableHelper.records = result.items;
        //    this.primengTableHelper.hideLoadingIndicator();
        //});
        this.reloadList(null,null,null,null, event);
    }

    reloadList(MaBatDongSan,LoaiBatDongSan,DiaChi,LoaiSoHuu, event?: LazyLoadEvent) {
        this._realEstateService.getRealEstatesByFilter(MaBatDongSan, LoaiBatDongSan, DiaChi, LoaiSoHuu, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteRealEstate(id): void {
        this._realEstateService.deleteRealEstate(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.filters.MaBatDongSan = params['MaBatDongSan'] || '';
            this.filters.LoaiBatDongSan = params['LoaiBatDongSan'] || '';
            this.filters.DiaChi = params['DiaChi'] || '';
            this.filters.LoaiSoHuu = params['LoaiSoHuu'] || '';
            //reload lại gridview
            this.reloadList(this.filters.MaBatDongSan, this.filters.LoaiBatDongSan, this.filters.DiaChi, this.filters.LoaiSoHuu, null);
            //this.reloadPage();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        //this._router.navigate(['app/gwebsite/realestatemanangement', {
        //    MaBatDongSan: this.filters.MaBatDongSan,
        //    LoaiBatDongSan: this.filters.LoaiBatDongSan,
        //    DiaChi: this.filters.DiaChi,
        //    LoaiSoHuu: this.filters.LoaiSoHuu,
        
       // }]);
    this.reloadList(this.filters.MaBatDongSan, this.filters.LoaiBatDongSan, this.filters.DiaChi, this.filters.LoaiSoHuu, null);
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createRealEstate() {
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
