import { Component } from '@angular/core';

import { ClrDatagridStateInterface } from '@clr/angular';

import {
  UserDto,
  GetUsersGQL,
  GetUsersQueryVariables,
  UserDtoEdge
} from '../../core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  users: UserDtoEdge[];
  total: number;
  loading = true;

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

  refresh(state: ClrDatagridStateInterface) {
    this.dataGridState = state;

    const queryArgs: GetUsersQueryVariables = {
      first: this.dataGridState.page.size
    };

    // // paging
    // queryArgs.take = this.dataGridState.page.size;
    // queryArgs.skip = this.dataGridState.page.from;

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

    // // sorting
    // if (this.dataGridState.sort) {
    //   if (this.dataGridState.sort.reverse) {
    //     queryArgs.sort = {
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

    this.getUsers(queryArgs);
  }

  private getUsers(queryArgs: GetUsersQueryVariables) {
    this.loading = true;
    this.getClient.watch(queryArgs).valueChanges.subscribe(
      result => {
        if (result.errors) {
          result.errors.forEach(error => {
            console.log(error.message);
          });
        } else {
          if (result.data.users !== null) {
            this.total = result.data.users.totalCount;
            this.users = result.data.users.edges;
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
