import { ViewAssetGroupModalComponent } from './view-asset-group-modal.component'
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetGroupServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAssetGroupModalComponent } from './create-or-edit-asset-group-modal.component';
import { AssetGroupDto } from './dto/asset-group-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
  templateUrl: './asset-group.component.html',
  animations: [appModuleAnimation()]
})
export class AssetGroupComponent extends AppComponentBase implements AfterViewInit, OnInit {

  /**
   * @ViewChild là dùng get control và call thuộc tính, functions của control đó
   */
  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetGroupModalComponent;
  @ViewChild('viewAssetGroupModal') viewAssetGroupModal: ViewAssetGroupModalComponent;

  /**
   * tạo các biến dể filters
   */
  assetGroupName: string;
  filterText: string;
  defaultImage = "https://dummyimage.com/100";

  constructor(
    injector: Injector,
    private _assetGroupService: AssetGroupServiceProxy,
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

  reloadList(assetGroupName: any, event?: LazyLoadEvent) {
    this._apiService.get('api/AssetGroup/GetAssetGroupsByFilter',
        [{ fieldName: 'Name', value: this.filterText }],
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(async result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        await this.setAssetGroups(result.items);
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
  }

  getAssetGroups(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this.reloadList(null, event);
}

  setAssetGroups(assetGroups: AssetGroupDto[]): void {
    this._apiService.get('api/TypeOfAsset/GetTypeOfAssetsByFilter'
    ).subscribe(result => {
      assetGroups.map((assetGroup, index) => {
        assetGroup.index = index + 1;
            for (let assetType of result.items) {
                if (assetType.id.toString() === assetGroup.assetType) {
                    return assetGroup.assetType = { ...assetType };
                }
            }
        });
    });
}

  deleteAssetGroup(id): void {
    this._assetGroupService.deleteAssetGroup(id).subscribe(() => {
      this.reloadPage();
    })
  }

  init(): void {
    //get params từ url để thực hiện filter
    this._activatedRoute.params.subscribe((params: Params) => {
      this.assetGroupName = params['name'] || '';
      this.reloadList(this.assetGroupName, null);
    });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  applyFilters(): void {
    //truyền params lên url thông qua router
    this.reloadList(this.assetGroupName, null);

    if (this.paginator.getPage() !== 0) {
      this.paginator.changePage(0);
      return;
    }
  }

  //hàm show view create MenuClient
  createAssetGroup() {
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

