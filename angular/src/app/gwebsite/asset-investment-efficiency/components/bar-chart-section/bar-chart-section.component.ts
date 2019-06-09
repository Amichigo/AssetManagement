import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges, SimpleChange } from '@angular/core';

@Component({
   selector: 'app-bar-chart-section',
   templateUrl: './bar-chart-section.component.html',
   styleUrls: ['./bar-chart-section.component.css']
})
export class BarChartSectionComponent extends Component {
    @Input() data;
    @Input() labels;
    @Input() xAxeLabel;
    @Input() yAxeLabel;
    @Input() title;
    @Input() tabs;
    @Input() timePeriod;

    @Output() update: EventEmitter<any> = new EventEmitter<any>();

    private activeTabIndex = 0;
    private comparisonMode = 0;
    private valueType = 0;
    private showValueTypeSelection = true;
    private options;

    constructor() {
        // super();
    }

    ngOnChanges(changes: SimpleChanges): void {
        const timePeriod: SimpleChange = changes.timePeriod;
        const yAxeLabel: SimpleChange = changes.yAxeLabel;
        const xAxeLabel: SimpleChange = changes.xAxeLabel;

        if (timePeriod && timePeriod.currentValue !== timePeriod.previousValue) {
            this.onReset();
        }

        if (yAxeLabel && yAxeLabel.currentValue) {
            this.updateOptions();
        }

        if (xAxeLabel && xAxeLabel.currentValue) {
            this.updateOptions();
        }
    }

    updateOptions() {
        this.options = {
            scaleShowVerticalLines: false,
            responsive: true,
            scales: {
               xAxes: [{
                     scaleLabel: {
                        display: true,
                        labelString: this.xAxeLabel
                     }
               }],
               yAxes: [{
                     scaleLabel: {
                        display: true,
                        labelString: this.yAxeLabel
                     }
               }]
            }
        };
    }

    onChange() {
        this.update.emit({
            activeTabIndex: this.activeTabIndex,
            comparisonMode: this.comparisonMode,
            valueType: this.valueType
        });
    }

    onChangeTab(tabIndex) {
        this.activeTabIndex = tabIndex;
        this.valueType = 0;
        this.comparisonMode = 0;
        this.onChange();
    }

    onChangeValueType(e) {
        this.valueType = parseInt(e.target.value);
        this.onChange();
    }

    onChangeComparisonMode(e) {
        const value = parseInt(e.target.value);

        if (value === 0) {
            this.showValueTypeSelection = true;
        }
        else {
            this.showValueTypeSelection = false;
        }

        this.comparisonMode = parseInt(e.target.value);
        this.valueType = 0;
        this.onChange();
    }

    onReset() {
        this.activeTabIndex = 0;
        this.valueType = 0;
        this.comparisonMode = 0;
        this.showValueTypeSelection = true;
    }
}