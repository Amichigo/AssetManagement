import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { HopDongThauServiceProxy, HopDongThauInput, HopDongThauDto, ComboboxItemDto, HoSoThauDto, NhaCungCapDto } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditHopDongThauModal',
    templateUrl: './create-or-edit-hopdongthau-modal.component.html'
})
export class CreateOrEditHopDongThauModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hopdongthauCombobox') hopdongthauCombobox: ElementRef;
    @ViewChild('hosothauCombobox') hosothauCombobox: ElementRef;
    @ViewChild('nhacungcapCombobox') nhacungcapCombobox: ElementRef;
    @ViewChild('trangthaiduyetCombobox') trangthaiduyetCombobox: ElementRef;
    @ViewChild('hinhthucthauCombobox') hinhthucthauCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hopdongthau: HopDongThauInput = new HopDongThauInput();

    hoSoThau: HoSoThauDto = new HoSoThauDto();
    hoSoThaus: ComboboxItemDto[] = [];

    nhaCungCap: NhaCungCapDto = new NhaCungCapDto();
    nhaCungCaps: ComboboxItemDto[] = [];

    constructor(
        injector: Injector,
        private _hopdongthauService: HopDongThauServiceProxy
    ) {
        super(injector);
    }

    show(hopdongthauId?: number | null | undefined): void {
        this.saving = false;

        this._hopdongthauService.getHopDongThauForEdit(hopdongthauId).subscribe(result => {
            this.hopdongthau = result;
            this.modal.show();

        })

        if (hopdongthauId == null) {
            this._hopdongthauService.getHoSoThauComboboxForEditAsync(hopdongthauId).subscribe(result => {
                //this.hopdongthau = result;      
                this.hoSoThau = result.hoSoThau;
                this.hoSoThaus = result.hoSoThaus;
                this.modal.show();
                setTimeout(() => {
                    $(this.hosothauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
            this._hopdongthauService.getNhaCungCapComboboxForEditAsync(hopdongthauId).subscribe(result => {
                //this.hopdongthau = result;      
                this.nhaCungCap = result.nhaCungCap;
                this.nhaCungCaps = result.nhaCungCaps;
                this.modal.show();
                setTimeout(() => {
                    $(this.nhacungcapCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }
        
    }

    save(): void {
        let input = this.hopdongthau;
        this.saving = true;
        this._hopdongthauService.createOrEditHopDongThau(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
