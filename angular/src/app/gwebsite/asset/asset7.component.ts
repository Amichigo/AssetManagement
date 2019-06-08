import { ViewAssetModalComponent } from './view-asset-modal.component'
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAssetModalComponent } from './create-or-edit-asset-modal.component';
import { AssetDto } from './dto/asset-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
  templateUrl: './asset7.component.html',
  animations: [appModuleAnimation()]
})
export class Asset7Component extends AppComponentBase implements AfterViewInit, OnInit {

  /**
   * @ViewChild là dùng get control và call thuộc tính, functions của control đó
   */
  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetModalComponent;
  @ViewChild('viewAssetModal') viewAssetModal: ViewAssetModalComponent;

  /**
   * tạo các biến dể filters
   */
  assetName: string;
  assetCode: string;
  assetType: string;
  assetGroupName: string;
  filterText: string;
  defaultImage = "https://dummyimage.com/100";

  constructor(
    injector: Injector,
    private _assetService: AssetServiceProxy,
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

  reloadList(assetName: any, event?: LazyLoadEvent) {
    this._apiService.get('api/Asset/GetAssetsByFilter',
        [{ fieldName: 'Name', value: this.filterText }],
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(async result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        await this.setAssetsToGetAssetType(result.items);
        await this.setAssetsToGetAssetGroupName(result.items);
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
  }

//   reloadList(assetName,assetCode,assetType,assetGroupName, event?: LazyLoadEvent) {
//     this._assetService.getAssetsByFilter(assetName,assetCode,assetType,assetGroupName, this.primengTableHelper.getSorting(this.dataTable),
//         this.primengTableHelper.getMaxResultCount(this.paginator, event),
//         this.primengTableHelper.getSkipCount(this.paginator, event),
//     ).subscribe(result => {
//         this.primengTableHelper.totalRecordsCount = result.totalCount;
//         this.primengTableHelper.records = result.items;
//         this.primengTableHelper.hideLoadingIndicator();
//     });
// }

  getAssets(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this.reloadList(null, event);
}

  setAssetsToGetAssetType(assets: AssetDto[]): void {
    this._apiService.get('api/TypeOfAsset/GetTypeOfAssetsByFilter'
    ).subscribe(result => {
      assets.map((asset, index) => {
        // asset.index = index + 1;
            for (let assetType of result.items) {
                if (assetType.id.toString() === asset.assetType) {
                    return asset.assetType = { ...assetType };
                }
            }
        });
    });
}

setAssetsToGetAssetGroupName(assets: AssetDto[]): void {
  this._apiService.get('api/AssetGroup/GetAssetGroupsByFilter'
    ).subscribe(result => {
      assets.map((asset, index) => {
        // asset.index = index + 1;
            for (let assetGroupName of result.items) {
                if (assetGroupName.id.toString() === asset.assetGroupName) {
                    return asset.assetGroupName = { ...assetGroupName };
                }
            }
        });
    });
}

  deleteAsset(id): void {
    this._assetService.deleteAsset(id).subscribe(() => {
      this.reloadPage();
    })
  }

  init(): void {
    //get params từ url để thực hiện filter
    this._activatedRoute.params.subscribe((params: Params) => {
      this.assetName = params['name'] || '';
      this.reloadList(this.assetName, null);
    });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  applyFilters(): void {
    //truyền params lên url thông qua router
    this.reloadList(this.assetName, null);

    if (this.paginator.getPage() !== 0) {
      this.paginator.changePage(0);
      return;
    }
  }

  //hàm show view create MenuClient
  createAsset() {
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

