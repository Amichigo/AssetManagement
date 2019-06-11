import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { HoSoThauN13Input, HoSoThauN13ServiceProxy, CongTrinhInput, CongTrinhForViewDto, HopDongN13ServiceProxy, HoSoThauN13ForViewDto, HopDongN13Input, ThanhToanN13Input, ThanhToanN13ServiceProxy, KeHoachXayDungForViewDto, DonViThauN13ForViewDto } from '@shared/service-proxies/service-proxies';
import { SelectHoSoThauN13ModalComponent } from './select-hosothaun13-modal.component';
import { CreateThanhToanN13Component } from './create-thanhtoann13-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
    
@Component({
    selector: 'createHopDongN13Modal',
    templateUrl: './create-hopdong13-modal.component.html'
})
export class CreateHopDongN13ModalComponent extends AppComponentBase {
    

    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;    
    @ViewChild('selectHoSoThauN13Modal') selectHoSoThauN13Modal: SelectHoSoThauN13ModalComponent;    
    @ViewChild('createThanhToan13Modal') createThanhToan13Modal: CreateThanhToanN13Component;    
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    inputvalue:string;
    dsThanhToan:Array<ThanhToanN13Input>=[];
    congtrinhForView:CongTrinhForViewDto=new CongTrinhForViewDto();
    goiThauForView:HoSoThauN13ForViewDto=new HoSoThauN13ForViewDto();
    keHoachForView:KeHoachXayDungForViewDto=new KeHoachXayDungForViewDto();
    donViThauForView:DonViThauN13ForViewDto=new DonViThauN13ForViewDto();
    madvtt:string;
    tendvtt:string;
    hopDongInput:HopDongN13Input=new HopDongN13Input();
    constructor(
        injector: Injector,
        private _hopDong: HopDongN13ServiceProxy,
        private _thanhtoanService:ThanhToanN13ServiceProxy,
        private _apiService: WebApiServiceProxy,
        
    ) {
        super(injector);
    }

    show(idHopDong?: number | null | undefined): void {
     this.dsThanhToan=[];
        this.saving = false;
        this._hopDong.getHopDongForEdit(idHopDong).subscribe(result => {
            this.hopDongInput=result;
            this.modal.show();
        })
    }

    showThanhToan(){
        this.createThanhToan13Modal.isSaveToDatabase=false;
        this.createThanhToan13Modal.show(null);
    }

    showHoSoThau(){
        this.selectHoSoThauN13Modal.show();
    }

    ThemThanhToan(){
        this.dsThanhToan.push(this.createThanhToan13Modal.ThanhToanIp);
    }

    reset():void{
    }
 
  
    save(): void {
      
        this.saving = true;
        this.hopDongInput.maHopDong=this.hopDongInput.soHopDong;
        this.hopDongInput.tongTienThanhToan=0;
        for(let item of this.dsThanhToan){
            if(item.daThanhToan==null) break;
            this.hopDongInput.tongTienThanhToan= this.hopDongInput.tongTienThanhToan+item.daThanhToan;
        }
         let input=this.hopDongInput;
         if(this.goiThauForView.id==null) {
            this.notify.info(this.l('Lưu không thành công'));
            return
         }
         
        this._hopDong.createOrEditHopDong(input,this.goiThauForView.id).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            let id=result;
            if(id==null) return;
            for(let item of this.dsThanhToan){
                item.idHopDong=id;
               this._thanhtoanService.createOrEditThanhToanN13(item).subscribe(rs=>
                {
                    this.notify.info(this.l('Lưu thanh toán'));
                })
            }
            this.close();
        })
        this.close();
    }
    SetThongTinCongTrinh():void{
        this.congtrinhForView=this.selectHoSoThauN13Modal.selectedCongTrinh;
        this.goiThauForView=this.selectHoSoThauN13Modal.selecTedGoiThau;
        this.madvtt=this.selectHoSoThauN13Modal.maDVTrungThau;
        this.tendvtt=this.selectHoSoThauN13Modal.tenDVTrungThau;
        if(this.congtrinhForView.idKeHoach==null) return;
        this._apiService.getForEdit('api/KeHoachXayDung/GetKeHoachXayDungForView',this.congtrinhForView.idKeHoach).subscribe(result => {
            this.keHoachForView = result;
         
        });
        if(this.goiThauForView.id==null) return;
        this._apiService.getForEdit('api/DonViThauN13/GetDonViThauByIdGoiThauForView',this.goiThauForView.id).subscribe(result => {
            this.donViThauForView = result;
        });

    }
    close(): void {
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
