import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ContractServiceProxy, ContractInput, ContractDto, ComboboxItemDto, BidDto, SupplierDto, BidServiceProxy, GoodsServiceProxy } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

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
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hopdongthau: ContractInput = new ContractInput();

    hoSoThau: BidDto = new BidDto();
    hoSoThaus: ComboboxItemDto[] = [];

    nhaCungCap: SupplierDto = new SupplierDto();
    nhaCungCaps: ComboboxItemDto[] = [];

    hosothauName: string;
    hanghoaName: string;
    listHangHoa = [];

    constructor(
        injector: Injector,
        private _hopdongthauService: ContractServiceProxy,
        private _hosothauService: BidServiceProxy,
        private _hanghoaService: GoodsServiceProxy,
    ) {
        super(injector);
    }

    show(hopdongthauId?: number | null | undefined): void {
        this.saving = false;

        this._hopdongthauService.getContractForEdit(hopdongthauId).subscribe(result => {
            this.hopdongthau = result;
            this.modal.show();

        })

        if (hopdongthauId == null) {
            this._hopdongthauService.getBidComboboxForEditAsync(hopdongthauId).subscribe(result => {
                //this.hopdongthau = result;      
                this.hoSoThau = result.bid;
                this.hoSoThaus = result.bids;
                this.modal.show();
                setTimeout(() => {
                    $(this.hosothauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
            this._hopdongthauService.getSupplierComboboxForEditAsync(hopdongthauId).subscribe(result => {
                //this.hopdongthau = result;      
                this.nhaCungCap = result.supplier;
                this.nhaCungCaps = result.suppliers;
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
        this._hopdongthauService.createOrEditContract(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    setBindMaDonViTrungThau(bindingMaDonViTrungThau: any) {
        this.hopdongthau.unitAcceptedCode = bindingMaDonViTrungThau;
    }

    /**
     * Hàm get danh sách HoSoThau
     * @param event
     */
    getHoSoThaus(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);

    }

    reloadList(hosothauName, event?: LazyLoadEvent) {
        this._hosothauService.getBidsByFilter(hosothauName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.hosothauName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    onSelect(maGoiThau: any, donViThau: any) {
        this.hopdongthau.bidCode = maGoiThau;
        this.hopdongthau.unitAcceptedCode = donViThau;
    }

    /**
     * Hàm get danh sách HangHoa
     * @param event
     */
    getHangHoas(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadListHangHoa(null, event);

    }

    reloadListHangHoa(hanghoaName, event?: LazyLoadEvent) {
        this._hanghoaService.getGoodsByFilter(hanghoaName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFiltersHangHoa(): void {
        //truyền params lên url thông qua router
        this.reloadListHangHoa(this.hanghoaName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateStringHangHoa(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
}



    onSelectHangHoa(hangHoa: any) {
        if (this.listHangHoa.find(x => x.id == hangHoa.maHangHoa) === undefined) {
            this.listHangHoa.push({
                id: hangHoa.goodsCode, name: hangHoa.goodsName,
                type: hangHoa.type, price: hangHoa.price
            });
        }
    }

    removeFromListHangHoa(hangHoaID: any) {
        this.listHangHoa.splice(hangHoaID, 1); // Removes one element, starting from index

        console.log(hangHoaID);
    }

    setSelectedHangHoa(hangHoa: any) {
        if (this.hopdongthau.goodsName === undefined) {
            this.hopdongthau.goodsName = "";
        }

        this.hopdongthau.goodsName += hangHoa + ', ';
        
        
    }

}
