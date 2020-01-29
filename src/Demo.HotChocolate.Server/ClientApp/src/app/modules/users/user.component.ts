import { Component } from '@angular/core';
import {
  ClrDatagridStateInterface
} from '@clr/angular';

import {
  GetUsersGQL,
  GetUsersQueryVariables,
  UserDtoConnection,
  SortOperationKind,
  GenderDto
} from '../../core';
import { IsMaleFilter } from './components/is-male-filter/is-male-filter.component';
import { GenderFilter } from './components/gender-filter/gender-filter.component';

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

  private filterIsMale: IsMaleFilter;
  private filterGender: GenderFilter;
  private filterZipCode = 0;
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
    // reset query arguments
    this.queryArgs = {};

    // paging
    this.queryArgs.before = this.connection.pageInfo.startCursor;
    this.queryArgs.last = this.dataGridState.page.size;

    // filtering
    this.setFilter();

    // sorting
    this.setSorting();

    this.getUsers(this.queryArgs);
  }

  onNextPage() {
    // reset query arguments
    this.queryArgs = {};

    // paging
    this.queryArgs.after = this.connection.pageInfo.endCursor;
    this.queryArgs.first = this.dataGridState.page.size;
    this.queryArgs.before = undefined;
    this.queryArgs.last = undefined;

    // filtering
    this.setFilter();

    // sorting
    this.setSorting();

    this.getUsers(this.queryArgs);
  }

  onGenderFilterChange($event) {
    this.filterGender = $event;
    this.refresh(this.dataGridState);
  }

  onIsMaleFilterChange($event) {
    this.filterIsMale = $event;
    this.refresh(this.dataGridState);
  }

  onZipCodeFilterChange($event) {
    console.log($event);
  }

  refresh(state: ClrDatagridStateInterface) {
    console.log('state', state);
    this.dataGridState = state;

    this.queryArgs = {};

    // paging
    this.queryArgs.first = this.dataGridState.page.size;

    // filtering
    this.setFilter();

    // sorting
    this.setSorting();

    this.getUsers(this.queryArgs);
  }

  onResetFilters() {
    this.filterGender = GenderFilter.None;
    this.filterIsMale = IsMaleFilter.None;
    this.filterZipCode = 0;

    this.dataGridState = {
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

    this.refresh(this.dataGridState);
  }

  private setFilter() {
    if (this.dataGridState.filters) {
      this.queryArgs.where = {};
      for (const filter of this.dataGridState.filters) {
        if (filter.property === 'email') {
          this.queryArgs.where.email_contains = filter.value;
        } else if (filter.property === 'firstName') {
          this.queryArgs.where.firstName_contains = filter.value;
        } else if (filter.property === 'lastName') {
          this.queryArgs.where.lastName_contains = filter.value;
        } else if (filter.property === 'birthDate') {
          this.queryArgs.where.birthDate = filter.value;
        } else if (filter.property === 'gender') {
          this.queryArgs.where.gender = filter.value;
        } else if (filter.property === 'zipCode') {
          this.queryArgs.where.zipCode = filter.value;
        }
      }
    }

    if (this.filterIsMale !== undefined) {
      if (this.filterIsMale !== IsMaleFilter.None) {
        if (this.queryArgs.where === undefined) {
          this.queryArgs.where = {};
        }

        if (this.filterIsMale === IsMaleFilter.Male) {
          this.queryArgs.where.isMale = true;
        } else {
          this.queryArgs.where.isMale = false;
        }
      }
    }

    if (this.filterGender !== undefined) {
      if (this.filterGender !== GenderFilter.None) {
        if (this.queryArgs.where === undefined) {
          this.queryArgs.where = {};
        }

        if (this.filterGender === GenderFilter.Male) {
          this.queryArgs.where.gender = GenderDto.Male;
        } else {
          this.queryArgs.where.gender = GenderDto.Female;
        }
      }
    }
  }

  private setSorting() {
    if (this.dataGridState.sort) {
      if (this.dataGridState.sort.reverse) {
        if (this.dataGridState.sort.by.toString() === 'firstName') {
          this.queryArgs.order_by = { firstName: SortOperationKind.Desc };
        } else if (this.dataGridState.sort.by.toString() === 'lastName') {
          this.queryArgs.order_by = { lastName: SortOperationKind.Desc };
        } else if (this.dataGridState.sort.by.toString() === 'birthDate') {
          this.queryArgs.order_by = { birthDate: SortOperationKind.Desc };
        } else if (this.dataGridState.sort.by.toString() === 'gender') {
          this.queryArgs.order_by = { gender: SortOperationKind.Desc };
        } else if (this.dataGridState.sort.by.toString() === 'isMale') {
          this.queryArgs.order_by = { isMale: SortOperationKind.Desc };
        } else if (this.dataGridState.sort.by.toString() === 'zipCode') {
          this.queryArgs.order_by = { zipCode: SortOperationKind.Desc };
        } else {
          this.queryArgs.order_by = { email: SortOperationKind.Desc };
        }
      } else {
        if (this.dataGridState.sort.by.toString() === 'firstName') {
          this.queryArgs.order_by = { firstName: SortOperationKind.Asc };
        } else if (this.dataGridState.sort.by.toString() === 'lastName') {
          this.queryArgs.order_by = { lastName: SortOperationKind.Asc };
        } else if (this.dataGridState.sort.by.toString() === 'birthDate') {
          this.queryArgs.order_by = { birthDate: SortOperationKind.Asc };
        } else if (this.dataGridState.sort.by.toString() === 'gender') {
          this.queryArgs.order_by = { gender: SortOperationKind.Asc };
        } else if (this.dataGridState.sort.by.toString() === 'isMale') {
          this.queryArgs.order_by = { isMale: SortOperationKind.Asc };
        } else if (this.dataGridState.sort.by.toString() === 'zipCode') {
          this.queryArgs.order_by = { zipCode: SortOperationKind.Asc };
        } else {
          this.queryArgs.order_by = { email: SortOperationKind.Asc };
        }
      }
    } else {
      this.queryArgs.order_by = { email: SortOperationKind.Asc };
    }
  }

  private getUsers(queryArgs: GetUsersQueryVariables) {
    console.log('queryArgs', this.queryArgs);

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
