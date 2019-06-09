import { CustomerServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ViewDemoModelModalComponent } from './demo-model/view-demo-model-modal.component';
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
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { AssetActivityServiceProxy } from '@shared/service-proxies/service-proxies';

import { PurchasedAssetsComponent } from './asset-investment-efficiency/pages/purchased-assets/purchased-assets.component';
import { SoldAssetsComponent } from './asset-investment-efficiency/pages/sold-assets/sold-assets.component';
import { MaintainedAssetsComponent } from './asset-investment-efficiency/pages/maintained-assets/maintained-assets.component';
import { PlannedToSellAssetsComponent } from './asset-investment-efficiency/pages/planned-to-sell-assets/planned-to-sell-assets.component';
import { PlannedToPurchaseAssetsComponent } from './asset-investment-efficiency/pages/planned-to-purchase-assets/planned-to-purchase-assets.component';
import { PlannedToMaintainAssetsComponent } from './asset-investment-efficiency/pages/planned-to-maintain-assets/planned-to-maintain-assets.component';
import { OperatingAssetsComponent } from './asset-investment-efficiency/pages/operating-assets/operating-assets.component';
import { PurchasedAssetsDataTableComponent } from './asset-investment-efficiency/pages/purchased-assets/purchased-assets-data-table/purchased-assets-data-table.component';
import { SoldAssetsDataTableComponent } from './asset-investment-efficiency/pages/sold-assets/sold-assets-data-table/sold-assets-data-table.component';
import { MaintainedAssetsDataTableComponent } from './asset-investment-efficiency/pages/maintained-assets/maintained-assets-data-table/maintained-assets-data-table.component';
import { PlannedToSellAssetsDataTableComponent } from './asset-investment-efficiency/pages/planned-to-sell-assets/planned-to-sell-assets-data-table/planned-to-sell-assets-data-table.component';
import { PlannedToPurchaseAssetsDataTableComponent } from './asset-investment-efficiency/pages/planned-to-purchase-assets/planned-to-purchase-assets-data-table/planned-to-purchase-assets-data-table.component';
import { PlannedToMaintainAssetsDataTableComponent } from './asset-investment-efficiency/pages/planned-to-maintain-assets/planned-to-maintain-assets-data-table/planned-to-maintain-assets-data-table.component';
import { OperatingAssetsDataTableComponent } from './asset-investment-efficiency/pages/operating-assets/operating-assets-data-table/operating-assets-data-table.component';
import { StatisticsCardComponent } from './asset-investment-efficiency/components/statistics-card/statistics-card.component';
import { StatisticsCardSectionComponent } from './asset-investment-efficiency/components/statistics-card-section/statistics-card-section.component';
import { TimePeriodPickerComponent } from './asset-investment-efficiency/components/time-period-picker/time-period-picker.component';
import { BarChartSectionComponent } from './asset-investment-efficiency/components/bar-chart-section/bar-chart-section.component';
import { PieChartSectionComponent } from './asset-investment-efficiency/components/pie-chart-section/pie-chart-section.component';
import { ChartsModule } from 'ng2-charts';
import { ExcelService } from './asset-investment-efficiency/utils/excel.service';
import { HttpClientModule } from '@angular/common/http';

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
        InputMaskModule,
        ChartsModule,
        HttpClientModule
    ],
    declarations: [
        MenuClientComponent,
        CreateOrEditMenuClientModalComponent,
        DemoModelComponent,
        CreateOrEditDemoModelModalComponent,
        ViewDemoModelModalComponent,
        CustomerComponent,
        CreateOrEditCustomerModalComponent,
        ViewCustomerModalComponent,
        PurchasedAssetsComponent,
        SoldAssetsComponent,
        MaintainedAssetsComponent,
        PlannedToSellAssetsComponent,
        OperatingAssetsComponent,
        PlannedToPurchaseAssetsComponent,
        PlannedToMaintainAssetsComponent,
        PurchasedAssetsComponent,
        StatisticsCardComponent,
        StatisticsCardSectionComponent,
        TimePeriodPickerComponent,
        BarChartSectionComponent,
        PurchasedAssetsDataTableComponent,
        PieChartSectionComponent,
        SoldAssetsDataTableComponent,
        MaintainedAssetsDataTableComponent,
        PlannedToSellAssetsDataTableComponent,
        PlannedToPurchaseAssetsDataTableComponent,
        PlannedToMaintainAssetsDataTableComponent,
        OperatingAssetsDataTableComponent
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        AssetActivityServiceProxy,
        ExcelService
    ]
})
export class GWebsiteModule { }
