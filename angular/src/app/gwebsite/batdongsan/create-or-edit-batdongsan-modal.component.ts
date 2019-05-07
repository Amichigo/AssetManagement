import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BatDongSanServiceProxy, BatDongSanInput, LoaiBatDongSanDto, LoaiSoHuuDto } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import * as moment from 'moment';
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
    selectedLBDS: number; //get selectedLBDS id for edit
    selectedLSH: number;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    batdongsan: BatDongSanInput = new BatDongSanInput();

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
    loaibatdongsan: LoaiBatDongSanDto =new LoaiBatDongSanDto();
    listLSH: Array<LoaiSoHuuDto> =[];
    loaisohuu: LoaiSoHuuDto=new LoaiSoHuuDto();

    static test: number;
    getListTypes(): void {

        this.selectedLBDS=0;
        
        // get loaibatdongsan type
        this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
            this.listItems = result.items;
        });
    }

    getListLoaiSoHuu():void {
        this.selectedLSH=0;
        // get loaibatdongsan type
        this._apiService.get('api/LoaiSoHuu/GetLoaiSoHuusByFilter').subscribe(result => {
            this.listLSH = result.items;
        });

    }




    onChangeType(): void {
        this._apiService.getForEdit('api/LoaiBatDongSan/GetLoaiBatDongSanForView', this.selectedLBDS).subscribe(result => {
            this.batdongsan.maLoaiBDS = result.name;
        });
    }

    onChangeLSH(): void {
        this._apiService.getForEdit('api/LoaiSoHuu/GetLoaiSoHuuForView', this.selectedLSH).subscribe(result => {
            this.batdongsan.maLoaiSoHuu = result.name;
        });
    }

   

    show(batdongsanId?: number | null | undefined): void {
        this.saving = false;


        this._batdongsanService.getBatDongSanForEdit(batdongsanId).subscribe(result => {
            this.batdongsan = result;
            this.modal.show();
            // default date time picker
            // $(this.sampleDateTimePicker.nativeElement).datetimepicker({
            //     locale: abp.localization.currentLanguage.name,
            //     format: 'L LT'
            // });
        })
    }

    save(): void {
        let input = this.batdongsan;
       // input.ngayMuaBatDongSan.format('yyyy-MM-dd HH:mm:ss Z');
        this.saving = true;
        this._batdongsanService.createOrEditBatDongSan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
