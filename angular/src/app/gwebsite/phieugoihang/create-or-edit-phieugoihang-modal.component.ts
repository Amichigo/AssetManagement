import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { PhieuGoiHangServiceProxy, PhieuGoiHangInput, PhieuGoiHangDto, ComboboxItemDto, HopDongThauDto } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditPhieuGoiHangModal',
    templateUrl: './create-or-edit-phieugoihang-modal.component.html',
    styleUrls: ['./create-or-edit-phieugoihang-modal.component.css',]
})
export class CreateOrEditPhieuGoiHangModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hopdongthauCombobox') hopdongthauCombobox: ElementRef;
    @ViewChild('donvithauCombobox') donvithauCombobox: ElementRef;
    @ViewChild('quatrinhthanhtoanCombobox') quatrinhthanhtoanCombobox: ElementRef;
    @ViewChild('tiendogiaohangCombobox') tiendogiaohangCombobox: ElementRef;
    @ViewChild('tinhtranghoadonCombobox') tinhtranghoadonCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    phieugoihang: PhieuGoiHangInput = new PhieuGoiHangInput();

    hopDongThau: HopDongThauDto = new HopDongThauDto();
    hopDongThaus: ComboboxItemDto[] = [];

    constructor(
        injector: Injector,
        private _phieugoihangService: PhieuGoiHangServiceProxy
    ) {
        super(injector);
    }

    show(phieugoihangId?: number | null | undefined): void {
        this.saving = false;

        this._phieugoihangService.getPhieuGoiHangForEdit(phieugoihangId).subscribe(result => {
            this.phieugoihang = result;
            this.modal.show();

        })

        if (phieugoihangId == null) {
            this._phieugoihangService.getHopDongThauComboboxForEditAsync(phieugoihangId).subscribe(result => {
                //this.phieugoihang = result;      
                this.hopDongThau = result.hopDongThau;
                this.hopDongThaus = result.hopDongThaus;
                this.modal.show();
                setTimeout(() => {
                    $(this.hopdongthauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }
        
    }

    save(): void {
        let input = this.phieugoihang;
        this.saving = true;
        this._phieugoihangService.createOrEditPhieuGoiHang(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
