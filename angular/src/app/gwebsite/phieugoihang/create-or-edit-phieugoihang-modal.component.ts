import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { GoodsInvoiceServiceProxy, GoodsInvoiceInput, GoodsInvoiceDto, ComboboxItemDto, ContractDto, GoodsContract, SupplierServiceProxy } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

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
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    phieugoihang: GoodsInvoiceInput = new GoodsInvoiceInput();

    hopDongThau: ContractDto = new ContractDto();
    hopDongThaus: ComboboxItemDto[] = [];

    hopdongthauCode: string;
    listHopDongHangHoa: GoodsContract[] = [];
    nhacungcapName: string;
    tenDonVi: any;
    maDonVi: any;
    diaChi: any;
    donVi: any;
    listNhaCungCap = [];
    hangHoaHopDong: any;

    constructor(
        injector: Injector,
        private _phieugoihangService: GoodsInvoiceServiceProxy,
        private _nhacungcapService: SupplierServiceProxy,
    ) {
        super(injector);
    }

    show(phieugoihangId?: number | null | undefined): void {
        this.saving = false;

        this._phieugoihangService.getGoodsInvoiceForEdit(phieugoihangId).subscribe(result => {
            this.phieugoihang = result;
            this.modal.show();

        })

        if (phieugoihangId == null) {
            this._phieugoihangService.getContractComboboxForEditAsync(phieugoihangId).subscribe(result => {
                //this.phieugoihang = result;      
                this.hopDongThau = result.contract;
                this.hopDongThaus = result.contracts;
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
        this._phieugoihangService.createOrEditGoodsInvoice(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }



    reloadListHopDongHangHoa(hopdongthauCode, event?: LazyLoadEvent) {
        this._phieugoihangService.getGoodsContract(hopdongthauCode).subscribe((hanghoahopdong: GoodsContract[]) => {
            this.listHopDongHangHoa = hanghoahopdong;
        });
    }

    applyFiltersHopDongHangHoa(): void {
        //truyền params lên url thông qua router
        this.reloadListHopDongHangHoa(this.hopdongthauCode, null);
    }

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getNhaCungCaps(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadListNhaCungCap(null, event);

    }

    reloadListNhaCungCap(nhacungcapName, event?: LazyLoadEvent) {
        this._nhacungcapService.getSuppliersByFilter(nhacungcapName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFiltersNhaCungCap(): void {
        //truyền params lên url thông qua router
        this.reloadListNhaCungCap(this.nhacungcapName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    onSelectNhaCungCap(donVi: any) {
        this.phieugoihang.unitName = donVi.supplierCode;
        this.tenDonVi = donVi.supplierName;
        this.diaChi = donVi.address;

    }

    onSelectHopDongHangHoa(hopDong: any, hangHoa: any) {
        this.phieugoihang.contractName = hopDong;
        this.hangHoaHopDong = hangHoa;

    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
