import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, NgModule } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import moment from 'moment';
import { isDateBetween, groupBy } from '../../utils';
import { HttpClient } from '@angular/common/http';

const BASE_API_URL = 'http://localhost:5000/api/OperatingAsset';

@Component({
    templateUrl: './operating-assets.component.html',
    styleUrls: ['./operating-assets.component.css'],
    animations: [appModuleAnimation()]
})
export class OperatingAssetsComponent extends AppComponentBase implements OnInit {
    private statisticsPeriod = 0;
    private startingDate = moment().format('YYYY-MM-DD');
    private endingDate = moment().format('YYYY-MM-DD');
    private previousStartingDate = moment().subtract(1, 'days').startOf('day').format('YYYY-MM-DD');
    private previousEndingDate = moment().subtract(1, 'days').startOf('day').format('YYYY-MM-DD');

    private generalStatisticsData = [];
    private detailedData = [];

    private section1Tabs = ['Giá trị đã đầu tư', 'Số lượng tài sản đang vận hành'];
    private section1Data = [];
    private section1Labels = [];
    private section1XAxeLabel = 'Thời gian (Ngày/ Tháng/ Năm)';
    private section1YAxeLabel = '';
    private section1Legend = true;

    private section2Tabs = ['Giá trị đã đầu tư', 'Số lượng tài sản đang vận hành'];
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
                                this.loadTotalOperatingAssetsChartInOriginalValue();
                                break;

                            case 1:
                                this.loadTotalOperatingAssetsChartInPercentage();
                                break;
                        }
                        break;

                    case 1:
                        this.loadTotalOperatingAssetsChartWithComparison();
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
                        this.loadOperatingAssetsByTypesInOriginalValue();
                        break;

                    case 1:
                        this.loadOperatingAssetsByTypesInPercentage();
                        break;
                }
                break;
        }
    }

    loadOperatingAssetsByTypesInPercentage() {
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

    loadOperatingAssetsByTypesInOriginalValue() {
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
                title: "Tổng giá trị đã đầu tư",
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentAmount'],
                rate: data['amountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số tài sản đang vận hành',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentQuantity'],
                rate: data['quantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị đã trích cho khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentDepreciatedAmount'],
                rate: data['depreciatedAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationDepreciatingQuantity'],
                rate: data['inOperationDepreciatingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của tài sản nói chung',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentOriginalAmount'],
                rate: data['originalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản trong kho',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInWareQuantity'],
                rate: data['inWareQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản trong kho',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInWareOriginalAmount'],
                rate: data['inWareOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành nói chung',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationQuantity'],
                rate: data['inOperationQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành nói chung',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationOriginalAmount'],
                rate: data['inOperationOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nói chung',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationDepreciatingAmount'],
                rate: data['inOperationDepreciatingAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành, không tính khấu hao nói chung',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationNotDepreciatingQuantity'],
                rate: data['inOperationNotDepreciatingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành và được sử dụng',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndUsingQuantity'],
                rate: data['inOperationAndUsingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndUsingOriginalAmount'],
                rate: data['inOperationAndUsingOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành và được sử dụng, có tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndUsingDepreciatingQuantity'],
                rate: data['inOperationAndUsingDepreciatingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, có tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndUsingDepreciatingOriginalAmount'],
                rate: data['inOperationAndUsingDepreciatingOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành và được sử dụng, có tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['CurrentInOperationAndUsingDepreciatingAmount'],
                rate: data['InOperationAndUsingDepreciatingAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành và được sử dụng, không tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndUsingNotDepreciatingQuantity'],
                rate: data['inOperationAndUsingNotDepreciatingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, không tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndUsingNotDepreciatingOriginalAmount'],
                rate: data['inOperationAndUsingNotDepreciatingOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationButNotUsingQuantity'],
                rate: data['inOperationButNotUsingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndNotUsingOriginalAmount'],
                rate: data['inOperationAndNotUsingOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationButNotUsingDepreciatingQuantity'],
                rate: data['inOperationButNotUsingDepreciatingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndNotUsingDepreciatingOriginalAmount'],
                rate: data['inOperationAndNotUsingDepreciatingOriginalAmountRatio'],
                unit: "VN"
            },
            {
                title: 'Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationButNotUsingNotDepreciatingQuantity'],
                rate: data['inOperationButNotUsingNotDepreciatingQuantityRatio'],
                unit: "Tài sản"
            },
            {
                title: 'Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndNotUsingNotDepreciatingOriginalAmount'],
                rate: data['inOperationAndNotUsingNotDepreciatingOriginalAmountRatio'],
                unit: "VNĐ"
            },
            {
                title: 'Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao',
                startingDate: this.startingDate,
                endingDate: this.endingDate,
                value: data['currentInOperationAndNotUsingDepreciatingAmount'],
                rate: data['inOperationAndNotUsingDepreciatingAmountRatio'],
                unit: "VNĐ"
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
        this.section1Data = [{ data: temp, label: 'Giá trị đã đầu tư (VNĐ)' }];
        this.section1YAxeLabel = 'Giá trị đã đầu tư (VNĐ)';
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
        this.section1Data = [{ data: temp, label: 'Tỉ lệ phần trăm so với tổng giá trị đã đầu tư (%)' }];
        this.section1YAxeLabel = 'Tỉ lệ phần trăm so với tổng giá trị đã đầu tư (%)';
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
        this.section1YAxeLabel = 'Giá trị đã đầu tư (VNĐ)';
    }

    loadTotalOperatingAssetsChartInOriginalValue() {
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
        this.section1Data = [{ data: temp, label: 'Số lượng tài sản đang vận hành (Tài sản)' }];
        this.section1YAxeLabel = 'Số lượng tài sản đang vận hành (Tài sản)';
    }

    loadTotalOperatingAssetsChartInPercentage() {
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
        this.section1YAxeLabel = 'Tỉ lệ phần trăm so với tổng số lượng tài sản đang vận hành (%)';
        this.section1Data = [{ data: temp, label: 'Tỉ lệ phần trăm so với tổng số lượng tài sản đang vận hành (%)' }];
    }

    loadTotalOperatingAssetsChartWithComparison() {
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
        this.section1YAxeLabel = 'Số lượng tài sản đang vận hành (Tài sản)';
    }

    onPrint() {
        window.print();
    }
}
