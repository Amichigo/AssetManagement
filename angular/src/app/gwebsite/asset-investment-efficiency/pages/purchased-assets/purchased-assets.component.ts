import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, NgModule } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AssetActivityServiceProxy } from '@shared/service-proxies/service-proxies';
import moment from 'moment';
import { getGeneralStatisticsData, getDetailedData } from '../../api/asset-purchase';
import { isDateBetween, groupBy } from '../../utils';

@Component({
    templateUrl: './purchased-assets.component.html',
    styleUrls: ['./purchased-assets.component.css'],
    animations: [appModuleAnimation()]
})
export class PurchasedAssetsComponent extends AppComponentBase implements OnInit {
    private statisticsPeriod = 0;
    private startingDate = moment().format('YYYY-MM-DD');
    private endingDate = moment().format('YYYY-MM-DD');
    private previousStartingDate;
    private previousEndingDate;

    private generalStatisticsData = [];
    private detailedData = [];

    private section1Tabs = ['Số vốn đã đầu tư', 'Số lượng tài sản đã mua'];
    private section1Data = [];
    private section1Labels = [];
    private section1XAxeLabel = 'Thời gian (Ngày/ Tháng/ Năm)';
    private section1YAxeLabel = '';
    private section1Legend = true;

    private section2Tabs = ['Số vốn đã đầu tư', 'Số lượng tài sản đã mua'];
    private section2Data = [];
    private section2Labels = [];
    private section2Legend = true;
    private section2RawData = [];

    constructor(
        injector: Injector,
        private _assetActivityService: AssetActivityServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    ngOnInit() {
        this.fetchData();
    }

    fetchData() {
        this.fetchGeneralStatisticsData();
        this.fetchDetailedData();
    }

    fetchGeneralStatisticsData() {
        setTimeout(() => {
            const data = getGeneralStatisticsData({
                starting_date: this.startingDate,
                ending_date: this.endingDate,
                statistics_period: this.statisticsPeriod
            });

            this.loadGeneralStatisticsData(data);
        }, 1000);
    }

    fetchDetailedData() {
        setTimeout(() => {
            const data = getDetailedData({
                starting_date: this.startingDate,
                ending_date: this.endingDate,
                statistics_period: this.statisticsPeriod
            });

            this.loadDetailedData(data);
            this.changeSection1({ activeTabIndex: 0, valueType: 0, comparisonMode: 0 });
            this.changeSection2({ activeTabIndex: 0, valueType: 0, comparisonMode: 0 });
        }, 1000);
    }

    changeTimePeriod(payload) {
        const { timePeriod, startingDate, endingDate, previousStartingDate, previousEndingDate } = payload;

        this.statisticsPeriod = timePeriod;
        this.startingDate = startingDate;
        this.endingDate = endingDate;
        this.previousStartingDate = previousStartingDate;
        this.previousEndingDate = previousEndingDate;

        this.fetchData();
    }

    changeSection1(payload) {
        const { activeTabIndex, valueType, comparisonMode } = payload;

        switch (activeTabIndex) {
            case 0:
                switch (comparisonMode) {
                    case 0:
                        switch (valueType) {
                            case 0:
                                this.loadTotalInvestedAmountChartInOriginalValue();
                                break;

                            case 1:
                                this.loadTotalInvestedAmountChartInPercentage();
                                break;
                        }
                        break;

                    case 1:
                        this.loadTotalInvestedAmountChartWithComparison();
                        break;
                }
                break;

            case 1:
                switch (comparisonMode) {
                    case 0:
                        switch (valueType) {
                            case 0:
                                this.loadTotalPurchasedAssetsChartInOriginalValue();
                                break;

                            case 1:
                                this.loadTotalPurchasedAssetsChartInPercentage();
                                break;
                        }
                        break;

                    case 1:
                        this.loadTotalPurchasedAssetsChartWithComparison();
                        break;
                }
                break;
        }
    }

    changeSection2(payload) {
        const { activeTabIndex, valueType, comparisonMode } = payload;

        switch (activeTabIndex) {
            case 0:
                switch (comparisonMode) {
                    case 0:
                        switch (valueType) {
                            case 0:
                                this.loadInvestedAmountByTypesInOriginalValue();
                                break;

                            case 1:
                                this.loadInvestedAmountByTypesInPercentage();
                                break;
                        }
                        break;

                    case 1:
                        this.loadInvestedAmountByTypesWithComparison();
                        break;
                }
                break;

            case 1:
                switch (comparisonMode) {
                    case 0:
                        switch (valueType) {
                            case 0:
                                this.loadPurchasedAssetsByTypesInOriginalValue();
                                break;

                            case 1:
                                this.loadPurchasedAssetsByTypesInPercentage();
                                break;
                        }
                        break;

                    case 1:
                        this.loadPurchasedAssetsByTypesWithComparison();
                        break;
                }
                break;
        }
    }

    loadPurchasedAssetsByTypesWithComparison() {

    }

    loadPurchasedAssetsByTypesInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push(d);
            }
        });

        processedData = groupBy(processedData, 'AssetTypeName');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['Quantity'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['Quantity'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
         }

         this.section2Labels = labels;
         this.section2Data = temp;
    }

    loadPurchasedAssetsByTypesInOriginalValue() {
        let labels = [];
        let processedData = [];
        let abc = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push(d);
            }
        });

        processedData = groupBy(processedData, 'AssetTypeName');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordAmount = 0;

            processedData[key].forEach(d => {
                recordAmount += d['Quantity'];
            });

            temp.push(recordAmount);
        }

        this.section2Data = temp;
        this.section2Labels = labels;
    }

    loadInvestedAmountByTypesInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push(d);
            }
        });

        processedData = groupBy(processedData, 'AssetTypeName');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['Amount'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['Amount'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
         }

         this.section2Labels = labels;
         this.section2Data = temp;
    }

    loadInvestedAmountByTypesWithComparison() {
        // throw new Error("Method not implemented.");
    }

    loadInvestedAmountByTypesInOriginalValue() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push(d);
            }
        });

        processedData = groupBy(processedData, 'AssetTypeName');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordAmount = 0;

            processedData[key].forEach(d => {
                recordAmount += d['Amount'];
            });

            temp.push(recordAmount);
        }

        this.section2Data = temp;
        this.section2Labels = labels;
    }

    loadGeneralStatisticsData(data) {
        this.generalStatisticsData = [
            {
                title: "Tổng số vốn đã đầu tư",
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['CurrentTotalInvestedAmount'],
                rate: data['TotalInvestedAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số tài sản đã mua',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['CurrentTotalPurchasedAssets'],
                rate: data['TotalPurchasedAssetsRatio'],
                unit: "Tài sản"
            }
        ];
    }

    loadDetailedData(data) {
        this.detailedData = data;
    }

    loadTotalInvestedAmountChartInOriginalValue() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    RecordedDate: moment(recordedDate).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'RecordedDate');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let total = 0;

            processedData[key].forEach(d => {
                total += d['Amount'];
            });

            temp.push(total);
        }

        this.section1Labels = labels;
        this.section1Data = [{ data: temp, label: 'Số vốn đã đầu tư (VNĐ)' }];
        this.section1YAxeLabel = 'Số vốn đã đầu tư (VNĐ)';
    }

    loadTotalInvestedAmountChartInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    RecordedDate: moment(recordedDate).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'RecordedDate');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['Amount'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['Amount'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
        }

        this.section1Labels = labels;
        this.section1Data = [{ data: temp, label: 'Tỉ lệ phần trăm so với tổng số vốn đã đầu tư (%)' }];
        this.section1YAxeLabel = 'Tỉ lệ phần trăm so với tổng số vốn đã đầu tư (%)';
    }

    loadTotalInvestedAmountChartWithComparison() {
        let processedData1 = [];
        let processedData2 = [];
        let labels = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['RecordedDate'];
            const previousStartingDate = new Date(this.previousStartingDate);
            const previousEndingDate = new Date(this.previousEndingDate);

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData1.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
            }
            else {
                if (this.statisticsPeriod <= 4) {
                    processedData2.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                }
                else {
                    if (isDateBetween(recordedDate, previousStartingDate, previousEndingDate)) {
                        processedData2.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                    }
                }
            }
        });

        processedData1 = groupBy(processedData1, 'RecordedDate');
        processedData2 = groupBy(processedData2, 'RecordedDate');

        let tempData1 = [];
        let tempData2 = [];
        let i = 0;

        for (const key of Object.keys(processedData1)) {
            let statisticsPeriod;

            if (typeof this.statisticsPeriod === 'string') {
                statisticsPeriod = parseInt(this.statisticsPeriod);
            }
            i++;

            switch (statisticsPeriod) {
                case 0:
                    labels.push('Hôm qua và hôm nay');
                    break;

                case 1:
                    const dayOfWeek = moment(key, 'DD/MM/YYYY').day();
                    const dayOfWeekString = dayOfWeek === 0 ? 'Chủ nhật' : `Thứ ${ dayOfWeek + 1}`;
                    labels.push(dayOfWeekString);
                    break;

                case 2:
                    labels.push(`Ngày ${ i }`);
                    break;

                case 3:
                    labels.push(`Ngày ${ i }`);
                    break;

                case 4:
                    labels.push(key.split('/').slice(0, 2).join('/'));
                    break;

                case 5:
                    labels.push(key.split('/').slice(0, 2).join('/'));
                    break;
            }

            let recordAmount = 0;

            processedData1[key].forEach(d => {
                recordAmount += d['Amount'];
            });

            tempData1.push(recordAmount);

            for (const key of Object.keys(processedData2)) {
                let recordAmount = 0;

                processedData2[key].forEach(d => {
                    recordAmount += d['Amount'];
                });

                tempData2.push(recordAmount);
            }
        }

        let data = [
            { data: tempData1, label: `${ moment(new Date(this.startingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.endingDate)).format('DD/MM/YYYY') }` },
            { data: tempData2, label: `${ Object.keys(processedData2)[0] } - ${ Object.keys(processedData2)[Object.keys(processedData2).length - 1] }` }
        ];

        this.section1Labels = labels;
        this.section1Data = data;
        this.section1YAxeLabel = 'Số vốn đã đầu tư (VNĐ)';
    }

    loadTotalPurchasedAssetsChartInOriginalValue() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    RecordedDate: moment(recordedDate).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'RecordedDate');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let total = 0;

            processedData[key].forEach(d => {
                total += d['Quantity'];
            });

            temp.push(total);
        }

        this.section1Labels = labels;
        this.section1Data = [{ data: temp, label: 'Số lượng tài sản đã mua (Tài sản)' }];
        this.section1YAxeLabel = 'Số lượng tài sản đã mua (Tài sản)';
    }

    loadTotalPurchasedAssetsChartInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['RecordedDate'];

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    RecordedDate: moment(recordedDate).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'RecordedDate');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['Quantity'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['Quantity'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
        }

        this.section1Labels = labels;
        this.section1YAxeLabel = 'Tỉ lệ phần trăm so với tổng số lượng tài sản đã mua (%)';
        this.section1Data = [{ data: temp, label: 'Tỉ lệ phần trăm so với tổng số lượng tài sản đã mua (%)' }];
    }

    loadTotalPurchasedAssetsChartWithComparison() {
        let processedData1 = [];
        let processedData2 = [];
        let labels = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['RecordedDate'];
            const previousStartingDate = new Date(this.previousStartingDate);
            const previousEndingDate = new Date(this.previousEndingDate);

            if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                processedData1.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
            }
            else {
                if (this.statisticsPeriod <= 4) {
                    processedData2.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                }
                else {
                    if (isDateBetween(recordedDate, previousStartingDate, previousEndingDate)) {
                        processedData2.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                    }
                }
            }
        });

        processedData1 = groupBy(processedData1, 'RecordedDate');
        processedData2 = groupBy(processedData2, 'RecordedDate');

        let tempData1 = [];
        let tempData2 = [];
        let i = 0;

        for (const key of Object.keys(processedData1)) {
            let statisticsPeriod;

            if (typeof this.statisticsPeriod === 'string') {
                statisticsPeriod = parseInt(this.statisticsPeriod);
            }
            i++;

            switch (statisticsPeriod) {
                case 0:
                    labels.push('Hôm qua và hôm nay');
                    break;

                case 1:
                    const dayOfWeek = moment(key, 'DD/MM/YYYY').day();
                    const dayOfWeekString = dayOfWeek === 0 ? 'Chủ nhật' : `Thứ ${ dayOfWeek + 1}`;
                    labels.push(dayOfWeekString);
                    break;

                case 2:
                    labels.push(`Ngày ${ i }`);
                    break;

                case 3:
                    labels.push(`Ngày ${ i }`);
                    break;

                case 4:
                    labels.push(key.split('/').slice(0, 2).join('/'));
                    break;

                case 5:
                    labels.push(key.split('/').slice(0, 2).join('/'));
                    break;
            }

            let recordAmount = 0;

            processedData1[key].forEach(d => {
                recordAmount += d['Quantity'];
            });

            tempData1.push(recordAmount);

            for (const key of Object.keys(processedData2)) {
                let recordAmount = 0;

                processedData2[key].forEach(d => {
                    recordAmount += d['Quantity'];
                });

                tempData2.push(recordAmount);
            }
        }

        let data = [
            { data: tempData1, label: `${ moment(new Date(this.startingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.endingDate)).format('DD/MM/YYYY') }` },
            { data: tempData2, label: `${ Object.keys(processedData2)[0] } - ${ Object.keys(processedData2)[Object.keys(processedData2).length - 1] }` }
        ];

        this.section1Labels = labels;
        this.section1Data = data;
        this.section1YAxeLabel = 'Số lượng tài sản đã mua (Tài sản)';
    }
}
