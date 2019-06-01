import { ViewAssetRentingContractModalComponent } from './view-asset-renting-contract-modal.component'
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetRentingContractServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAssetRentingContractModalComponent } from './create-or-edit-asset-renting-contract-modal.component';
import { AssetRentingContractDto } from './dto/asset-renting-contract-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ViewAssetRentingFileModalComponent } from '../asset-renting-file/view-asset-renting-file-modal.component';

@Component({
  templateUrl: './asset-renting-contract.component.html',
  animations: [appModuleAnimation()]
})
export class AssetRentingContractComponent extends AppComponentBase implements AfterViewInit, OnInit {

  /**
   * @ViewChild là dùng get control và call thuộc tính, functions của control đó
   */
  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetRentingContractModalComponent;
  @ViewChild('viewAssetRentingContractModal') viewAssetRentingContractModal: ViewAssetRentingContractModalComponent;
  @ViewChild('viewAssetRentingFileModal') viewAssetRentingFileModal: ViewAssetRentingFileModalComponent;


  /**
   * tạo các biến dể filters
   */
  assetRentingContractName: string;
  filterText: string;
  defaultImage = "https://dummyimage.com/100";

  constructor(
    injector: Injector,
    private _assetRentingContractService: AssetRentingContractServiceProxy,
    private _activatedRoute: ActivatedRoute,
    private _apiService: WebApiServiceProxy
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

  reloadList(assetRentingContractName: any, event?: LazyLoadEvent) {
    this._apiService.get('api/AssetRentingContract/GetAssetRentingContractsByFilter',
        [{ fieldName: 'Name', value: this.filterText }],
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(async result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        await this.setAssetRentingContracts(result.items);
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
  }

  getAssetRentingContracts(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this.reloadList(null, event);
}

  setAssetRentingContracts(assetRentingContracts: AssetRentingContractDto[]): void {
    this._apiService.get('api/AssetRentingFile/GetAssetRentingFilesByFilter'
    ).subscribe(result => {
      assetRentingContracts.map((assetRentingContract, index) => {
        assetRentingContract.index = index + 1;
            for (let fileCode of result.items) {
                if (fileCode.id.toString() === assetRentingContract.fileCode) {
                    return assetRentingContract.fileCode = { ...fileCode };
                }
            }
        });
    });
}

  deleteContract(id): void {
    this._assetRentingContractService.deleteAssetRentingContract(id).subscribe(() => {
      this.reloadPage();
    })
  }

  init(): void {
    //get params từ url để thực hiện filter
    this._activatedRoute.params.subscribe((params: Params) => {
      this.assetRentingContractName = params['name'] || '';
      this.reloadList(this.assetRentingContractName, null);
    });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  applyFilters(): void {
    //truyền params lên url thông qua router
    this.reloadList(this.assetRentingContractName, null);

    if (this.paginator.getPage() !== 0) {
      this.paginator.changePage(0);
      return;
    }
  }

  //hàm show view create MenuClient
  createAssetRentingContract() {
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

