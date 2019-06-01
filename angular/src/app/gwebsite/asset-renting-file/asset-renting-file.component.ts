import { ViewAssetRentingFileModalComponent } from './view-asset-renting-file-modal.component'
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetRentingFileServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAssetRentingFileModalComponent } from './create-or-edit-asset-renting-file-modal.component';
import { AssetRentingFileDto } from './dto/asset-renting-file-dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
  templateUrl: './asset-renting-file.component.html',
  animations: [appModuleAnimation()]
})
export class AssetRentingFileComponent extends AppComponentBase implements AfterViewInit, OnInit {

  /**
   * @ViewChild là dùng get control và call thuộc tính, functions của control đó
   */
  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetRentingFileModalComponent;
  @ViewChild('viewAssetRentingFileModal') viewAssetRentingFileModal: ViewAssetRentingFileModalComponent;

  /**
   * tạo các biến dể filters
   */
  assetRentingFileName: string;
  filterText: string;
  defaultImage = "https://dummyimage.com/100";

  constructor(
    injector: Injector,
    private _assetRentingFileService: AssetRentingFileServiceProxy,
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

  reloadListToGetAssetCode(assetRentingFileName: any, event?: LazyLoadEvent) {
    this._apiService.get('api/AssetRentingFile/GetAssetRentingFilesByFilter',
        [{ fieldName: 'Name', value: this.filterText }],
        this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(async result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        await this.setAssetRentingFilesToGetAssetCode(result.items);
        await this.setAssetRentingFilesToGetFormOfRenting(result.items);
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
  }

  getAssetRentingFiles(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this.reloadListToGetAssetCode(null, event);
}

  setAssetRentingFilesToGetAssetCode(assetRentingFiles: AssetRentingFileDto[]): void {
    this._apiService.get('api/RentalAsset/GetRentalAssetsByFilter'
    ).subscribe(result => {
      assetRentingFiles.map((assetRentingFile, index) => {
        // assetRentingFile.index = index + 1;
            for (let assetCode of result.items) {
                if (assetCode.id.toString() === assetRentingFile.assetCode) {
                    return assetRentingFile.assetCode = { ...assetCode };
                }
            }
        });
    });
}

setAssetRentingFilesToGetFormOfRenting(assetRentingFiles: AssetRentingFileDto[]): void {
  this._apiService.get('api/FormOfRentingAsset/GetFormOfRentingAssetsByFilter'
    ).subscribe(result => {
      assetRentingFiles.map((assetRentingFile, index) => {
        // assetRentingFile.index = index + 1;
            for (let formOfRenting of result.items) {
                if (formOfRenting.id.toString() === assetRentingFile.formOfRenting) {
                    return assetRentingFile.formOfRenting = { ...formOfRenting };
                }
            }
        });
    });
}

  deleteFile(id): void {
    this._assetRentingFileService.deleteAssetRentingFile(id).subscribe(() => {
      this.reloadPage();
    })
  }

  init(): void {
    //get params từ url để thực hiện filter
    this._activatedRoute.params.subscribe((params: Params) => {
      this.assetRentingFileName = params['name'] || '';
      this.reloadListToGetAssetCode(this.assetRentingFileName, null);
    });
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  applyFilters(): void {
    //truyền params lên url thông qua router
    this.reloadListToGetAssetCode(this.assetRentingFileName, null);

    if (this.paginator.getPage() !== 0) {
      this.paginator.changePage(0);
      return;
    }
  }

  //hàm show view create MenuClient
  createAssetRentingFile() {
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

