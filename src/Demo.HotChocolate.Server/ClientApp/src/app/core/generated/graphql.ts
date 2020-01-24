import gql from 'graphql-tag';
import { Injectable } from '@angular/core';
import * as Apollo from 'apollo-angular';
import { MutationOptionsAlone, QueryOptionsAlone, SubscriptionOptionsAlone, WatchQueryOptionsAlone } from 'apollo-angular/types';
export type Maybe<T> = T | null;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string,
  String: string,
  Boolean: boolean,
  Int: number,
  Float: number,
  PaginationAmount: any,
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: any,
  Uuid: any,
  /** The multiplier path scalar represents a valid GraphQL multiplier path string. */
  MultiplierPath: any,
};





export enum GenderDto {
  Male = 'MALE',
  Female = 'FEMALE'
}


export type PageInfo = {
   __typename?: 'PageInfo',
  endCursor?: Maybe<Scalars['String']>,
  hasNextPage: Scalars['Boolean'],
  hasPreviousPage: Scalars['Boolean'],
  startCursor?: Maybe<Scalars['String']>,
};


export type Query = {
   __typename?: 'Query',
  users?: Maybe<UserDtoConnection>,
};


export type QueryUsersArgs = {
  after?: Maybe<Scalars['String']>,
  before?: Maybe<Scalars['String']>,
  first?: Maybe<Scalars['PaginationAmount']>,
  last?: Maybe<Scalars['PaginationAmount']>,
  order_by?: Maybe<UserDtoSort>
};

export enum SortOperationKind {
  Asc = 'ASC',
  Desc = 'DESC'
}

export type UserDto = {
   __typename?: 'UserDto',
  birthDate: Scalars['DateTime'],
  email?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  gender: GenderDto,
  id: Scalars['Uuid'],
  isMale: Scalars['Boolean'],
  lastName?: Maybe<Scalars['String']>,
  zipCode: Scalars['Int'],
};

export type UserDtoConnection = {
   __typename?: 'UserDtoConnection',
  edges?: Maybe<Array<UserDtoEdge>>,
  nodes?: Maybe<Array<Maybe<UserDto>>>,
  pageInfo: PageInfo,
  totalCount: Scalars['Int'],
};

export type UserDtoEdge = {
   __typename?: 'UserDtoEdge',
  cursor: Scalars['String'],
  node?: Maybe<UserDto>,
};

export type UserDtoSort = {
  birthDate?: Maybe<SortOperationKind>,
  email?: Maybe<SortOperationKind>,
  firstName?: Maybe<SortOperationKind>,
  gender?: Maybe<SortOperationKind>,
  id?: Maybe<SortOperationKind>,
  isMale?: Maybe<SortOperationKind>,
  lastName?: Maybe<SortOperationKind>,
  zipCode?: Maybe<SortOperationKind>,
};


export type GetUsersQueryVariables = {
  after?: Maybe<Scalars['String']>,
  before?: Maybe<Scalars['String']>,
  first?: Maybe<Scalars['PaginationAmount']>,
  last?: Maybe<Scalars['PaginationAmount']>,
  order_by?: Maybe<UserDtoSort>
};


export type GetUsersQuery = (
  { __typename?: 'Query' }
  & { users: Maybe<(
    { __typename?: 'UserDtoConnection' }
    & Pick<UserDtoConnection, 'totalCount'>
    & { pageInfo: (
      { __typename?: 'PageInfo' }
      & Pick<PageInfo, 'endCursor' | 'hasNextPage' | 'hasPreviousPage' | 'startCursor'>
    ), edges: Maybe<Array<(
      { __typename?: 'UserDtoEdge' }
      & Pick<UserDtoEdge, 'cursor'>
      & { node: Maybe<(
        { __typename?: 'UserDto' }
        & Pick<UserDto, 'birthDate' | 'email' | 'firstName' | 'gender' | 'id' | 'isMale' | 'lastName' | 'zipCode'>
      )> }
    )>> }
  )> }
);

export const GetUsersDocument = gql`
    query getUsers($after: String, $before: String, $first: PaginationAmount, $last: PaginationAmount, $order_by: UserDtoSort) {
  users(after: $after, before: $before, first: $first, last: $last, order_by: $order_by) {
    totalCount
    pageInfo {
      endCursor
      hasNextPage
      hasPreviousPage
      startCursor
    }
    edges {
      cursor
      node {
        birthDate
        email
        firstName
        gender
        id
        isMale
        lastName
        zipCode
      }
    }
  }
}
    `;

  @Injectable({
    providedIn: 'root'
  })
  export class GetUsersGQL extends Apollo.Query<GetUsersQuery, GetUsersQueryVariables> {
    document = GetUsersDocument;
    
  }