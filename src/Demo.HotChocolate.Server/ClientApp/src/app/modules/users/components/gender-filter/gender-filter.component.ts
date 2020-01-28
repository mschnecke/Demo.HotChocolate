import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-gender-filter',
  templateUrl: './gender-filter.component.html',
  styleUrls: ['./gender-filter.component.css']
})
export class GenderFilterComponent implements OnInit {
  private option: GenderFilter = GenderFilter.None;
  optionKeys = Object.keys(this.option).filter(Number);

  @Output()
  genderFilterValue = new EventEmitter<GenderFilter>();

  constructor() {}

  ngOnInit() {
    this.optionKeys = ['none'];
  }

  reset() {
    this.optionKeys = ['none'];
    this.genderFilterValue.emit(GenderFilter.None);
  }

  onClick(value: boolean) {
    if (value) {
      this.genderFilterValue.emit(GenderFilter.Male);
    } else {
      this.genderFilterValue.emit(GenderFilter.Female);
    }
  }
}

export enum GenderFilter {
  None = 0,
  Male = 1,
  Female = 2
}
