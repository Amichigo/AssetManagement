import { ViewAssetActivityModalComponent } from './view-asset-activity-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, NgModule } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetActivityServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAssetActivityModalComponent } from './create-or-edit-asset-activity-modal.component';
import { exec } from 'child_process';

@Component({
    templateUrl: './asset-activity.component.html',
    animations: [appModuleAnimation()]
})
export class AssetActivityComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetActivityModalComponent;
    @ViewChild('viewAssetActivityModal') viewAssetActivityModal: ViewAssetActivityModalComponent;

    /**
     * tạo các biến dể filters
     */
    // customerName: string;
    assetId: string;
    assetActivityType: string;
    investmentType: string;
    startingExecutionTime: string;
    endingExecutionTime: string;
    items: any;

    // OverviewChart
    overviewChartOptions = {
        scaleShowVerticalLines: false,
        responsive: true
    };
    overviewChartLabels: any;
    overviewChartType = 'bar';
    overviewChartLegend = true;
    overviewChartData: any;

    overviewFilterStartingDate: any;
    overviewFilterEndingDate: any;

    // InvestmentChart
    investmentChartOptions = {
        scaleShowVerticalLines: false,
        responsive: true
    };
    investmentChartLabels: any;
    investmentChartType = 'bar';
    investmentChartLegend = true;
    investmentChartData: any;

    investmentFilterStartingDate: any;
    investmentFilterEndingDate: any;

    constructor(
        injector: Injector,
        private _assetActivityService: AssetActivityServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
        let today = new Date();
        let todayString = `${ today.getFullYear() }-${ this.pad(today.getMonth() + 1, 2) }-${ this.pad(today.getDate(), 2) }`
        this.overviewFilterStartingDate = todayString;
        this.overviewFilterEndingDate = todayString;
        this.investmentFilterStartingDate = todayString;
        this.investmentFilterEndingDate = todayString;
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }


    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }
    
    getDaysInMonth (month, year) {
        return new Date(year, month, 0).getDate();
    }

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getAssetActivities(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, null, event);

    }

    toTitleCase(str) {
        return str.replace(
            /\w\S*/g,
            function(txt) {
                return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
            }
        );
    }

    groupBy(items, key) {
        return items.reduce(
        (result, item) => ({
          ...result,
          [item[key]]: [
            ...(result[item[key]] || []),
            item,
          ],
        }), 
        {},
      );
    }

    calculateSumOfField(items, field) {
        let sum = 0;
        for(let i = 0; i < items.length; i++) {
          sum += items[i][field];
        }
        return sum;
    }

    pad(n, width) {
        n = n + '';
        return n.length >= width ? n : new Array(width - n.length + 1).join('0') + n;
    }

    overviewChartFilterOnChange() {
        let overviewChartLabels = [];
        let overviewChartData = [];

        let start = new Date(this.overviewFilterStartingDate);
        let end = new Date(this.overviewFilterEndingDate);
        let labels = this.items.map(record => record["assetActivityType"]).filter((x, i, a) => a.indexOf(x) == i);

        while(start <= end) {
            overviewChartLabels.push(`${ start.getDate() }/${ start.getMonth() + 1 }/${ start.getFullYear() }`);
            start.setDate(start.getDate() + 1);
        }

        let phase1 = this.items.filter(item => {
            const startingTime = new Date(this.overviewFilterStartingDate);
            const endingTime = new Date(this.overviewFilterEndingDate);
            item["executionTime"] = item['executionTime'].substr(0, 10);
            const executionTime = new Date(item["executionTime"]);
          
            if (executionTime >= startingTime && executionTime <= endingTime) {
              return item;
            }
        });

        let phase2 = this.groupBy(phase1, 'assetActivityType');
        let phase3 = {};

        for(let key1 of Object.keys(phase2)) {
            phase3[key1] = {};
            let temp1 = this.groupBy(phase2[key1], 'executionTime');
          
            for(let key2 of Object.keys(temp1)) {
              phase3[key1][key2] = this.calculateSumOfField(temp1[key2], 'cost');
            }
        }

        overviewChartData = labels.map(label => {
            let startingTime = new Date(this.overviewFilterStartingDate);
            let endingTime = new Date(this.overviewFilterEndingDate);
            let data = [];
          
            while(startingTime <= endingTime) {
              const key = `${ startingTime.getFullYear() }-${ this.pad(startingTime.getMonth() + 1, 2) }-${ this.pad(startingTime.getDate(), 2) }`;
              
              if (typeof phase3[label] !== 'undefined' && typeof phase3[label][key] !== 'undefined') {
                data.push(phase3[label][key]);
              }
              else {
                data.push(0);
              }
          
              startingTime.setDate(startingTime.getDate() + 1);
            }
          
            return { label: this.toTitleCase(label.replace('_', ' ')), data };
        });

        this.overviewChartLabels = overviewChartLabels;
        this.overviewChartData = overviewChartData;
    }

    investmentChartFilterOnChange() {
        let investmentChartLabels = [];
        let investmentChartData = [];

        let start = new Date(this.investmentFilterStartingDate);
        let end = new Date(this.investmentFilterEndingDate);
        let labels = this.items.map(record => record["investmentType"]).filter((x, i, a) => a.indexOf(x) == i);

        while(start <= end) {
            investmentChartLabels.push(`${ start.getDate() }/${ start.getMonth() + 1 }/${ start.getFullYear() }`);
            start.setDate(start.getDate() + 1);
        }

        let phase1 = this.items.filter(item => {
            const startingTime = new Date(this.investmentFilterStartingDate);
            const endingTime = new Date(this.investmentFilterEndingDate);
            item["executionTime"] = item['executionTime'].substr(0, 10);
            const executionTime = new Date(item["executionTime"]);
          
            if (executionTime >= startingTime && executionTime <= endingTime) {
              return item;
            }
        });

        let phase2 = this.groupBy(phase1, 'investmentType');
        let phase3 = {};

        for(let key1 of Object.keys(phase2)) {
            phase3[key1] = {};
            let temp1 = this.groupBy(phase2[key1], 'executionTime');
          
            for(let key2 of Object.keys(temp1)) {
              phase3[key1][key2] = this.calculateSumOfField(temp1[key2], 'cost');
            }
        }

        investmentChartData = labels.map(label => {
            let startingTime = new Date(this.investmentFilterStartingDate);
            let endingTime = new Date(this.investmentFilterEndingDate);
            let data = [];
          
            while(startingTime <= endingTime) {
              const key = `${ startingTime.getFullYear() }-${ this.pad(startingTime.getMonth() + 1, 2) }-${ this.pad(startingTime.getDate(), 2) }`;
              
              if (typeof phase3[label] !== 'undefined' && typeof phase3[label][key] !== 'undefined') {
                data.push(phase3[label][key]);
              }
              else {
                data.push(0);
              }
          
              startingTime.setDate(startingTime.getDate() + 1);
            }
          
            return { label: this.toTitleCase(label.replace('_', ' ')), data };
        });

        this.investmentChartLabels = investmentChartLabels;
        this.investmentChartData = investmentChartData;
    }

    reloadList(assetId, assetActivityType, investmentType, startingExecutionTime, endingExecutionTime, event?: LazyLoadEvent) {
        this._assetActivityService.getAssetActivitiesByFilter(assetId, assetActivityType, investmentType, startingExecutionTime, endingExecutionTime, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.items = result.items;
            console.log(result.items);
            this.overviewChartFilterOnChange();
            this.investmentChartFilterOnChange();
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    getDaysDiff(dt1, dt2) {
        let diff = (dt2.getTime() - dt1.getTime()) / 1000;
        diff /= (3600 * 24);
        return Math.abs(Math.round(diff));
      }

    deleteAssetActivity(id): void {
        this._assetActivityService.deleteAssetActivity(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.assetId = params['assetId'] || ''
            this.assetActivityType = params['assetActivityType'] || '';
            this.startingExecutionTime = params['startingExecutionTime'] || '';
            this.endingExecutionTime = params['endingExecutionTime'] || '';
            this.reloadList(this.assetId, this.assetActivityType, this.investmentType, this.startingExecutionTime, this.endingExecutionTime, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.assetId, this.assetActivityType, this.investmentType, this.startingExecutionTime, this.endingExecutionTime, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createAssetActivity() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}