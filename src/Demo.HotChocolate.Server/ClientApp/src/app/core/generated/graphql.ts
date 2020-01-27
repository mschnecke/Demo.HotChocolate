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
  order_by?: Maybe<UserDtoSort>,
  where?: Maybe<UserDtoFilter>
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

export type UserDtoFilter = {
  AND?: Maybe<Array<UserDtoFilter>>,
  birthDate?: Maybe<Scalars['DateTime']>,
  birthDate_gt?: Maybe<Scalars['DateTime']>,
  birthDate_gte?: Maybe<Scalars['DateTime']>,
  birthDate_in?: Maybe<Array<Scalars['DateTime']>>,
  birthDate_lt?: Maybe<Scalars['DateTime']>,
  birthDate_lte?: Maybe<Scalars['DateTime']>,
  birthDate_not?: Maybe<Scalars['DateTime']>,
  birthDate_not_gt?: Maybe<Scalars['DateTime']>,
  birthDate_not_gte?: Maybe<Scalars['DateTime']>,
  birthDate_not_in?: Maybe<Array<Scalars['DateTime']>>,
  birthDate_not_lt?: Maybe<Scalars['DateTime']>,
  birthDate_not_lte?: Maybe<Scalars['DateTime']>,
  email?: Maybe<Scalars['String']>,
  email_contains?: Maybe<Scalars['String']>,
  email_ends_with?: Maybe<Scalars['String']>,
  email_in?: Maybe<Array<Maybe<Scalars['String']>>>,
  email_not?: Maybe<Scalars['String']>,
  email_not_contains?: Maybe<Scalars['String']>,
  email_not_ends_with?: Maybe<Scalars['String']>,
  email_not_in?: Maybe<Array<Maybe<Scalars['String']>>>,
  email_not_starts_with?: Maybe<Scalars['String']>,
  email_starts_with?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  firstName_contains?: Maybe<Scalars['String']>,
  firstName_ends_with?: Maybe<Scalars['String']>,
  firstName_in?: Maybe<Array<Maybe<Scalars['String']>>>,
  firstName_not?: Maybe<Scalars['String']>,
  firstName_not_contains?: Maybe<Scalars['String']>,
  firstName_not_ends_with?: Maybe<Scalars['String']>,
  firstName_not_in?: Maybe<Array<Maybe<Scalars['String']>>>,
  firstName_not_starts_with?: Maybe<Scalars['String']>,
  firstName_starts_with?: Maybe<Scalars['String']>,
  gender?: Maybe<GenderDto>,
  gender_gt?: Maybe<GenderDto>,
  gender_gte?: Maybe<GenderDto>,
  gender_in?: Maybe<Array<GenderDto>>,
  gender_lt?: Maybe<GenderDto>,
  gender_lte?: Maybe<GenderDto>,
  gender_not?: Maybe<GenderDto>,
  gender_not_gt?: Maybe<GenderDto>,
  gender_not_gte?: Maybe<GenderDto>,
  gender_not_in?: Maybe<Array<GenderDto>>,
  gender_not_lt?: Maybe<GenderDto>,
  gender_not_lte?: Maybe<GenderDto>,
  id?: Maybe<Scalars['Uuid']>,
  id_gt?: Maybe<Scalars['Uuid']>,
  id_gte?: Maybe<Scalars['Uuid']>,
  id_in?: Maybe<Array<Scalars['Uuid']>>,
  id_lt?: Maybe<Scalars['Uuid']>,
  id_lte?: Maybe<Scalars['Uuid']>,
  id_not?: Maybe<Scalars['Uuid']>,
  id_not_gt?: Maybe<Scalars['Uuid']>,
  id_not_gte?: Maybe<Scalars['Uuid']>,
  id_not_in?: Maybe<Array<Scalars['Uuid']>>,
  id_not_lt?: Maybe<Scalars['Uuid']>,
  id_not_lte?: Maybe<Scalars['Uuid']>,
  isMale?: Maybe<Scalars['Boolean']>,
  isMale_not?: Maybe<Scalars['Boolean']>,
  lastName?: Maybe<Scalars['String']>,
  lastName_contains?: Maybe<Scalars['String']>,
  lastName_ends_with?: Maybe<Scalars['String']>,
  lastName_in?: Maybe<Array<Maybe<Scalars['String']>>>,
  lastName_not?: Maybe<Scalars['String']>,
  lastName_not_contains?: Maybe<Scalars['String']>,
  lastName_not_ends_with?: Maybe<Scalars['String']>,
  lastName_not_in?: Maybe<Array<Maybe<Scalars['String']>>>,
  lastName_not_starts_with?: Maybe<Scalars['String']>,
  lastName_starts_with?: Maybe<Scalars['String']>,
  OR?: Maybe<Array<UserDtoFilter>>,
  zipCode?: Maybe<Scalars['Int']>,
  zipCode_gt?: Maybe<Scalars['Int']>,
  zipCode_gte?: Maybe<Scalars['Int']>,
  zipCode_in?: Maybe<Array<Scalars['Int']>>,
  zipCode_lt?: Maybe<Scalars['Int']>,
  zipCode_lte?: Maybe<Scalars['Int']>,
  zipCode_not?: Maybe<Scalars['Int']>,
  zipCode_not_gt?: Maybe<Scalars['Int']>,
  zipCode_not_gte?: Maybe<Scalars['Int']>,
  zipCode_not_in?: Maybe<Array<Scalars['Int']>>,
  zipCode_not_lt?: Maybe<Scalars['Int']>,
  zipCode_not_lte?: Maybe<Scalars['Int']>,
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
  order_by?: Maybe<UserDtoSort>,
  where?: Maybe<UserDtoFilter>
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
    query getUsers($after: String, $before: String, $first: PaginationAmount, $last: PaginationAmount, $order_by: UserDtoSort, $where: UserDtoFilter) {
  users(after: $after, before: $before, first: $first, last: $last, order_by: $order_by, where: $where) {
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