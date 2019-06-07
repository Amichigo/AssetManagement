import { Component, OnInit, Input, SimpleChanges, SimpleChange } from '@angular/core';
import { checkForRequiredProps, addThousandSeparator } from '../../utils';
import moment from 'moment';

@Component({
   selector: 'app-statistics-card',
   templateUrl: './statistics-card.component.html',
   styleUrls: ['./statistics-card.component.css']
})
export class StatisticsCardComponent extends Component implements OnInit, OnChanges {
   @Input() title;
   @Input() startingDate;
   @Input() endingDate;
   @Input() value;
   @Input() rate;
   @Input() unit;
   @Input() showComparison;
   
   private tendency;
   private dateRange;
   private addThousandSeparator;

   constructor() {
      super();
   }

   ngOnInit() {
      // checkForRequiredProps(this, 'StatisticsCardComponent', ['title', 'startingDate', 'endingDate', 'value', 'rate', 'unit']);
      // this.initialize();
   }

   ngOnChanges(changes: SimpleChanges): void {
      //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
      //Add '${implements OnChanges}' to the class.
      const value: SimpleChange = changes.value;

      if (value && value.currentValue !== value.previousValue) {
         this.reload();
      }
   }

   reload() {
      const startingDate = moment(new Date(this.startingDate));
      const endingDate = moment(new Date(this.endingDate));
      const startingDateString = `${ startingDate.format('DD') } tháng ${ startingDate.format('MM') }, ${ startingDate.format('YYYY') }`;
      const endingDateString = `${ endingDate.format('DD') } tháng ${ endingDate.format('MM') }, ${ endingDate.format('YYYY') }`;
      this.dateRange = `${ startingDateString } - ${ endingDateString }`;
      this.tendency = this.getTendencyFromRate();
      this.addThousandSeparator = addThousandSeparator;
   }

   // initialize() {
   //    const startingDate = moment(new Date(this.startingDate));
   //    const endingDate = moment(new Date(this.endingDate));
   //    const startingDateString = `${ startingDate.format('DD') } tháng ${ startingDate.format('MM') }, ${ startingDate.format('YYYY') }`;
   //    const endingDateString = `${ endingDate.format('DD') } tháng ${ endingDate.format('MM') }, ${ endingDate.format('YYYY') }`;
   //    this.dateRange = `${ startingDateString } - ${ endingDateString }`;
   //    this.tendency = this.getTendencyFromRate();
   //    this.addThousandSeparator = addThousandSeparator;
   // }

   getTendencyFromRate() {
      if (this.rate > 0) {
         return 'up';
      }
      else if (this.rate < 0) {
         return 'down';
      }
      else {
         return 'stable';
      }
   }
}