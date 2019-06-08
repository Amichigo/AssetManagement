import { ViewRentalAssetModalComponent } from './view-rental-asset-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { RentalAssetServiceProxy, AssetInput } from '@shared/service-proxies/service-proxies';
import { CreateOrEditRentalAssetModalComponent } from './create-or-edit-rental-asset-modal.component';
import { Asset7Component } from '../asset/asset7.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { AssetDto } from '../asset/dto/asset-dto';
import { SelectAssetModalComponent } from '../asset/select-asset-modal.component';
import { Constain } from '../constain/constain';

@Component({
    selector: 'rentalAssetComponent',
    templateUrl: './rental-asset.component.html',
    animations: [appModuleAnimation()]
})
export class RentalAssetComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditRentalAssetModalComponent;
    @ViewChild('selectAssetModel') selectAssetModel: SelectAssetModalComponent;
    @ViewChild('viewRentalAssetModal') viewRentalAssetModal: ViewRentalAssetModalComponent;
    @ViewChild('assetModel') assetModel: Asset7Component;

    /**
     * tạo các biến dể filters
     */
    rentalAssetCode: string;
    assetCode: string;
    // maloaibds: string;
    asset: AssetInput = new AssetInput();
    // listItems: Array<LoaiBatDongSanDto> = [];
    listAssets: Array<AssetDto> = [];
    // selectedLBDS: number;
    selectedAsset: number;
    // dùng để gọi từ conponent khác
    // @Input() selectedMaTaiSan:string;

    constructor(
        injector: Injector,
        private _rentalAssetService: RentalAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
        // this.getListTypes();
       // this.getListTaiSan();
    }


    // getListTypes(): void {
    //     // get loaibatdongsan type
    //     this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
    //         this.listItems = result.items;
    //     });
    // }


    getListAsset(): void {

        this._apiService.get('api/Asset/GetAssetsByFilter').subscribe(result => {
            this.listAssets = result.items;

        });
    }

    onChangeAsset(): void {
        this._apiService.getForEdit('api/Asset/GetAssetForView', this.selectedAsset).subscribe(result => {
            this.asset.assetName = result.assetName;
            this.asset.assetCode = result.assetCode;
            this.asset.assetType = result.assetType;
            this.asset.assetGroupName = result.assetGroupName;
            this.asset.assetStatus = result.assetStatus;
            this.asset.assetValue = result.assetValue;
            this.asset.note = result.note;
            this.asset.linkofImage = result.linkofImage;
        });
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
     * Hàm get danh sách BatDongSan
     * @param event
     */
    getRentalAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null,  event);

    }



    reloadList(rentalAssetCode, assetCode, event?: LazyLoadEvent) {
        this._rentalAssetService.getRentalAssetsByFilter(rentalAssetCode, assetCode, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteRentalAsset(id): void {
        this._rentalAssetService.deleteRentalAsset(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.rentalAssetCode = params['RentalAssetCode'] || '';
            // this.maloaibds = params['MaLoaiBDS'] || '';
            this.assetCode = params['AssetCode'] || '';
            this.reloadList(this.rentalAssetCode, this.assetCode, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.rentalAssetCode, this.assetCode, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    reset(): void {
        this.rentalAssetCode = "";
        this.assetCode = "";
        // this.maloaibds = "";
        this.asset.assetName = "";
        this.asset.assetType = "";
        this.asset.assetGroupName = "";
        this.asset.assetStatus = "";
        this.asset.assetValue = null;
        this.asset.note = "";
        this.asset.linkofImage = "";
        // this.selectedLBDS = 0;
        this.selectedAsset = 0;
        this.applyFilters();

    }
    //hàm show view create MenuClient
    createRentalAsset() {
        this.createOrEditModal.show();
    }

    selectAsset() {
        if (Constain.showConsoleLog)
        {
            console.log("mo modal");
        }
            
        this.selectAssetModel.show();

    }

    updateAsset() {
        if (Constain.showConsoleLog)
        {
            console.log("Update data");
        }
        if(this.selectAssetModel.selectedAssetCode!=-1){
            this.selectedAsset=this.selectAssetModel.selectedAssetCode;
            this._apiService.getForEdit('api/Asset/GetAssetForView', this.selectedAsset).subscribe(result => {
            this.asset.assetName = result.assetName;
            this.asset.assetCode = result.assetCode;
            this.asset.assetType = result.assetType;
            this.asset.assetGroupName = result.assetGroupName;
            this.asset.assetStatus = result.assetStatus;
            this.asset.assetValue = result.assetValue;
            this.asset.note = result.note;
            this.asset.linkofImage = result.linkofImage;
            });
        }

    }   




    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
