import { Component } from '@angular/core';
import { ClrDatagridStateInterface } from '@clr/angular';

import {
  GetUsersGQL,
  GetUsersQueryVariables,
  UserDtoConnection,
  SortOperationKind
} from '../../core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  loading = true;
  connection: UserDtoConnection = {
    totalCount: 0,
    pageInfo: {
      hasNextPage: false,
      hasPreviousPage: false
    }
  };

  private queryArgs: GetUsersQueryVariables = {};

  private dataGridState: ClrDatagridStateInterface = {
    page: {
      size: 10,
      from: 0
    },
    filters: [] = [],
    sort: {
      by: '',
      reverse: false
    }
  };

  constructor(private getClient: GetUsersGQL) {}

  onPreviousPage() {
    this.queryArgs.after = undefined;
    this.queryArgs.before = this.connection.pageInfo.startCursor;
    this.refresh(this.dataGridState);
  }

  onNextPage() {
    this.queryArgs.before = undefined;
    this.queryArgs.after = this.connection.pageInfo.endCursor;
    this.refresh(this.dataGridState);
  }

  refresh(state: ClrDatagridStateInterface) {
    this.dataGridState = state;

    // paging
    this.queryArgs.first = this.dataGridState.page.size;

    // // filtering
    // if (this.dataGridState.filters) {
    //   for (const filter of this.dataGridState.filters) {
    //     const { property, value } = filter as {
    //       property: string;
    //       value: string;
    //     };

    //     queryArgs.filters.push({ key: property, value: value });
    //   }
    // }

    // sorting
    this.queryArgs.order_by = { email: SortOperationKind.Asc };

    // if (this.dataGridState.sort) {
    //   if (this.dataGridState.sort.reverse) {
    //     queryArgs.order_by.sort = {
    //       field: this.dataGridState.sort.by.toString(),
    //       kind: SortKind.Desc
    //     };
    //   } else {
    //     queryArgs.sort = {
    //       field: this.dataGridState.sort.by.toString(),
    //       kind: SortKind.Asc
    //     };
    //   }
    // } else {
    //   queryArgs.sort = {
    //     field: 'name',
    //     kind: SortKind.Asc
    //   };
    // }

    console.log('queryArgs', this.queryArgs);
    this.getUsers(this.queryArgs);
  }

  private getUsers(queryArgs: GetUsersQueryVariables) {
    this.loading = true;
    this.getClient.watch(queryArgs).valueChanges.subscribe(
      result => {
        if (result.errors) {
          this.loading = false;
          result.errors.forEach(error => {
            console.log(error.message);
          });
        } else {
          if (result.data.users !== null) {
            this.connection = result.data.users;
            this.loading = result.loading;
          }
        }
      },
      err => {
        this.loading = false;
        console.error(err);
      }
    );
  }
}
