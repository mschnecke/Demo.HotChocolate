import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { UsersRoutingModule } from './users-routing.module';
import { UserComponent } from './user.component';
import { ClarityModule } from '@clr/angular';
import { IsMaleFilterComponent } from './components/is-male-filter/is-male-filter.component';

@NgModule({
  declarations: [UserComponent, IsMaleFilterComponent],
  imports: [CommonModule, FormsModule, UsersRoutingModule, ClarityModule]
})
export class UsersModule {}
