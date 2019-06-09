import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, NgModule } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import moment from 'moment';
import { isDateBetween, groupBy } from '../../utils';
import { HttpClient } from '@angular/common/http';

const BASE_API_URL = 'http://localhost:5000/api/PlannedToSellAsset';

@Component({
    templateUrl: './planned-to-sell-assets.component.html',
    styleUrls: ['./planned-to-sell-assets.component.css'],
    animations: [appModuleAnimation()]
})
export class PlannedToSellAssetsComponent extends AppComponentBase implements OnInit {
    private statisticsPeriod = 0;
    private startingDate = moment().format('YYYY-MM-DD');
    private endingDate = moment().format('YYYY-MM-DD');
    private previousStartingDate = moment().subtract(1, 'days').startOf('day').format('YYYY-MM-DD');
    private previousEndingDate = moment().subtract(1, 'days').startOf('day').format('YYYY-MM-DD');

    private generalStatisticsData = [];
    private detailedData = [];

    private section1Tabs = ['Giá trị dự kiến thu về', 'Số lượng tài sản dự kiến thanh lý'];
    private section1Data = [];
    private section1Labels = [];
    private section1XAxeLabel = 'Thời gian (Ngày/ Tháng/ Năm)';
    private section1YAxeLabel = '';
    private section1Legend = true;

    private section2Tabs = ['Giá trị dự kiến thu về', 'Số lượng tài sản dự kiến thanh lý'];
    private section2Data = [];
    private section2Labels = [];
    private section2Legend = true;
    private section2RawData = [];

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private httpClient: HttpClient
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

    formRequestUrl(route) {
        let url = `${ BASE_API_URL }/${ route }`;

        url += '?CurrentStartingDate=' + this.startingDate;
        url += '&CurrentEndingDate=' + this.endingDate;
        url += '&PreviousStartingDate=' + this.previousStartingDate;
        url += '&PreviousEndingDate=' + this.previousEndingDate;

        return url;
    }

    formRequestHeaders() {
        return {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${ abp.auth.getToken() }`
        };
    }

    fetchGeneralStatisticsData() {
        let url = this.formRequestUrl('GetGeneralStatisticsData');
        let headers = this.formRequestHeaders();

        return this.httpClient.get<any>(url, { headers }).subscribe(data => {
            this.loadGeneralStatisticsData(data.result);
        });
    }

    fetchDetailedData() {
        let url = this.formRequestUrl('GetDetailedData');
        let headers = this.formRequestHeaders();

        return this.httpClient.get<any>(url, { headers }).subscribe(data => {
            this.loadDetailedData(data.result.items);
            this.changeSection1({ activeTabIndex: 0, valueType: 0, comparisonMode: 0 });
            this.changeSection2({ activeTabIndex: 0, valueType: 0 });
        });
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
                                this.loadTotalPlannedToSellAssetsChartInOriginalValue();
                                break;

                            case 1:
                                this.loadTotalPlannedToSellAssetsChartInPercentage();
                                break;
                        }
                        break;

                    case 1:
                        this.loadTotalPlannedToSellAssetsChartWithComparison();
                        break;
                }
                break;
        }
    }

    changeSection2(payload) {
        const { activeTabIndex, valueType } = payload;

        switch (activeTabIndex) {
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
                switch (valueType) {
                    case 0:
                        this.loadPlannedToSellAssetsByTypesInOriginalValue();
                        break;

                    case 1:
                        this.loadPlannedToSellAssetsByTypesInPercentage();
                        break;
                }
                break;
        }
    }

    loadPlannedToSellAssetsByTypesInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'assetTypeName');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['quantity'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['quantity'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
         }

         this.section2Labels = labels;
         this.section2Data = temp;
    }

    loadPlannedToSellAssetsByTypesInOriginalValue() {
        let labels = [];
        let processedData = [];
        let abc = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'assetTypeName');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordAmount = 0;

            processedData[key].forEach(d => {
                recordAmount += d['quantity'];
            });

            temp.push(recordAmount);
        }

        this.section2Data = temp;
        this.section2Labels = labels;
    }

    loadInvestedAmountByTypesInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'assetTypeName');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['amount'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['amount'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
         }

         this.section2Labels = labels;
         this.section2Data = temp;
    }

    loadInvestedAmountByTypesInOriginalValue() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'assetTypeName');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordAmount = 0;

            processedData[key].forEach(d => {
                recordAmount += d['amount'];
            });

            temp.push(recordAmount);
        }

        this.section2Data = temp;
        this.section2Labels = labels;
    }

    loadGeneralStatisticsData(data) {
        this.generalStatisticsData = [
            {
                title: "Tổng giá trị dự kiến thu về",
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentTotalAmount'],
                rate: data['amountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số tài sản dự kiến thanh lý',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentTotalQuantity'],
                rate: data['quantityRatio'],
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
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'recordedDate');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let total = 0;

            processedData[key].forEach(d => {
                total += d['amount'];
            });

            temp.push(total);
        }

        this.section1Labels = labels;
        this.section1Data = [{ data: temp, label: 'Giá trị dự kiến thu về (VNĐ)' }];
        this.section1YAxeLabel = 'Giá trị dự kiến thu về (VNĐ)';
    }

    loadTotalInvestedAmountChartInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'recordedDate');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['amount'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['amount'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
        }

        this.section1Labels = labels;
        this.section1Data = [{ data: temp, label: 'Tỉ lệ phần trăm so với tổng giá trị dự kiến thu về (%)' }];
        this.section1YAxeLabel = 'Tỉ lệ phần trăm so với tổng giá trị dự kiến thu về (%)';
    }

    loadTotalInvestedAmountChartWithComparison() {
        let processedData1 = [];
        let processedData2 = [];
        let labels = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['recordedDate'];
            const previousStartingDate = new Date(this.previousStartingDate);
            const previousEndingDate = new Date(this.previousEndingDate);

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData1.push({ ...d, recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY') });
            }
            else {
                if (this.statisticsPeriod <= 4) {
                    processedData2.push({ ...d, recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY') });
                }
                else {
                    if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), previousStartingDate, previousEndingDate)) {
                        processedData2.push({ ...d, recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY') });
                    }
                }
            }
        });

        processedData1 = groupBy(processedData1, 'recordedDate');
        processedData2 = groupBy(processedData2, 'recordedDate');

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
                recordAmount += d['amount'];
            });

            tempData1.push(recordAmount);

            for (const key of Object.keys(processedData2)) {
                let recordAmount = 0;

                processedData2[key].forEach(d => {
                    recordAmount += d['amount'];
                });

                tempData2.push(recordAmount);
            }
        }

        let tempData1Label = `${ moment(new Date(this.startingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.endingDate)).format('DD/MM/YYYY') }`;
        let tempData2Label = `${ moment(new Date(this.previousStartingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.previousEndingDate)).format('DD/MM/YYYY') }`;

        let data = [
            { data: tempData1, label: tempData1Label },
            { data: tempData2, label: tempData2Label }
        ];

        this.section1Labels = labels;
        this.section1Data = data;
        this.section1YAxeLabel = 'Giá trị dự kiến thu về (VNĐ)';
    }

    loadTotalPlannedToSellAssetsChartInOriginalValue() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'recordedDate');

        let temp = [];

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let total = 0;

            processedData[key].forEach(d => {
                total += d['quantity'];
            });

            temp.push(total);
        }

        this.section1Labels = labels;
        this.section1Data = [{ data: temp, label: 'Số lượng tài sản dự kiến thanh lý (Tài sản)' }];
        this.section1YAxeLabel = 'Số lượng tài sản dự kiến thanh lý (Tài sản)';
    }

    loadTotalPlannedToSellAssetsChartInPercentage() {
        let labels = [];
        let processedData = [];

        this.detailedData.forEach(record => {
            const recordedDate = record['recordedDate'];

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData.push({
                    ...record,
                    recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY')
                });
            }
        });

        processedData = groupBy(processedData, 'recordedDate');

        let temp = [];
        let total = 0;

        for (const key of Object.keys(processedData)) {
            processedData[key].forEach(d => {
                total += d['quantity'];
            });
        }

        for (const key of Object.keys(processedData)) {
            labels.push(key);
            let recordTotal = 0;

            processedData[key].forEach(d => {
                recordTotal += d['quantity'];
            });

            temp.push(((recordTotal / total) * 100).toFixed(2));
        }

        this.section1Labels = labels;
        this.section1YAxeLabel = 'Tỉ lệ phần trăm so với tổng số lượng tài sản dự kiến thanh lý (%)';
        this.section1Data = [{ data: temp, label: 'Tỉ lệ phần trăm so với tổng số lượng tài sản dự kiến thanh lý (%)' }];
    }

    loadTotalPlannedToSellAssetsChartWithComparison() {
        let processedData1 = [];
        let processedData2 = [];
        let labels = [];

        this.detailedData.forEach(d => {
            const recordedDate = d['recordedDate'];
            const previousStartingDate = new Date(this.previousStartingDate);
            const previousEndingDate = new Date(this.previousEndingDate);

            if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), this.startingDate, this.endingDate)) {
                processedData1.push({ ...d, recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY') });
            }
            else {
                if (this.statisticsPeriod <= 4) {
                    processedData2.push({ ...d, recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY') });
                }
                else {
                    if (isDateBetween(moment(new Date(recordedDate)).format('YYYY-MM-DD'), previousStartingDate, previousEndingDate)) {
                        processedData2.push({ ...d, recordedDate: moment(recordedDate.substr(0, 10)).format('DD/MM/YYYY') });
                    }
                }
            }
        });

        processedData1 = groupBy(processedData1, 'recordedDate');
        processedData2 = groupBy(processedData2, 'recordedDate');

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
                recordAmount += d['quantity'];
            });

            tempData1.push(recordAmount);

            for (const key of Object.keys(processedData2)) {
                let recordAmount = 0;

                processedData2[key].forEach(d => {
                    recordAmount += d['quantity'];
                });

                tempData2.push(recordAmount);
            }
        }

        let tempData1Label = `${ moment(new Date(this.startingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.endingDate)).format('DD/MM/YYYY') }`;
        let tempData2Label = `${ moment(new Date(this.previousStartingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.previousEndingDate)).format('DD/MM/YYYY') }`;

        let data = [
            { data: tempData1, label: tempData1Label },
            { data: tempData2, label: tempData2Label }
        ];

        this.section1Labels = labels;
        this.section1Data = data;
        this.section1YAxeLabel = 'Số lượng tài sản dự kiến thanh lý (Tài sản)';
    }

    onPrint() {
        window.print();
    }
}
