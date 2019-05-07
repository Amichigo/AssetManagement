import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { DirectorShoppingPlanServiceProxy, DirectorShoppingPlanInput } from '@shared/service-proxies/service-proxies';
import { ShoppingPlanServiceProxy, ShoppingPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';

@Component({
    selector: 'createOrEditDirectorShoppingPlanModal',
    templateUrl: './create-or-edit-directorShoppingPlan-modal.component.html'
})
export class CreateOrEditDirectorShoppingPlanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('directorShoppingPlanCombobox') directorShoppingPlanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    directorShoppingPlan: DirectorShoppingPlanInput = new DirectorShoppingPlanInput();
    shoppingPlan: ShoppingPlanInput = new ShoppingPlanInput();

    constructor(
        injector: Injector,
        private _directorShoppingPlanService: DirectorShoppingPlanServiceProxy,
        private _shoppingPlanService: ShoppingPlanServiceProxy
    ) {
        super(injector);
    }

    show(directorShoppingPlanId?: number | null | undefined): void {
        this.saving = false;


        this._directorShoppingPlanService.getDirectorShoppingPlanForEdit(directorShoppingPlanId).subscribe(result => {
            this.directorShoppingPlan = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.directorShoppingPlan;
        this.saving = true;
        var now = new Date();
        this.directorShoppingPlan.ngayHieuLuc = moment(now);
        this.shoppingPlan.khuVuc = this.directorShoppingPlan.khuVuc;
        this.shoppingPlan.kinhPhi = this.directorShoppingPlan.kinhPhi;
        this.shoppingPlan.nam = this.directorShoppingPlan.nam;
        this.shoppingPlan.ngayHieuLuc = this.directorShoppingPlan.ngayHieuLuc;
        this.shoppingPlan.phongBan = this.directorShoppingPlan.phongBan;
        this.directorShoppingPlan.tinhTrang = true;
        let inputShoppingPlan = this.shoppingPlan;
        this._shoppingPlanService.createOrEditShoppingPlan(inputShoppingPlan).subscribe(result => {
            this.notify.info(this.l('AddedToShoppingPlan'));
        })
        this._directorShoppingPlanService.createOrEditDirectorShoppingPlan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
