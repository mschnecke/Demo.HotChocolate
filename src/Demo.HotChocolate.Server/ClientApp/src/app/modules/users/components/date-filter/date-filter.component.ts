import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-date-filter',
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css']
})
export class DateFilterComponent {
  @Output()
  dateFilterValue = new EventEmitter<DateRange>();

  minimumValue: Date = undefined;
  maximumValue: Date = undefined;

  constructor() {}

  reset() {
    this.minimumValue = undefined;
    this.maximumValue = undefined;
    this.dateFilterValue.emit(undefined);
  }

  submit() {
    const range: DateRange = {
      minimumValue: this.minimumValue,
      maximumValue: this.maximumValue
    };

    this.dateFilterValue.emit(range);
  }
}

export class DateRange {
  minimumValue: Date;
  maximumValue: Date;
}
