import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-is-male-filter',
  templateUrl: './is-male-filter.component.html',
  styleUrls: ['./is-male-filter.component.css']
})
export class IsMaleFilterComponent implements OnInit {
  private option: IsMaleFilter = IsMaleFilter.None;
  optionKeys = Object.keys(this.option).filter(Number);

  @Output()
  boolFilterValue = new EventEmitter<IsMaleFilter>();

  constructor() {}

  ngOnInit() {
    this.optionKeys = ['none'];
  }

  reset() {
    this.optionKeys = ['none'];
    this.boolFilterValue.emit(IsMaleFilter.None);
  }

  onClick(value: boolean) {
    if (value) {
      this.boolFilterValue.emit(IsMaleFilter.Male);
    } else {
      this.boolFilterValue.emit(IsMaleFilter.Female);
    }
  }
}

export enum IsMaleFilter {
  None = 0,
  Male = 1,
  Female = 2
}
