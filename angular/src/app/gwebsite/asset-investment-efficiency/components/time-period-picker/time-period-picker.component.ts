import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import moment from 'moment';

@Component({
   selector: 'app-time-period-picker',
   templateUrl: './time-period-picker.component.html',
   styleUrls: ['./time-period-picker.component.css']
})
export class TimePeriodPickerComponent extends Component {
   @Input() title;
   @Output() update: EventEmitter<any> = new EventEmitter<any>();

   private showDateRangePicker = false;
   private timePeriod = 0;
   private startingDate = moment().format('YYYY-MM-DD');
   private endingDate = moment().format('YYYY-MM-DD');
   private previousStartingDate = moment().format('YYYY-MM-DD');
   private previousEndingDate = moment().format('YYYY-MM-DD');

   constructor() {
      super(null);
   }

   onChangeTimePeriod() {
      let value;

      if (typeof this.timePeriod === 'string') {
         value = parseInt(this.timePeriod);
      }
      else {
         value = this.timePeriod;
      }

      switch (value) {
         case 0:
            this.showDateRangePicker = false;
            this.startingDate = moment().format('YYYY-MM-DD');
            this.endingDate = moment().format('YYYY-MM-DD');
            this.previousStartingDate = moment().subtract(1, 'days').startOf('day').format('YYYY-MM-DD');
            this.previousEndingDate = moment().subtract(1, 'days').endOf('day').format('YYYY-MM-DD');
            break;

         case 1:
            this.showDateRangePicker = false;
            this.startingDate = moment().startOf('week').format('YYYY-MM-DD');
            this.endingDate = moment().endOf('week').format('YYYY-MM-DD');
            this.previousStartingDate = moment().subtract(1, 'weeks').startOf('week').format('YYYY-MM-DD');
            this.previousEndingDate = moment().subtract(1, 'weeks').endOf('week').format('YYYY-MM-DD');
            break;

         case 2:
            this.showDateRangePicker = false;
            this.startingDate = moment().startOf('month').format('YYYY-MM-DD');
            this.endingDate = moment().endOf('month').format('YYYY-MM-DD');
            this.previousStartingDate = moment().subtract(1, 'months').startOf('month').format('YYYY-MM-DD');
            this.previousEndingDate = moment().subtract(1, 'months').endOf('month').format('YYYY-MM-DD');
            break;

         case 3:
            this.showDateRangePicker = false;
            this.startingDate = moment().startOf('quarter').format('YYYY-MM-DD');
            this.endingDate = moment().endOf('quarter').format('YYYY-MM-DD');
            this.previousStartingDate = moment().subtract(1, 'quarters').startOf('quarter').format('YYYY-MM-DD');
            this.previousEndingDate = moment().subtract(1, 'quarters').endOf('quarter').format('YYYY-MM-DD');
            break;

         case 4:
            this.showDateRangePicker = false;
            this.startingDate = moment().startOf('year').format('YYYY-MM-DD');
            this.endingDate = moment().endOf('year').format('YYYY-MM-DD');
            this.previousStartingDate = moment().subtract(1, 'years').startOf('year').format('YYYY-MM-DD');
            this.previousEndingDate = moment().subtract(1, 'years').endOf('year').format('YYYY-MM-DD');
            break;

         case 5:
            this.showDateRangePicker = true;
            this.startingDate = moment().format('YYYY-MM-DD');
            this.endingDate = moment().format('YYYY-MM-DD');
            this.previousStartingDate = moment(new Date(this.startingDate)).subtract(1, 'years').startOf('day').format('YYYY-MM-DD');
            this.previousEndingDate = moment(new Date(this.endingDate)).subtract(1, 'years').endOf('day').format('YYYY-MM-DD');
            break;
      }

      this.onUpdate();
   }

   onUpdate() {
      this.update.emit({
         timePeriod: this.timePeriod,
         startingDate: this.startingDate,
         endingDate: this.endingDate,
         previousStartingDate: this.previousStartingDate,
         previousEndingDate: this.previousEndingDate
      });
   }
}