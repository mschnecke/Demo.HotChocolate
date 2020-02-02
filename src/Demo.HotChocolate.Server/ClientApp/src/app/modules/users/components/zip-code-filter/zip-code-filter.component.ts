import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-zip-code-filter',
  templateUrl: './zip-code-filter.component.html',
  styleUrls: ['./zip-code-filter.component.css']
})
export class ZipCodeFilterComponent {
  @Output()
  zipCodeFilterValue = new EventEmitter<ZipCodeRange>();

  minimumValue: number;
  maximumValue: number;

  constructor() {}

  reset() {
    this.minimumValue = undefined;
    this.maximumValue = undefined;
    this.zipCodeFilterValue.emit(undefined);
  }

  submit() {
    const range: ZipCodeRange = {
      minimumValue: this.minimumValue,
      maximumValue: this.maximumValue
    };

    this.zipCodeFilterValue.emit(range);
  }
}

export class ZipCodeRange {
  minimumValue: number;
  maximumValue: number;
}
