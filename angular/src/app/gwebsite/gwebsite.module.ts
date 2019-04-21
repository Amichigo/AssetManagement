import { CustomerServiceProxy} from './../../shared/service-proxies/service-proxies';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { GWebsiteRoutingModule } from './gwebsite-routing.module';

import { MenuClientComponent, CreateOrEditMenuClientModalComponent } from './index';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { DuAnServiceProxy } from '@shared/service-proxies/service-proxies';
import { HoSoThauServiceProxy } from '@shared/service-proxies/service-proxies';
import { NhaCungCapServiceProxy } from '@shared/service-proxies/service-proxies';
import { HopDongThauServiceProxy } from '@shared/service-proxies/service-proxies';
import { PhieuGoiHangServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { DuAnComponent } from './duan/duan.component';
import { ViewDuAnModalComponent } from './duan/view-duan-modal.component';
import { CreateOrEditDuAnModalComponent } from './duan/create-or-edit-duan-modal.component';
import { HoSoThauComponent } from './hosothau/hosothau.component';
import { ViewHoSoThauModalComponent } from './hosothau/view-hosothau-modal.component';
import { CreateOrEditHoSoThauModalComponent } from './hosothau/create-or-edit-hosothau-modal.component';
import { NhaCungCapComponent } from './nhacungcap/nhacungcap.component';
import { ViewNhaCungCapModalComponent } from './nhacungcap/view-nhacungcap-modal.component';
import { CreateOrEditNhaCungCapModalComponent } from './nhacungcap/create-or-edit-nhacungcap-modal.component';
import { HopDongThauComponent } from './hopdongthau/hopdongthau.component';
import { ViewHopDongThauModalComponent } from './hopdongthau/view-hopdongthau-modal.component';
import { CreateOrEditHopDongThauModalComponent } from './hopdongthau/create-or-edit-hopdongthau-modal.component';
import { PhieuGoiHangComponent } from './phieugoihang/phieugoihang.component';
import { ViewPhieuGoiHangModalComponent } from './phieugoihang/view-phieugoihang-modal.component';
import { CreateOrEditPhieuGoiHangModalComponent } from './phieugoihang/create-or-edit-phieugoihang-modal.component';

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule
    ],
    declarations: [
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        DuAnComponent, CreateOrEditDuAnModalComponent, ViewDuAnModalComponent,
        HoSoThauComponent, CreateOrEditHoSoThauModalComponent, ViewHoSoThauModalComponent,
        NhaCungCapComponent, CreateOrEditNhaCungCapModalComponent, ViewNhaCungCapModalComponent,
        HopDongThauComponent, CreateOrEditHopDongThauModalComponent, ViewHopDongThauModalComponent,
        PhieuGoiHangComponent, CreateOrEditPhieuGoiHangModalComponent, ViewPhieuGoiHangModalComponent,
    ],
    providers: [
        CustomerServiceProxy,
        DuAnServiceProxy,
        HoSoThauServiceProxy,
        NhaCungCapServiceProxy,
        HopDongThauServiceProxy,
        PhieuGoiHangServiceProxy,
    ]
})
export class GWebsiteModule { }
