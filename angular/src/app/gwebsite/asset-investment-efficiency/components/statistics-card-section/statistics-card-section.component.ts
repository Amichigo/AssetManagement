import { Component, OnInit, Input } from '@angular/core';

@Component({
   selector: 'app-statistics-card-section',
   templateUrl: './statistics-card-section.component.html',
   styleUrls: ['./statistics-card-section.component.css']
})
export class StatisticsCardSectionComponent extends Component {
   @Input() title;
   @Input() data;

   constructor() {
      super(null);
   }
}