import { SuaChuaBatDongSanForViewDto, TaiSanN13Input, BatDongSanInput, SuaChuaBatDongSanInput, TaiSanDto, BatDongSanDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { SuaChuaBatDongSanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewSuaChuaBatDongSanModal',
    templateUrl: './view-suachuabatdongsan-modal.component.html'
})



export class ViewSuaChuaBatDongSanModalComponent extends AppComponentBase {

    suachuabatdongsan: SuaChuaBatDongSanInput = new SuaChuaBatDongSanInput();
    taisan: TaiSanN13Input = new TaiSanN13Input();
    batdongsan: BatDongSanInput = new BatDongSanInput();
    selectedTaiSan: number;
    listTaiSans: Array<TaiSanDto> = [];
    listBatDongSan: Array<BatDongSanDto> = [];
    selectedMaTS:number;
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
        this.getListTaiSan();
        this.getListBDS();
    }

    show(suachuabatdongsanId?: number | null | undefined): void {
        console.log("ID:"+suachuabatdongsanId);
        this._suachuabatdongsanService.getSuaChuaBatDongSanForEdit(suachuabatdongsanId).subscribe(result => {
            this.suachuabatdongsan = result;
            if (this.suachuabatdongsan.id) {
                for (let item of this.listTaiSans) {
                    if (item.maTaiSan == this.suachuabatdongsan.maTaiSan) {
                        this.selectedMaTS = item.id;
                        console.log("ID:MTS"+ this.selectedMaTS);
                        this.updateTaiSan();
                        break;
                    }
                }
            }
        })
    }

    resetBDS(): void {
        this.batdongsan.maTaiSan = "";
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
        this.batdongsan.maLoaiBDS = "";
      

    }
    getListTaiSan(): void {

        this._apiService.get('api/TaiSanN13/GetTaiSansByFilter').subscribe(result => {
            this.listTaiSans = result.items;

        });
    }

    getListBDS(): void {
        this._apiService.get('api/BatDongSan/GetBatDongSansByFilter').subscribe(result => {
            this.listBatDongSan = result.items;
        });
    }
    updateTaiSan(): void {
        if (this.selectedMaTS != -1) {
            this.selectedTaiSan = this.selectedMaTS;
        
            this._apiService.getForEdit('api/TaiSanN13/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
                // this.suachuabatdongsan.maTaiSan = result.maTaiSan;
                this.taisan.maTaiSan = result.maTaiSan;
                this.taisan.diaChi = result.diaChi;
                this.taisan.tenTaiSan = result.tenTaiSan;
                this.taisan.maNhomTaiSan = result.maNhomTaiSan;
                this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
                this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
                this.taisan.ghiChu = result.ghiChu;
                this.getListBDS();
                for (let item of this.listBatDongSan) {
                    if (item.maTaiSan == this.taisan.maTaiSan) {
                        this.batdongsan = item;
                      
                        break;
                    }
                    else {
                        this.resetBDS();
                    }
                }
            });


        }


    }
   



    close(): void {
        this.modal.hide();
    }
}
