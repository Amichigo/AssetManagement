import { Component, OnInit, Input, SimpleChanges, SimpleChange } from '@angular/core';
import { addThousandSeparator } from '../../utils';
import moment from 'moment';

@Component({
   selector: 'app-statistics-card',
   templateUrl: './statistics-card.component.html',
   styleUrls: ['./statistics-card.component.css']
})
export class StatisticsCardComponent extends Component implements OnChanges {
   @Input() title;
   @Input() startingDate;
   @Input() endingDate;
   @Input() value;
   @Input() rate;
   @Input() unit;
   
   private dateRange;
   private addThousandSeparator;

   constructor() {
      // super();
   }

   ngOnChanges(changes: SimpleChanges): void {
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
      this.addThousandSeparator = addThousandSeparator;
   }
}