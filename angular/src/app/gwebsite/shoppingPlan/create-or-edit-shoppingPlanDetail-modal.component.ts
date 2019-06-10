import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild,Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ShoppingPlanDetailServiceProxy, ShoppingPlanDetailInput, ShoppingPlanInput, GoodServiceProxy, GoodDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';
import { filter } from 'rxjs/operators';
import { SelectableRow, Table } from 'primeng/table';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';

@Component({
    selector: 'createOrEditShoppingPlanDetailModal',
    templateUrl: './create-or-edit-shoppingPlanDetail-modal.component.html',
    providers:[GoodServiceProxy]
})
export class CreateOrEditShoppingPlanDetailModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('shoppingPlanDetailCombobox') shoppingPlanDetailCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Input() maKeHoach: string;

    saving = false;
    maSP: string;
    tenSP: string;
    gia: string;

    shoppingPlanDetail: ShoppingPlanDetailInput = new ShoppingPlanDetailInput();
    good: GoodDto = new GoodDto();

    constructor(
        injector: Injector,
        private _shoppingPlanDetailService: ShoppingPlanDetailServiceProxy,
        private _goodService: GoodServiceProxy
    ) {
        super(injector);
    }

    getGoods(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }
        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();
        this.reloadList(null, null, null, event);
        console.log(1);
    }

    reloadList(maSP,tenSP,gia, event?: LazyLoadEvent) {
        this._goodService.getGoodsByFilter(maSP,tenSP,gia, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    show(shoppingPlanDetailId?: number | null | undefined): void {
        this.saving = false;
        this._shoppingPlanDetailService.getShoppingPlanDetailForEdit(shoppingPlanDetailId).subscribe(result => {
            this.shoppingPlanDetail = result;
            if (this.shoppingPlanDetail.maKeHoach == null) {
                this.shoppingPlanDetail.maKeHoach = this.maKeHoach;
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.shoppingPlanDetail;
        this.saving = true;
        input.giaTriMotSP = this.good.gia;
        input.maSP = this.good.maSP;
        input.tenSP = this.good.tenSP;
        this._shoppingPlanDetailService.createOrEditShoppingPlanDetail(input).subscribe(result => {
            this.notify.info(this.l('Them thanh cong!'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    rowSelected(input: any) {
        this.good.gia = input.gia;
        this.good.maSP = input.maSP;
        this.good.tenSP = input.tenSP;
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
