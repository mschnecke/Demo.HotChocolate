import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserComponent } from './user.component';
import { ClarityModule } from '@clr/angular';

@NgModule({
  declarations: [UserComponent],
  imports: [CommonModule, UsersRoutingModule, ClarityModule]
})
export class UsersModule {}
