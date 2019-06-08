import { CustomerForViewDto, AssetServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
import { RentalAssetComponent } from '../rental-asset/rental-asset.component';

@Component({
    selector: 'selectAssetModal',
    templateUrl: './select-asset-modal.component.html'
})

export class SelectAssetModalComponent extends AppComponentBase {

    customer : CustomerForViewDto = new CustomerForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    constructor(
        injector: Injector,
        private _assetService: AssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }


    assetName: string;
    assetCode:string;
    assetType:string;
    assetGroupName:string;
    public selectedAssetCode:number;
   
    //@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
     @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(customerId?: number | null | undefined): void {
        // this._taisanService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.assetName = params['AssetName'] || '';
            this.assetCode = params['AssetCode'] || '';
            this.assetType= params['AssetType'] || '';
            this.assetGroupName= params['AssetGroupName'] || '';
            this.reloadList(this.assetName,this.assetCode,this.assetType,this.assetGroupName, null);
        });
            this.selectedAssetCode=-1;
            this.modal.show();

    }


    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    selectedAsset(acode):void{
        this.selectedAssetCode=acode;
        this.close();
    }

    /**
     * Hàm get danh sách TaiSan
     * @param event
     */
    getAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

         this.reloadList(null,null,null,null, event);

    }


    reloadList(assetName,assetCode,assetType,assetGroupName, event?: LazyLoadEvent) {
        this._assetService.getAssetsByFilter(assetName,assetCode,assetType,assetGroupName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }
    
    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.assetName,this.assetCode,this.assetType,this.assetGroupName, null);
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }


  
    close() : void{
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
