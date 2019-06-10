import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BatDongSanServiceProxy, BatDongSanInput, LoaiBatDongSanDto, LoaiSoHuuDto, TaiSanDto, TaiSanN13Input, TaiSanN13ForViewDto } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import * as moment from 'moment';
import { ViewBatDongSanModalComponent } from './view-batdongsan-modal.component';
import { SelectTaiSanModalComponent } from '../taisan/select-taisan-modal.component';
import { Constain } from '../constain/constain';
@Component({
    selector: 'createOrEditBatDongSanModal',
    templateUrl: './create-or-edit-batdongsan-modal.component.html'
})
export class CreateOrEditBatDongSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('batdongsanCombobox') batdongsanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('SampleDateTimePicker') sampleDateTimePicker: ElementRef;
    @ViewChild('viewBatDongSanModal') viewBatDongSanModal: ViewBatDongSanModalComponent;
    @ViewChild('selectTaiSanModel') selectTaiSanModel: SelectTaiSanModalComponent;
    selectedLBDS: number; //get selectedLBDS id for edit
    selectedLSH: number;

    selectedTaiSan: number;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    batdongsan: BatDongSanInput = new BatDongSanInput();
    taisan: TaiSanN13ForViewDto = new TaiSanN13ForViewDto();


    constructor(
        injector: Injector,
        private _batdongsanService: BatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,

    ) {
        super(injector);
        this.getListTypes();// fill data to list loaibatdongsan when component created
        this.getListLoaiSoHuu();// binding data to list loaisohuu when component created

    }

    listItems: Array<LoaiBatDongSanDto> = [];

    listLSH: Array<LoaiSoHuuDto> = [];
    loaisohuu: LoaiSoHuuDto = new LoaiSoHuuDto();


    getListTypes(): void {

        // get loaibatdongsan type
        this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
            this.listItems = result.items;
        });
    }

    getListLoaiSoHuu(): void {
        this._apiService.get('api/LoaiSoHuu/GetLoaiSoHuusByFilter').subscribe(result => {
            this.listLSH = result.items;
        });
    }






    updateTaiSan(): void {
        console.log("update data");
        if (this.selectTaiSanModel.selectedMaTS != -1) {
            this.selectedTaiSan = this.selectTaiSanModel.selectedMaTS;
            this._apiService.getForEdit('api/TaiSanN13/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
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






    show(batdongsanId?: number | null | undefined): void {
        this.saving = false;
        this._batdongsanService.getBatDongSanForEdit(batdongsanId).subscribe(result => {
            this.batdongsan = result;
            this._apiService.getForEdit('api/TaiSanN13/GetTaiSanForViewByIdBDS', batdongsanId).subscribe(rs => {
                this.taisan = rs;
            })
            if (!batdongsanId) {
                this.batdongsan.idLoaiBDS = null;
                this.batdongsan.idLoaiSoHuu = null;
            }
            this.modal.show();

        })
    }

    selectTaiSan() {
        console.log("mo modal");
        this.selectTaiSanModel.intType = 0;
        this.selectTaiSanModel.show();

    }


    save(): void {

        let input = this.batdongsan;
        this.saving = true;
        this._batdongsanService.createOrEditBatDongSan(input, this.selectedTaiSan).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })


    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
