import { SuaChuaBatDongSanForViewDto, TaiSanN13Input, BatDongSanInput, SuaChuaBatDongSanInput, TaiSanDto, BatDongSanDto, BatDongSanForViewDto, TaiSanN13ForViewDto } from './../../../shared/service-proxies/service-proxies';
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
    taisan: TaiSanN13ForViewDto = new TaiSanN13ForViewDto();
    batdongsan: BatDongSanForViewDto = new BatDongSanForViewDto();
    selectedTaiSan: number;

    selectedMaTS:number;
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
      
    }

    show(suachuabatdongsanId?: number | null | undefined): void {
        console.log("ID:"+suachuabatdongsanId);
        this._suachuabatdongsanService.getSuaChuaBatDongSanForEdit(suachuabatdongsanId).subscribe(result => {
            this.suachuabatdongsan = result;
            if (this.suachuabatdongsan.id) {
                this._apiService.getForEdit('api/TaiSanN13/GetTaiSanForView', this.suachuabatdongsan.idTaiSan).subscribe(rs => {
                    // this.suachuabatdongsan.maTaiSan = result.maTaiSan;
                    this.taisan=rs;
                    if(this.taisan.idBatDongSan!=null)
                    {
                        this._apiService.getForEdit('api/BatDongSan/GetBatDongSanForView', this.taisan.idBatDongSan).subscribe(rs => {
                            this.batdongsan = rs;
                        });
                    }
                });
            }
        })
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




    close(): void {
        this.modal.hide();
    }
}
