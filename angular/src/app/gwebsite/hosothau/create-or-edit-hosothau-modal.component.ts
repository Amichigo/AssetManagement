import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { HoSoThauServiceProxy, HoSoThauInput, HoSoThauDto, ComboboxItemDto, DuAnDto } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditHoSoThauModal',
    templateUrl: './create-or-edit-hosothau-modal.component.html'
})
export class CreateOrEditHoSoThauModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hosothauCombobox') hosothauCombobox: ElementRef;
    @ViewChild('trangthaiduyetCombobox') trangthaiduyetCombobox: ElementRef;
    @ViewChild('hinhthucthauCombobox') hinhthucthauCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hosothau: HoSoThauInput = new HoSoThauInput();

    duAn: DuAnDto = new DuAnDto();
    duAns: ComboboxItemDto[] = [];

    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauServiceProxy
    ) {
        super(injector);
    }

    show(hosothauId?: number | null | undefined): void {
        this.saving = false;

        this._hosothauService.getHoSoThauForEdit(hosothauId).subscribe(result => {
            this.hosothau = result;
            this.modal.show();

        })

        if (hosothauId == null) {
            this._hosothauService.getDuAnComboboxForEditAsync(hosothauId).subscribe(result => {
                //this.hosothau = result;      
                this.duAn = result.duAn;
                this.duAns = result.duAns;
                this.modal.show();
                setTimeout(() => {
                    $(this.hosothauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }
        
    }

    save(): void {
        let input = this.hosothau;
        this.saving = true;
        this._hosothauService.createOrEditHoSoThau(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
