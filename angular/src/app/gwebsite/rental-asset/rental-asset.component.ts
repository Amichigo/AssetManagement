import { ViewRentalAssetModalComponent } from './view-rental-asset-modal.component'
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { RentalAssetServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditRentalAssetModalComponent } from './create-or-edit-rental-asset-modal.component';
import { RentalAssetDto } from './dto/rental-asset-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
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
  @ViewChild('viewRentalAssetModal') viewRentalAssetModal: ViewRentalAssetModalComponent;

  /**
   * tạo các biến dể filters
   */
  rentalAssetName: string;
  filterText: string;
  defaultImage = "https://dummyimage.com/100";

  constructor(
    injector: Injector,
    private _rentalAssetService: RentalAssetServiceProxy,
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

  reloadList(rentalAssetName: any, event?: LazyLoadEvent) {
    this._apiService.get('api/RentalAsset/GetRentalAssetsByFilter',
        [{ fieldName: 'Name', value: this.filterText }],
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(async result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        await this.setRentalAssets(result.items);
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
  }

  getRentalAssets(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this.reloadList(null, event);
}

  setRentalAssets(rentalAssets: RentalAssetDto[]): void {
    this._apiService.get('api/TypeOfRentalAsset/GetTypeOfRentalAssetsByFilter'
    ).subscribe(result => {
      rentalAssets.map((rentalAsset, index) => {
        rentalAsset.index = index + 1;
            for (let typeOfAsset of result.items) {
                if (typeOfAsset.id.toString() === rentalAsset.typeOfAsset) {
                    return rentalAsset.typeOfAsset = { ...typeOfAsset };
                }
            }
        });
    });
}

  deleteAsset(id): void {
    this._rentalAssetService.deleteRentalAsset(id).subscribe(() => {
      this.reloadPage();
    })
  }

  init(): void {
    //get params từ url để thực hiện filter
    this._activatedRoute.params.subscribe((params: Params) => {
      this.rentalAssetName = params['name'] || '';
      this.reloadList(this.rentalAssetName, null);
    });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  applyFilters(): void {
    //truyền params lên url thông qua router
    this.reloadList(this.rentalAssetName, null);

    if (this.paginator.getPage() !== 0) {
      this.paginator.changePage(0);
      return;
    }
  }

  //hàm show view create MenuClient
  createRentalAsset() {
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

