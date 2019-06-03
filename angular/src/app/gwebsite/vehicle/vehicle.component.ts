import { ViewVehicleModalComponent } from "./view-vehicle-modal.componenent";
import {
    AfterViewInit,
    Component,
    ElementRef,
    Injector,
    OnInit,
    ViewChild
} from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import * as _ from "lodash";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import {
    CustomerServiceProxy,
    AssetInput,
    AssetForViewDto
} from "@shared/service-proxies/service-proxies";
import { VehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { CreateOrEditVehicleModalComponent } from "./create-or-edit-vehicle-modal.components";
import { SelectAssetModalComponent } from "../asset/select-asset-modal.component";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
import { AssetServiceProxy } from "@shared/service-proxies/service-proxies";
@Component({
    templateUrl: "./vehicle.component.html",
    animations: [appModuleAnimation()]
})
export class VehicleComponent extends AppComponentBase
    implements AfterViewInit, OnInit {
    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;
    @ViewChild("createOrEditModal")
    createOrEditModal: CreateOrEditVehicleModalComponent;
    @ViewChild("viewVehicleModal") viewVehicleModal: ViewVehicleModalComponent;
    // gọi modal select ra để hiển thị trong component vehicle;
    @ViewChild("selectAssetModal") selectAssetModal: SelectAssetModalComponent;
    /**
     * tạo các biến dể filters
     */
    vehicleName: string;
    selectedAsset: number;
    mataisanName: string;
    taisan: AssetInput = new AssetInput();
    constructor(
        injector: Injector,
        private _vehicleService: VehicleServiceProxy,
        private _apiService: WebApiServiceProxy,
        private _assetService: AssetServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {}

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách Vehicle
     * @param event
     */
    getVehicles(event?: LazyLoadEvent) {
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

    reloadList(vehicleName, event?: LazyLoadEvent) {
        this._vehicleService
            .getVehiclesByFilter(
                vehicleName,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(
                    this.paginator,
                    event
                ),
                this.primengTableHelper.getSkipCount(this.paginator, event)
            )
            .subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    deleteVehicle(id): void {
        this._vehicleService.deleteVehicle(id).subscribe(() => {
            this.reloadPage();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.vehicleName = params["name"] || "";
            this.reloadList(this.vehicleName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.vehicleName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createVehicle() {
        this.createOrEditModal.show();
    }

    //Lấy ra thông tin tài sản ứng với id tài sản vừa chọn
    updateAsset(): void {
        if (this.selectAssetModal.selectedMaTS != -1) {
            this.selectedAsset = this.selectAssetModal.selectedMaTS;
            this._apiService
                .getForEdit("api/Asset/GetAssetForView", this.selectedAsset)
                .subscribe(result => {
                    // this.mataisanName = result.maTaiSan;
                    this.taisan = result; //ghi vậy ngắn hơn
                });
        }
    }

    // hiển thị  modal select lên cái màn hình vehicle
    // gọi nó trong button, khi button click gọi vào hàm này,
    showTaiSan(): void {
        this.selectAssetModal.show();
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, "...");
    }
}
