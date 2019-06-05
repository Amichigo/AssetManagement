import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { HoSoThauN13Input, HoSoThauN13ServiceProxy, CongTrinhInput, CongTrinhForViewDto, DonViThauServiceProxy, DonViThauInput } from '@shared/service-proxies/service-proxies';
import { SelectCongTrinhN13ModalComponent } from './select-congtrinhn13-modal.component';
import { CreateDonViThauN13Component } from './create-donvithaun13-modal.component';
    
@Component({
    selector: 'createHoSoThauN13Modal',
    templateUrl: './create-hosothau13-modal.component.html'
})
export class CreateHoSoThauN13ModalComponent extends AppComponentBase {


    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;    
    @ViewChild('selectCongTrinhN13Modal') selectCongTrinhN13Modal: SelectCongTrinhN13ModalComponent;
    @ViewChild('createDonViThauN13Modal') createDonViThauN13Modal:CreateDonViThauN13Component;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    
    hosothau: HoSoThauN13Input = new HoSoThauN13Input();
    congTrinhForView:CongTrinhForViewDto=new CongTrinhForViewDto();
    dsDonViThau: Array<DonViThauInput>=[];
    donVitest:DonViThauInput=new DonViThauInput()
    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauN13ServiceProxy,
        private _donvithauService: DonViThauServiceProxy,
    ) {
        super(injector);
    }

    show(): void {
        this.dsDonViThau=[];
        this.saving = false;
        
    }

    showSelectCongTrinh(){
        this.selectCongTrinhN13Modal.show();
    }

    reset():void{
        this.dsDonViThau=[];
    }
    ThemDonViThau():void{
        console.log("Them don vi");
        this.dsDonViThau.push(this.createDonViThauN13Modal.donViThauIp);
    }
    ShowDonViThau():void{
        this.createDonViThauN13Modal.show();
    }
    save(): void {
        this.hosothau.maCongTrinh= this.congTrinhForView.maCongTrinh;
        let input = this.hosothau;
        this.saving = true;

        this._hosothauService.createOrEditHoSoThau(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            for(let item of this.dsDonViThau){
                item.maGoiThau=this.hosothau.maHoSoThau;
                let dv=item;
                this._donvithauService.createOrEditDonViThau(dv).subscribe(rs=>{
                    this.notify.info(this.l('SavedSuccessfully'));
                })
            }
            this.close();
        })
        this.close();
    }
    SetThongTinCongTrinh():void{
        this.congTrinhForView=this.selectCongTrinhN13Modal.congtrinhForView;
    }
    close(): void {
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
