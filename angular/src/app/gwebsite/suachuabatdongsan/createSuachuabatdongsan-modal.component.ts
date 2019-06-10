import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SuaChuaBatDongSanServiceProxy, SuaChuaBatDongSanInput, LoaiSoHuuDto, TaiSanN13Input, TaiSanDto, BatDongSanInput, BatDongSanDto, ResetPasswordInput, TaiSanN13ForViewDto, BatDongSanForViewDto } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import * as moment from 'moment';
import { ViewSuaChuaBatDongSanModalComponent } from './view-suachuabatdongsan-modal.component';
import { SelectTaiSanModalComponent } from '../taisan/select-taisan-modal.component';
import { BreadcrumbModule } from 'primeng/primeng';
import { Constain, TrangThai } from '../constain/constain';
@Component({
    selector: 'createOrEditSuaChuaBatDongSanModal',
    templateUrl: './createSuachuabatdongsan-modal.component.html'
})
export class CreateOrEditSuaChuaBatDongSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('suachuabatdongsanCombobox') suachuabatdongsanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('SampleDateTimePicker') sampleDateTimePicker: ElementRef;
    @ViewChild('viewSuaChuaBatDongSanModal') viewSuaChuaBatDongSanModal: ViewSuaChuaBatDongSanModalComponent;
    @ViewChild('selectTaiSanModel') selectTaiSanModel: SelectTaiSanModalComponent;
    selectedLBDS: number; //get selectedLBDS id for edit
    selectedLSH: number;

    selectedTaiSan: number;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    suachuabatdongsan: SuaChuaBatDongSanInput = new SuaChuaBatDongSanInput();
    taisan: TaiSanN13ForViewDto = new TaiSanN13ForViewDto();
    batdongsan: BatDongSanForViewDto = new BatDongSanForViewDto();
    trangThai: TrangThai;
    constructor(
        injector: Injector,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,

    ) {
        super(injector);


    }





    updateTaiSan(): void {
        if (this.selectTaiSanModel.selectedMaTS != -1) {
            this.selectedTaiSan = this.selectTaiSanModel.selectedMaTS;
            if (Constain.showConsoleLog) {
                console.log("Selected IDtaisan=" + this.selectedTaiSan);
            }
            this._apiService.getForEdit('api/TaiSanN13/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
                this.taisan = result;
                if (this.taisan.idBatDongSan != null) {
                    this._apiService.getForEdit('api/BatDongSan/GetBatDongSanForView', this.taisan.idBatDongSan).subscribe(rs => {
                        this.batdongsan = rs;
                    });
                }
                else{
                    this.resetBDS();
                }


            });


        }


    }

    resetBDS(): void {
        this.batdongsan.hienTrangBDS = "";
        this.batdongsan.chieuDai = null;
        this.batdongsan.chieuRong = null;
        this.batdongsan.dienTichDatNen = null;
        this.batdongsan.dienTichXayDung = null;
        this.batdongsan.ranhGioi = null;
        this.batdongsan.maHienTrangPhapLy = null;
        this.batdongsan.ketCauNha = "";
        this.batdongsan.ghiChu = "";
        this.batdongsan.chuSoHuu = "";
        this.batdongsan.maTinhTrangSuDungDat = "";
        this.batdongsan.maLoaiBDS="";
        this.batdongsan.maLoaiSoHuu="";


    }

    ResetInput(): void {
        this.resetBDS();
        this.taisan.maTaiSan = null;
        this.taisan.tenTaiSan = null;
        this.taisan.maNhomTaiSan = null;
        this.taisan.maLoaiTaiSan = null;
        this.taisan.diaChi = null;
        this.taisan.ghiChu = null;
        this.suachuabatdongsan.ngayDeXuat = null;
        this.suachuabatdongsan.ngayDuKienSuaXong = null;
        this.suachuabatdongsan.donViDeXuat = null;
        this.suachuabatdongsan.donViSuaChua = null;
        this.suachuabatdongsan.ghiChu = null;
        this.suachuabatdongsan.nguoiDeXuat = null;
        this.suachuabatdongsan.nhanVienPhuTrach = null;
        this.suachuabatdongsan.noiDungSuaChua = null;
        this.suachuabatdongsan.chiPhiDuKien = null;

    }






    show(suachuabatdongsanId?: number | null | undefined): void {
        this.saving = false;
        this._suachuabatdongsanService.getSuaChuaBatDongSanForEdit(suachuabatdongsanId).subscribe(result => {
            this.suachuabatdongsan = result;
            if (this.suachuabatdongsan.id) {

            }
        })
    }

    selectTaiSan() {
        console.log("mo modal");
        this.selectTaiSanModel.show();

    }


    save(): void {

        console.log("tu dong luu");

        if (!this.suachuabatdongsan.maSuaChuaBatDongSan) {
            // tao moi
            this.suachuabatdongsan.idTaiSan = this.taisan.id;
            for (let item of Constain.trangthai) {
                if (item.id == 1) {
                    this.suachuabatdongsan.trangThaiSuaChua = item.Name;
                    break;
                }
            }
        }
        else {

        }

        let input = this.suachuabatdongsan;



        // input.ngayMuaSuaChuaBatDongSan.format('yyyy-MM-dd HH:mm:ss Z');
        this.saving = true;
        this._suachuabatdongsanService.createOrEditSuaChuaBatDongSan(input).subscribe(result => {
            this.close();
            this.notify.info(this.l('SavedSuccessfully'));
        })

    }

    close(): void {

        this.modalSave.emit(null);
        this.saving = false;
    }
}
