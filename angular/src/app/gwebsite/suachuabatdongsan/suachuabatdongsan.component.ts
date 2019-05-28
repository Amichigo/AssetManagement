import { ViewSuaChuaBatDongSanModalComponent } from './view-suachuabatdongsan-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { SuaChuaBatDongSanServiceProxy, TaiSanInput } from '@shared/service-proxies/service-proxies';
import { CreateOrEditSuaChuaBatDongSanModalComponent } from './create-or-edit-suachuabatdongsan-modal.component';
import { TaiSanComponent } from '../taisan/taisan.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { TaiSanDto } from '../taisan/Dto/taisandto';
import { SelectTaiSanModalComponent } from '../taisan/select-taisan-modal.component';

@Component({
    selector: 'suachuabatdongsanComponent',
    templateUrl: './suachuabatdongsan.component.html',
    animations: [appModuleAnimation()]
})
export class SuaChuaBatDongSanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditSuaChuaBatDongSanModalComponent;
    @ViewChild('selectTaiSanModel') selectTaiSanModel: SelectTaiSanModalComponent;
    @ViewChild('viewSuaChuaBatDongSanModal') viewSuaChuaBatDongSanModal: ViewSuaChuaBatDongSanModalComponent;
    @ViewChild('taiSanModel') taiSanModel: TaiSanComponent;

    /**
     * tạo các biến dể filters
     */
    suachuabatdongsanName: string;
    mataisanName: string;
    tenTaiSan:string;
    ngayDeXuat:string;
    ngaySuaXong:string;
    maloaibds: string;
    taisan: TaiSanInput = new TaiSanInput();
 //   listItems: Array<LoaiSuaChuaBatDongSanDto> = [];
    listTaiSans: Array<TaiSanDto> = [];
    selectedLBDS: number;
    selectedTaiSan: number;
    @Input() test: number = 0;
    // dùng để gọi từ conponent khác
    // @Input() selectedMaTaiSan:string;

    constructor(
        injector: Injector,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
        //this.getListTypes();
       // this.getListTaiSan();
    }


    //getListTypes(): void {
    //    // get loaisuachuabatdongsan type
    //    this._apiService.get('api/LoaiSuaChuaBatDongSan/GetLoaiSuaChuaBatDongSansByFilter').subscribe(result => {
    //        this.listItems = result.items;
    //    });
    //}
    // onChangeType(): void {
    //     this._apiService.getForEdit('api/LoaiSuaChuaBatDongSan/GetLoaiSuaChuaBatDongSanForView', this.selectedLBDS).subscribe(result => {
    //         this.maloaibds = result.id;
    //     });
    // }

    getListTaiSan(): void {

        this._apiService.get('api/TaiSan/GetTaiSansByFilter').subscribe(result => {
            this.listTaiSans = result.items;
        });
    }
    onChangeTaiSan(): void {

        this._apiService.getForEdit('api/TaiSan/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
            this.mataisanName = result.maTaiSan;
            this.taisan.maTaiSan = result.maTaiSan;
            this.taisan.diaChi = result.diaChi;
            this.taisan.tenTaiSan = result.tenTaiSan;
            this.taisan.maNhomTaiSan = result.maNhomTaiSan;
            this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
            this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
            this.taisan.ghiChu = result.ghiChu;
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
     * Hàm get danh sách SuaChuaBatDongSan
     * @param event
     */
    getSuaChuaBatDongSans(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, event);

    }



    reloadList(mataisanName,ngayDeXuat, ngaySuaXong, event?: LazyLoadEvent) {
        this._suachuabatdongsanService.getSuaChuaBatDongSansByFilter(mataisanName,ngayDeXuat,ngaySuaXong, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteSuaChuaBatDongSan(id): void {
        this._suachuabatdongsanService.deleteSuaChuaBatDongSan(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.mataisanName = params['MaTaiSan'] || '';
            this.tenTaiSan ='';
            this.ngayDeXuat = params['NgayDeXuat'] || '';
            this.ngaySuaXong=params['NgaySuaXong'] || '';
            this.reloadList(this.mataisanName, this.ngayDeXuat,this.ngaySuaXong, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.mataisanName, this.ngayDeXuat, this.ngaySuaXong, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    reset(): void {
        this.suachuabatdongsanName = "";
        this.mataisanName = "";
        this.maloaibds = "";
        this.taisan.maTaiSan = "";
        this.taisan.diaChi = "";
        this.taisan.tenTaiSan = "";
        this.taisan.maNhomTaiSan = "";
        this.taisan.maLoaiTaiSan = "";
        this.taisan.nguyenGiaTaiSan = null;
        this.taisan.ghiChu = "";
        this.selectedLBDS = 0;
        this.selectedTaiSan = 0;
        this.ngayDeXuat=null;
        this.ngaySuaXong=null;
        this.tenTaiSan="";
        this.applyFilters();

      
    }
    //hàm show view create MenuClient
    createSuaChuaBatDongSan() {
        this.createOrEditModal.show();
    }

    selectTaiSan() {
        console.log("mo modal");
        this.selectTaiSanModel.show();

    }

    updateTaiSan() {
        console.log("update data");
        if(this.selectTaiSanModel.selectedMaTS!=-1){
            this.selectedTaiSan=this.selectTaiSanModel.selectedMaTS;
            this._apiService.getForEdit('api/TaiSan/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
                this.mataisanName = result.maTaiSan;
                this.tenTaiSan=result.tenTaiSan;
                this.taisan.maTaiSan = result.maTaiSan;
                this.taisan.diaChi = result.diaChi;
                this.taisan.tenTaiSan = result.tenTaiSan;
                this.taisan.maNhomTaiSan = result.maNhomTaiSan;
                this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
                this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
                this.taisan.ghiChu = result.ghiChu;
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
