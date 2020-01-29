import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-zip-code-filter',
  templateUrl: './zip-code-filter.component.html',
  styleUrls: ['./zip-code-filter.component.css']
})
export class ZipCodeFilterComponent implements OnInit {

  @Output()
  zipCodeFilterValue = new EventEmitter<number>();

  form: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.form = this.fb.group({
      zipCode: ['', Validators.pattern('[1-9]{5}')]
    });
  }

  onChange(value: string): void {
    // if (Number.isNaN(+value)) {
    //   this.invalid = true;
    //   return;
    // }

    // this.zipCodeFilterValue.emit(+value);
    // this.invalid = false;
  }
}
