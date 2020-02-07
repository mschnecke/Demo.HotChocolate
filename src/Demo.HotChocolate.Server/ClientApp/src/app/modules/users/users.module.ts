import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { UsersRoutingModule } from './users-routing.module';
import { UserComponent } from './user.component';
import { ClarityModule } from '@clr/angular';
import { IsMaleFilterComponent } from './components/is-male-filter/is-male-filter.component';
import { GenderFilterComponent } from './components/gender-filter/gender-filter.component';
import { ZipCodeFilterComponent } from './components/zip-code-filter/zip-code-filter.component';
import { DateFilterComponent } from './components/date-filter/date-filter.component';

@NgModule({
  declarations: [
    UserComponent,
    IsMaleFilterComponent,
    GenderFilterComponent,
    ZipCodeFilterComponent,
    DateFilterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UsersRoutingModule,
    ClarityModule
  ]
})
export class UsersModule {}
