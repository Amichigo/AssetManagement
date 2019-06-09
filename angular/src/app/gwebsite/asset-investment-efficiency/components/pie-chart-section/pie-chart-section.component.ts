import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges, SimpleChange, OnChanges } from '@angular/core';
import { getRandomColor, isDateBetween } from '../../utils';
import moment from 'moment';

@Component({
   selector: 'app-pie-chart-section',
   templateUrl: './pie-chart-section.component.html',
   styleUrls: ['./pie-chart-section.component.css']
})
export class PieChartSectionComponent extends Component implements OnInit, OnChanges {
    @Input() data;
    @Input() labels;
    @Input() title;
    @Input() tabs;
    @Input() timePeriod;

    @Output() update: EventEmitter<any> = new EventEmitter<any>();

    private activeTabIndex = 0;
    private valueType = 0;
    private showValueTypeSelection = true;
    private options;
    private colors;
    private showPieChartPopup = false;
    private moment = moment;
    private selectedLabels = [];
    private mainLabels = [];
    private mainData = [];
    private filteredLabels = [];
    private keyword = '';

    constructor() {
        super(null);
    }

    ngOnInit() {
        this.mainData = this.data;
        this.mainLabels = this.labels;
    }

    ngOnChanges(changes: SimpleChanges): void {
        const data: SimpleChange = changes.data;
        const labels: SimpleChange = changes.labels;

        if (data && data.currentValue) {
            this.mainData = data.currentValue;
        }

        if (labels && labels.currentValue) {
            this.mainLabels = labels.currentValue;
            this.filteredLabels = labels.currentValue;
        }

        this.updateColors();
    }

    updateColors() {
        this.colors = [{
            backgroundColor: this.data.map(d => {
                return getRandomColor();
            })
        }];
    }

    onChange() {
        this.update.emit({
            activeTabIndex: this.activeTabIndex,
            valueType: this.valueType
        });
    }

    onChangeTab(tabIndex) {
        this.activeTabIndex = tabIndex;
        this.valueType = 0;
        this.selectedLabels = [];
        this.keyword = '';
        this.onChange();
    }

    onChangeValueType(e) {
        this.valueType = parseInt(e.target.value);
        this.selectedLabels = [];
        this.keyword = '';
        this.onChange();
    }

    onShowPieChartPopup() {
        this.showPieChartPopup = true;
    }

    onClosePieChartPopup() {
        this.showPieChartPopup = false;
    }

    onChangeSelectedLabel(label) {
        let index = this.selectedLabels.indexOf(label);

        if (index > -1) {
            this.selectedLabels.splice(index, 1);
        }
        else {
            this.selectedLabels.push(label);
        }

        this.updateChart();
    }

    updateChart() {
        let mainLabels = [];
        let mainData = [];

        for (let i = 0; i < this.labels.length; i++) {
            if (this.selectedLabels.indexOf(this.labels[i]) === -1) {
                mainLabels.push(this.labels[i]);
                mainData.push(this.data[i]);
            }
        }

        this.mainLabels = mainLabels;
        this.mainData = mainData;
    }

    onChangeKeyword() {
        this.filteredLabels = this.labels.filter(label => {
            return label.toLowerCase().includes(this.keyword.toLowerCase());
        });
    }
}