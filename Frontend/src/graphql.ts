import { Injectable } from '@angular/core';
import * as Apollo from 'apollo-angular';
import { gql } from 'apollo-angular';

export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = {
    [K in keyof T]: T[K];
};
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & {
    [SubKey in K]?: Maybe<T[SubKey]>;
};
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & {
    [SubKey in K]: Maybe<T[SubKey]>;
};
export type MakeEmpty<
    T extends { [key: string]: unknown },
    K extends keyof T
> = { [_ in K]?: never };
export type Incremental<T> =
    | T
    | {
          [P in keyof T]?: P extends ' $fragmentName' | '__typename'
              ? T[P]
              : never;
      };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
    ID: { input: string; output: string };
    String: { input: string; output: string };
    Boolean: { input: boolean; output: boolean };
    Int: { input: number; output: number };
    Float: { input: number; output: number };
    /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
    DateTime: { input: any; output: any };
    UUID: { input: any; output: any };
};

export enum AccountType {
    Active = 'ACTIVE',
    Passive = 'PASSIVE'
}

export type AccountTypeOperationFilterInput = {
    eq?: InputMaybe<AccountType>;
    in?: InputMaybe<Array<AccountType>>;
    neq?: InputMaybe<AccountType>;
    nin?: InputMaybe<Array<AccountType>>;
};

export type BankAccount = {
    __typename?: 'BankAccount';
    accountType: AccountType;
    amount: Scalars['Float']['output'];
    cards?: Maybe<Array<CardDto>>;
    credit: Scalars['Float']['output'];
    creditContract?: Maybe<CreditContract>;
    currency: Currency;
    debit: Scalars['Float']['output'];
    depositContract?: Maybe<DepositContract>;
    ibanNumber: Scalars['String']['output'];
    id: Scalars['UUID']['output'];
    typeOfAccount: TypeOfAccount;
};

export type BankAccountFilterInput = {
    accountType?: InputMaybe<AccountTypeOperationFilterInput>;
    amount?: InputMaybe<FloatOperationFilterInput>;
    and?: InputMaybe<Array<BankAccountFilterInput>>;
    cards?: InputMaybe<ListFilterInputTypeOfCardDtoFilterInput>;
    credit?: InputMaybe<FloatOperationFilterInput>;
    creditContract?: InputMaybe<CreditContractFilterInput>;
    currency?: InputMaybe<CurrencyFilterInput>;
    debit?: InputMaybe<FloatOperationFilterInput>;
    depositContract?: InputMaybe<DepositContractFilterInput>;
    ibanNumber?: InputMaybe<StringOperationFilterInput>;
    id?: InputMaybe<UuidOperationFilterInput>;
    or?: InputMaybe<Array<BankAccountFilterInput>>;
    typeOfAccount?: InputMaybe<TypeOfAccountOperationFilterInput>;
};

export type BankAccountSortInput = {
    accountType?: InputMaybe<SortEnumType>;
    amount?: InputMaybe<SortEnumType>;
    credit?: InputMaybe<SortEnumType>;
    creditContract?: InputMaybe<CreditContractSortInput>;
    currency?: InputMaybe<CurrencySortInput>;
    debit?: InputMaybe<SortEnumType>;
    depositContract?: InputMaybe<DepositContractSortInput>;
    ibanNumber?: InputMaybe<SortEnumType>;
    id?: InputMaybe<SortEnumType>;
    typeOfAccount?: InputMaybe<SortEnumType>;
};

export type BooleanOperationFilterInput = {
    eq?: InputMaybe<Scalars['Boolean']['input']>;
    neq?: InputMaybe<Scalars['Boolean']['input']>;
};

export type CardDto = {
    __typename?: 'CardDto';
    bankAccount: BankAccount;
    cardNumber: Scalars['String']['output'];
    client: Client;
    id: Scalars['Int']['output'];
    isBlocked: Scalars['Boolean']['output'];
    pin: Scalars['Int']['output'];
};

export type CardDtoFilterInput = {
    and?: InputMaybe<Array<CardDtoFilterInput>>;
    bankAccount?: InputMaybe<BankAccountFilterInput>;
    cardNumber?: InputMaybe<StringOperationFilterInput>;
    client?: InputMaybe<ClientFilterInput>;
    id?: InputMaybe<IntOperationFilterInput>;
    isBlocked?: InputMaybe<BooleanOperationFilterInput>;
    or?: InputMaybe<Array<CardDtoFilterInput>>;
    pin?: InputMaybe<IntOperationFilterInput>;
};

export type CardDtoSortInput = {
    bankAccount?: InputMaybe<BankAccountSortInput>;
    cardNumber?: InputMaybe<SortEnumType>;
    client?: InputMaybe<ClientSortInput>;
    id?: InputMaybe<SortEnumType>;
    isBlocked?: InputMaybe<SortEnumType>;
    pin?: InputMaybe<SortEnumType>;
};

export type CardInfoDto = {
    __typename?: 'CardInfoDto';
    amount: Scalars['Float']['output'];
    card: CardDto;
    transitLogs?: Maybe<Array<TransitLog>>;
};

export type Citizenship = {
    __typename?: 'Citizenship';
    id: Scalars['Int']['output'];
    name: Scalars['String']['output'];
};

export type CitizenshipFilterInput = {
    and?: InputMaybe<Array<CitizenshipFilterInput>>;
    id?: InputMaybe<IntOperationFilterInput>;
    name?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<CitizenshipFilterInput>>;
};

export type CitizenshipSortInput = {
    id?: InputMaybe<SortEnumType>;
    name?: InputMaybe<SortEnumType>;
};

export type City = {
    __typename?: 'City';
    id: Scalars['Int']['output'];
    name: Scalars['String']['output'];
};

export type CityFilterInput = {
    and?: InputMaybe<Array<CityFilterInput>>;
    id?: InputMaybe<IntOperationFilterInput>;
    name?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<CityFilterInput>>;
};

export type CitySortInput = {
    id?: InputMaybe<SortEnumType>;
    name?: InputMaybe<SortEnumType>;
};

export type Client = {
    __typename?: 'Client';
    birthDate: Scalars['DateTime']['output'];
    birthPlace: Scalars['String']['output'];
    cards?: Maybe<Array<CardDto>>;
    citizenship: Citizenship;
    creditContracts?: Maybe<Array<CreditContract>>;
    depositContracts?: Maybe<Array<DepositContract>>;
    disabilityGroup: DisabilityGroup;
    email?: Maybe<Scalars['String']['output']>;
    firstName: Scalars['String']['output'];
    gender: GenderType;
    homePhoneNumber?: Maybe<Scalars['String']['output']>;
    id: Scalars['UUID']['output'];
    identificationNumber: Scalars['String']['output'];
    isLiableForMilitaryService: Scalars['Boolean']['output'];
    isRetired: Scalars['Boolean']['output'];
    lastName: Scalars['String']['output'];
    livingAddress: Scalars['String']['output'];
    livingCity: City;
    maritalStatus: MaritalStatus;
    passportIssueDate: Scalars['DateTime']['output'];
    passportIssuer: Scalars['String']['output'];
    passportNumber: Scalars['String']['output'];
    passportSeries: Scalars['String']['output'];
    patronymic: Scalars['String']['output'];
    phoneNumber?: Maybe<Scalars['String']['output']>;
    position?: Maybe<Scalars['String']['output']>;
    registrationAddress: Scalars['String']['output'];
    registrationCity: City;
    salary?: Maybe<Scalars['Float']['output']>;
    workPlace?: Maybe<Scalars['String']['output']>;
};

export type ClientFilterInput = {
    and?: InputMaybe<Array<ClientFilterInput>>;
    birthDate?: InputMaybe<DateTimeOperationFilterInput>;
    birthPlace?: InputMaybe<StringOperationFilterInput>;
    cards?: InputMaybe<ListFilterInputTypeOfCardDtoFilterInput>;
    citizenship?: InputMaybe<CitizenshipFilterInput>;
    creditContracts?: InputMaybe<ListFilterInputTypeOfCreditContractFilterInput>;
    depositContracts?: InputMaybe<ListFilterInputTypeOfDepositContractFilterInput>;
    disabilityGroup?: InputMaybe<DisabilityGroupOperationFilterInput>;
    email?: InputMaybe<StringOperationFilterInput>;
    firstName?: InputMaybe<StringOperationFilterInput>;
    gender?: InputMaybe<GenderTypeOperationFilterInput>;
    homePhoneNumber?: InputMaybe<StringOperationFilterInput>;
    id?: InputMaybe<UuidOperationFilterInput>;
    identificationNumber?: InputMaybe<StringOperationFilterInput>;
    isLiableForMilitaryService?: InputMaybe<BooleanOperationFilterInput>;
    isRetired?: InputMaybe<BooleanOperationFilterInput>;
    lastName?: InputMaybe<StringOperationFilterInput>;
    livingAddress?: InputMaybe<StringOperationFilterInput>;
    livingCity?: InputMaybe<CityFilterInput>;
    maritalStatus?: InputMaybe<MaritalStatusOperationFilterInput>;
    or?: InputMaybe<Array<ClientFilterInput>>;
    passportIssueDate?: InputMaybe<DateTimeOperationFilterInput>;
    passportIssuer?: InputMaybe<StringOperationFilterInput>;
    passportNumber?: InputMaybe<StringOperationFilterInput>;
    passportSeries?: InputMaybe<StringOperationFilterInput>;
    patronymic?: InputMaybe<StringOperationFilterInput>;
    phoneNumber?: InputMaybe<StringOperationFilterInput>;
    position?: InputMaybe<StringOperationFilterInput>;
    registrationAddress?: InputMaybe<StringOperationFilterInput>;
    registrationCity?: InputMaybe<CityFilterInput>;
    salary?: InputMaybe<FloatOperationFilterInput>;
    workPlace?: InputMaybe<StringOperationFilterInput>;
};

export type ClientSortInput = {
    birthDate?: InputMaybe<SortEnumType>;
    birthPlace?: InputMaybe<SortEnumType>;
    citizenship?: InputMaybe<CitizenshipSortInput>;
    disabilityGroup?: InputMaybe<SortEnumType>;
    email?: InputMaybe<SortEnumType>;
    firstName?: InputMaybe<SortEnumType>;
    gender?: InputMaybe<SortEnumType>;
    homePhoneNumber?: InputMaybe<SortEnumType>;
    id?: InputMaybe<SortEnumType>;
    identificationNumber?: InputMaybe<SortEnumType>;
    isLiableForMilitaryService?: InputMaybe<SortEnumType>;
    isRetired?: InputMaybe<SortEnumType>;
    lastName?: InputMaybe<SortEnumType>;
    livingAddress?: InputMaybe<SortEnumType>;
    livingCity?: InputMaybe<CitySortInput>;
    maritalStatus?: InputMaybe<SortEnumType>;
    passportIssueDate?: InputMaybe<SortEnumType>;
    passportIssuer?: InputMaybe<SortEnumType>;
    passportNumber?: InputMaybe<SortEnumType>;
    passportSeries?: InputMaybe<SortEnumType>;
    patronymic?: InputMaybe<SortEnumType>;
    phoneNumber?: InputMaybe<SortEnumType>;
    position?: InputMaybe<SortEnumType>;
    registrationAddress?: InputMaybe<SortEnumType>;
    registrationCity?: InputMaybe<CitySortInput>;
    salary?: InputMaybe<SortEnumType>;
    workPlace?: InputMaybe<SortEnumType>;
};

export type CreateClientInput = {
    birthDate: Scalars['DateTime']['input'];
    birthPlace: Scalars['String']['input'];
    citizenshipId: Scalars['Int']['input'];
    disabilityGroup: DisabilityGroup;
    email?: InputMaybe<Scalars['String']['input']>;
    firstName: Scalars['String']['input'];
    gender: GenderType;
    homePhoneNumber?: InputMaybe<Scalars['String']['input']>;
    identificationNumber: Scalars['String']['input'];
    isLiableForMilitaryService: Scalars['Boolean']['input'];
    isRetired: Scalars['Boolean']['input'];
    lastName: Scalars['String']['input'];
    livingAddress: Scalars['String']['input'];
    livingCityId: Scalars['Int']['input'];
    maritalStatus: MaritalStatus;
    passportIssueDate: Scalars['DateTime']['input'];
    passportIssuer: Scalars['String']['input'];
    passportNumber: Scalars['String']['input'];
    passportSeries: Scalars['String']['input'];
    patronymic: Scalars['String']['input'];
    phoneNumber?: InputMaybe<Scalars['String']['input']>;
    position?: InputMaybe<Scalars['String']['input']>;
    registrationAddress: Scalars['String']['input'];
    registrationCityId: Scalars['Int']['input'];
    salary?: InputMaybe<Scalars['Float']['input']>;
    workPlace?: InputMaybe<Scalars['String']['input']>;
};

export type CreateCreditContractInput = {
    amount: Scalars['Float']['input'];
    clientId: Scalars['UUID']['input'];
    creditId: Scalars['Int']['input'];
    number: Scalars['String']['input'];
};

export type CreateCreditInput = {
    currencyId: Scalars['Int']['input'];
    interest: Scalars['Float']['input'];
    isAnnuity: Scalars['Boolean']['input'];
    name: Scalars['String']['input'];
    period: Scalars['Int']['input'];
};

export type CreateDepositContractInput = {
    amount: Scalars['Float']['input'];
    clientId: Scalars['UUID']['input'];
    depositId: Scalars['Int']['input'];
    number: Scalars['String']['input'];
};

export type CreateDepositInput = {
    currencyId: Scalars['Int']['input'];
    interest: Scalars['Float']['input'];
    isRevocable: Scalars['Boolean']['input'];
    name: Scalars['String']['input'];
    period: Scalars['Int']['input'];
};

export type Credit = {
    __typename?: 'Credit';
    currency: Currency;
    id: Scalars['Int']['output'];
    interest: Scalars['Float']['output'];
    isAnnuity: Scalars['Boolean']['output'];
    name: Scalars['String']['output'];
    period: Scalars['Int']['output'];
};

export type CreditContract = {
    __typename?: 'CreditContract';
    amount: Scalars['Float']['output'];
    bankAccounts: Array<BankAccount>;
    client: Client;
    credit: Credit;
    dateBegin: Scalars['DateTime']['output'];
    dateEnd: Scalars['DateTime']['output'];
    daysToEnd: Scalars['Int']['output'];
    id: Scalars['Int']['output'];
    isActive: Scalars['Boolean']['output'];
    number: Scalars['String']['output'];
};

export type CreditContractFilterInput = {
    amount?: InputMaybe<FloatOperationFilterInput>;
    and?: InputMaybe<Array<CreditContractFilterInput>>;
    bankAccounts?: InputMaybe<ListFilterInputTypeOfBankAccountFilterInput>;
    client?: InputMaybe<ClientFilterInput>;
    credit?: InputMaybe<CreditFilterInput>;
    dateBegin?: InputMaybe<DateTimeOperationFilterInput>;
    dateEnd?: InputMaybe<DateTimeOperationFilterInput>;
    daysToEnd?: InputMaybe<IntOperationFilterInput>;
    id?: InputMaybe<IntOperationFilterInput>;
    isActive?: InputMaybe<BooleanOperationFilterInput>;
    number?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<CreditContractFilterInput>>;
};

export type CreditContractSortInput = {
    amount?: InputMaybe<SortEnumType>;
    client?: InputMaybe<ClientSortInput>;
    credit?: InputMaybe<CreditSortInput>;
    dateBegin?: InputMaybe<SortEnumType>;
    dateEnd?: InputMaybe<SortEnumType>;
    daysToEnd?: InputMaybe<SortEnumType>;
    id?: InputMaybe<SortEnumType>;
    isActive?: InputMaybe<SortEnumType>;
    number?: InputMaybe<SortEnumType>;
};

export type CreditFilterInput = {
    and?: InputMaybe<Array<CreditFilterInput>>;
    currency?: InputMaybe<CurrencyFilterInput>;
    id?: InputMaybe<IntOperationFilterInput>;
    interest?: InputMaybe<FloatOperationFilterInput>;
    isAnnuity?: InputMaybe<BooleanOperationFilterInput>;
    name?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<CreditFilterInput>>;
    period?: InputMaybe<IntOperationFilterInput>;
};

export type CreditSortInput = {
    currency?: InputMaybe<CurrencySortInput>;
    id?: InputMaybe<SortEnumType>;
    interest?: InputMaybe<SortEnumType>;
    isAnnuity?: InputMaybe<SortEnumType>;
    name?: InputMaybe<SortEnumType>;
    period?: InputMaybe<SortEnumType>;
};

export type Currency = {
    __typename?: 'Currency';
    id: Scalars['Int']['output'];
    name: Scalars['String']['output'];
};

export type CurrencyFilterInput = {
    and?: InputMaybe<Array<CurrencyFilterInput>>;
    id?: InputMaybe<IntOperationFilterInput>;
    name?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<CurrencyFilterInput>>;
};

export type CurrencySortInput = {
    id?: InputMaybe<SortEnumType>;
    name?: InputMaybe<SortEnumType>;
};

export type DateTimeOperationFilterInput = {
    eq?: InputMaybe<Scalars['DateTime']['input']>;
    gt?: InputMaybe<Scalars['DateTime']['input']>;
    gte?: InputMaybe<Scalars['DateTime']['input']>;
    in?: InputMaybe<Array<InputMaybe<Scalars['DateTime']['input']>>>;
    lt?: InputMaybe<Scalars['DateTime']['input']>;
    lte?: InputMaybe<Scalars['DateTime']['input']>;
    neq?: InputMaybe<Scalars['DateTime']['input']>;
    ngt?: InputMaybe<Scalars['DateTime']['input']>;
    ngte?: InputMaybe<Scalars['DateTime']['input']>;
    nin?: InputMaybe<Array<InputMaybe<Scalars['DateTime']['input']>>>;
    nlt?: InputMaybe<Scalars['DateTime']['input']>;
    nlte?: InputMaybe<Scalars['DateTime']['input']>;
};

export type Deposit = {
    __typename?: 'Deposit';
    currency: Currency;
    id: Scalars['Int']['output'];
    interest: Scalars['Float']['output'];
    isRevocable: Scalars['Boolean']['output'];
    name: Scalars['String']['output'];
    period: Scalars['Int']['output'];
};

export type DepositContract = {
    __typename?: 'DepositContract';
    amount: Scalars['Float']['output'];
    bankAccounts: Array<BankAccount>;
    client: Client;
    dateBegin: Scalars['DateTime']['output'];
    dateEnd: Scalars['DateTime']['output'];
    daysToEnd: Scalars['Int']['output'];
    deposit: Deposit;
    id: Scalars['Int']['output'];
    isActive: Scalars['Boolean']['output'];
    number: Scalars['String']['output'];
};

export type DepositContractFilterInput = {
    amount?: InputMaybe<FloatOperationFilterInput>;
    and?: InputMaybe<Array<DepositContractFilterInput>>;
    bankAccounts?: InputMaybe<ListFilterInputTypeOfBankAccountFilterInput>;
    client?: InputMaybe<ClientFilterInput>;
    dateBegin?: InputMaybe<DateTimeOperationFilterInput>;
    dateEnd?: InputMaybe<DateTimeOperationFilterInput>;
    daysToEnd?: InputMaybe<IntOperationFilterInput>;
    deposit?: InputMaybe<DepositFilterInput>;
    id?: InputMaybe<IntOperationFilterInput>;
    isActive?: InputMaybe<BooleanOperationFilterInput>;
    number?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<DepositContractFilterInput>>;
};

export type DepositContractSortInput = {
    amount?: InputMaybe<SortEnumType>;
    client?: InputMaybe<ClientSortInput>;
    dateBegin?: InputMaybe<SortEnumType>;
    dateEnd?: InputMaybe<SortEnumType>;
    daysToEnd?: InputMaybe<SortEnumType>;
    deposit?: InputMaybe<DepositSortInput>;
    id?: InputMaybe<SortEnumType>;
    isActive?: InputMaybe<SortEnumType>;
    number?: InputMaybe<SortEnumType>;
};

export type DepositFilterInput = {
    and?: InputMaybe<Array<DepositFilterInput>>;
    currency?: InputMaybe<CurrencyFilterInput>;
    id?: InputMaybe<IntOperationFilterInput>;
    interest?: InputMaybe<FloatOperationFilterInput>;
    isRevocable?: InputMaybe<BooleanOperationFilterInput>;
    name?: InputMaybe<StringOperationFilterInput>;
    or?: InputMaybe<Array<DepositFilterInput>>;
    period?: InputMaybe<IntOperationFilterInput>;
};

export type DepositSortInput = {
    currency?: InputMaybe<CurrencySortInput>;
    id?: InputMaybe<SortEnumType>;
    interest?: InputMaybe<SortEnumType>;
    isRevocable?: InputMaybe<SortEnumType>;
    name?: InputMaybe<SortEnumType>;
    period?: InputMaybe<SortEnumType>;
};

export enum DisabilityGroup {
    First = 'FIRST',
    None = 'NONE',
    Second = 'SECOND',
    Third = 'THIRD'
}

export type DisabilityGroupOperationFilterInput = {
    eq?: InputMaybe<DisabilityGroup>;
    in?: InputMaybe<Array<DisabilityGroup>>;
    neq?: InputMaybe<DisabilityGroup>;
    nin?: InputMaybe<Array<DisabilityGroup>>;
};

export type FloatOperationFilterInput = {
    eq?: InputMaybe<Scalars['Float']['input']>;
    gt?: InputMaybe<Scalars['Float']['input']>;
    gte?: InputMaybe<Scalars['Float']['input']>;
    in?: InputMaybe<Array<InputMaybe<Scalars['Float']['input']>>>;
    lt?: InputMaybe<Scalars['Float']['input']>;
    lte?: InputMaybe<Scalars['Float']['input']>;
    neq?: InputMaybe<Scalars['Float']['input']>;
    ngt?: InputMaybe<Scalars['Float']['input']>;
    ngte?: InputMaybe<Scalars['Float']['input']>;
    nin?: InputMaybe<Array<InputMaybe<Scalars['Float']['input']>>>;
    nlt?: InputMaybe<Scalars['Float']['input']>;
    nlte?: InputMaybe<Scalars['Float']['input']>;
};

export enum GenderType {
    Female = 'FEMALE',
    Male = 'MALE',
    Undefined = 'UNDEFINED'
}

export type GenderTypeOperationFilterInput = {
    eq?: InputMaybe<GenderType>;
    in?: InputMaybe<Array<GenderType>>;
    neq?: InputMaybe<GenderType>;
    nin?: InputMaybe<Array<GenderType>>;
};

export type IntOperationFilterInput = {
    eq?: InputMaybe<Scalars['Int']['input']>;
    gt?: InputMaybe<Scalars['Int']['input']>;
    gte?: InputMaybe<Scalars['Int']['input']>;
    in?: InputMaybe<Array<InputMaybe<Scalars['Int']['input']>>>;
    lt?: InputMaybe<Scalars['Int']['input']>;
    lte?: InputMaybe<Scalars['Int']['input']>;
    neq?: InputMaybe<Scalars['Int']['input']>;
    ngt?: InputMaybe<Scalars['Int']['input']>;
    ngte?: InputMaybe<Scalars['Int']['input']>;
    nin?: InputMaybe<Array<InputMaybe<Scalars['Int']['input']>>>;
    nlt?: InputMaybe<Scalars['Int']['input']>;
    nlte?: InputMaybe<Scalars['Int']['input']>;
};

export type ListFilterInputTypeOfBankAccountFilterInput = {
    all?: InputMaybe<BankAccountFilterInput>;
    any?: InputMaybe<Scalars['Boolean']['input']>;
    none?: InputMaybe<BankAccountFilterInput>;
    some?: InputMaybe<BankAccountFilterInput>;
};

export type ListFilterInputTypeOfCardDtoFilterInput = {
    all?: InputMaybe<CardDtoFilterInput>;
    any?: InputMaybe<Scalars['Boolean']['input']>;
    none?: InputMaybe<CardDtoFilterInput>;
    some?: InputMaybe<CardDtoFilterInput>;
};

export type ListFilterInputTypeOfCreditContractFilterInput = {
    all?: InputMaybe<CreditContractFilterInput>;
    any?: InputMaybe<Scalars['Boolean']['input']>;
    none?: InputMaybe<CreditContractFilterInput>;
    some?: InputMaybe<CreditContractFilterInput>;
};

export type ListFilterInputTypeOfDepositContractFilterInput = {
    all?: InputMaybe<DepositContractFilterInput>;
    any?: InputMaybe<Scalars['Boolean']['input']>;
    none?: InputMaybe<DepositContractFilterInput>;
    some?: InputMaybe<DepositContractFilterInput>;
};

export enum MaritalStatus {
    Divorced = 'DIVORCED',
    Married = 'MARRIED',
    Single = 'SINGLE',
    Widower = 'WIDOWER'
}

export type MaritalStatusOperationFilterInput = {
    eq?: InputMaybe<MaritalStatus>;
    in?: InputMaybe<Array<MaritalStatus>>;
    neq?: InputMaybe<MaritalStatus>;
    nin?: InputMaybe<Array<MaritalStatus>>;
};

export type Mutations = {
    __typename?: 'Mutations';
    cardInfo: CardInfoDto;
    closeBankDay: Scalars['Boolean']['output'];
    closeDepositContract: Scalars['Boolean']['output'];
    createClient: Client;
    createCredit: Credit;
    createCreditContract: CreditContract;
    createDeposit: Deposit;
    createDepositContract: DepositContract;
    deleteClient: Scalars['Boolean']['output'];
    deleteCredit: Scalars['Boolean']['output'];
    deleteDeposit: Scalars['Boolean']['output'];
    getCard: Scalars['Boolean']['output'];
    insertCard: Scalars['UUID']['output'];
    openCard: CardDto;
    putClient?: Maybe<Client>;
    puttingMoneyOnPhone: CardInfoDto;
    withdrawMoney: CardInfoDto;
};

export type MutationsCardInfoArgs = {
    token: Scalars['UUID']['input'];
};

export type MutationsCloseBankDayArgs = {
    days: Scalars['Int']['input'];
};

export type MutationsCloseDepositContractArgs = {
    id: Scalars['Int']['input'];
};

export type MutationsCreateClientArgs = {
    client: CreateClientInput;
};

export type MutationsCreateCreditArgs = {
    credit: CreateCreditInput;
};

export type MutationsCreateCreditContractArgs = {
    creditContract: CreateCreditContractInput;
};

export type MutationsCreateDepositArgs = {
    deposit: CreateDepositInput;
};

export type MutationsCreateDepositContractArgs = {
    depositContract: CreateDepositContractInput;
};

export type MutationsDeleteClientArgs = {
    id: Scalars['UUID']['input'];
};

export type MutationsDeleteCreditArgs = {
    id: Scalars['Int']['input'];
};

export type MutationsDeleteDepositArgs = {
    id: Scalars['Int']['input'];
};

export type MutationsGetCardArgs = {
    token: Scalars['UUID']['input'];
};

export type MutationsInsertCardArgs = {
    cardNumber: Scalars['String']['input'];
    pin: Scalars['Int']['input'];
};

export type MutationsOpenCardArgs = {
    bankAccountId: Scalars['UUID']['input'];
};

export type MutationsPutClientArgs = {
    client: UpdateClientInput;
};

export type MutationsPuttingMoneyOnPhoneArgs = {
    accountId: Scalars['UUID']['input'];
    amount: Scalars['Float']['input'];
    token: Scalars['UUID']['input'];
};

export type MutationsWithdrawMoneyArgs = {
    amount: Scalars['Float']['input'];
    token: Scalars['UUID']['input'];
};

export type Queries = {
    __typename?: 'Queries';
    bankAccounts: Array<BankAccount>;
    cards: Array<CardDto>;
    cities: Array<City>;
    citizenship: Array<Citizenship>;
    clients: Array<Client>;
    creditContracts: Array<CreditContract>;
    credits: Array<Credit>;
    currencies: Array<Currency>;
    depositContracts: Array<DepositContract>;
    deposits: Array<Deposit>;
    transitLogs: Array<TransitLog>;
};

export type QueriesBankAccountsArgs = {
    order?: InputMaybe<Array<BankAccountSortInput>>;
    where?: InputMaybe<BankAccountFilterInput>;
};

export type QueriesCardsArgs = {
    order?: InputMaybe<Array<CardDtoSortInput>>;
    where?: InputMaybe<CardDtoFilterInput>;
};

export type QueriesCitiesArgs = {
    order?: InputMaybe<Array<CitySortInput>>;
    where?: InputMaybe<CityFilterInput>;
};

export type QueriesCitizenshipArgs = {
    order?: InputMaybe<Array<CitizenshipSortInput>>;
    where?: InputMaybe<CitizenshipFilterInput>;
};

export type QueriesClientsArgs = {
    order?: InputMaybe<Array<ClientSortInput>>;
    where?: InputMaybe<ClientFilterInput>;
};

export type QueriesCreditContractsArgs = {
    order?: InputMaybe<Array<CreditContractSortInput>>;
    where?: InputMaybe<CreditContractFilterInput>;
};

export type QueriesCreditsArgs = {
    order?: InputMaybe<Array<CreditSortInput>>;
    where?: InputMaybe<CreditFilterInput>;
};

export type QueriesCurrenciesArgs = {
    order?: InputMaybe<Array<CurrencySortInput>>;
    where?: InputMaybe<CurrencyFilterInput>;
};

export type QueriesDepositContractsArgs = {
    order?: InputMaybe<Array<DepositContractSortInput>>;
    where?: InputMaybe<DepositContractFilterInput>;
};

export type QueriesDepositsArgs = {
    order?: InputMaybe<Array<DepositSortInput>>;
    where?: InputMaybe<DepositFilterInput>;
};

export type QueriesTransitLogsArgs = {
    order?: InputMaybe<Array<TransitLogSortInput>>;
    where?: InputMaybe<TransitLogFilterInput>;
};

export enum SortEnumType {
    Asc = 'ASC',
    Desc = 'DESC'
}

export type StringOperationFilterInput = {
    and?: InputMaybe<Array<StringOperationFilterInput>>;
    contains?: InputMaybe<Scalars['String']['input']>;
    endsWith?: InputMaybe<Scalars['String']['input']>;
    eq?: InputMaybe<Scalars['String']['input']>;
    in?: InputMaybe<Array<InputMaybe<Scalars['String']['input']>>>;
    ncontains?: InputMaybe<Scalars['String']['input']>;
    nendsWith?: InputMaybe<Scalars['String']['input']>;
    neq?: InputMaybe<Scalars['String']['input']>;
    nin?: InputMaybe<Array<InputMaybe<Scalars['String']['input']>>>;
    nstartsWith?: InputMaybe<Scalars['String']['input']>;
    or?: InputMaybe<Array<StringOperationFilterInput>>;
    startsWith?: InputMaybe<Scalars['String']['input']>;
};

export type TransitLog = {
    __typename?: 'TransitLog';
    amount: Scalars['Float']['output'];
    date: Scalars['DateTime']['output'];
    id: Scalars['UUID']['output'];
    source?: Maybe<BankAccount>;
    target?: Maybe<BankAccount>;
};

export type TransitLogFilterInput = {
    amount?: InputMaybe<FloatOperationFilterInput>;
    and?: InputMaybe<Array<TransitLogFilterInput>>;
    date?: InputMaybe<DateTimeOperationFilterInput>;
    id?: InputMaybe<UuidOperationFilterInput>;
    or?: InputMaybe<Array<TransitLogFilterInput>>;
    source?: InputMaybe<BankAccountFilterInput>;
    target?: InputMaybe<BankAccountFilterInput>;
};

export type TransitLogSortInput = {
    amount?: InputMaybe<SortEnumType>;
    date?: InputMaybe<SortEnumType>;
    id?: InputMaybe<SortEnumType>;
    source?: InputMaybe<BankAccountSortInput>;
    target?: InputMaybe<BankAccountSortInput>;
};

export enum TypeOfAccount {
    A1 = 'A1',
    Cash = 'CASH',
    Credit = 'CREDIT',
    CreditPercent = 'CREDIT_PERCENT',
    Deposit = 'DEPOSIT',
    DepositPercent = 'DEPOSIT_PERCENT',
    Main = 'MAIN',
    Mts = 'MTS'
}

export type TypeOfAccountOperationFilterInput = {
    eq?: InputMaybe<TypeOfAccount>;
    in?: InputMaybe<Array<TypeOfAccount>>;
    neq?: InputMaybe<TypeOfAccount>;
    nin?: InputMaybe<Array<TypeOfAccount>>;
};

export type UpdateClientInput = {
    birthDate: Scalars['DateTime']['input'];
    birthPlace: Scalars['String']['input'];
    citizenshipId: Scalars['Int']['input'];
    disabilityGroup: DisabilityGroup;
    email?: InputMaybe<Scalars['String']['input']>;
    firstName: Scalars['String']['input'];
    gender: GenderType;
    homePhoneNumber?: InputMaybe<Scalars['String']['input']>;
    id: Scalars['UUID']['input'];
    identificationNumber: Scalars['String']['input'];
    isLiableForMilitaryService: Scalars['Boolean']['input'];
    isRetired: Scalars['Boolean']['input'];
    lastName: Scalars['String']['input'];
    livingAddress: Scalars['String']['input'];
    livingCityId: Scalars['Int']['input'];
    maritalStatus: MaritalStatus;
    passportIssueDate: Scalars['DateTime']['input'];
    passportIssuer: Scalars['String']['input'];
    passportNumber: Scalars['String']['input'];
    passportSeries: Scalars['String']['input'];
    patronymic: Scalars['String']['input'];
    phoneNumber?: InputMaybe<Scalars['String']['input']>;
    position?: InputMaybe<Scalars['String']['input']>;
    registrationAddress: Scalars['String']['input'];
    registrationCityId: Scalars['Int']['input'];
    salary?: InputMaybe<Scalars['Float']['input']>;
    workPlace?: InputMaybe<Scalars['String']['input']>;
};

export type UuidOperationFilterInput = {
    eq?: InputMaybe<Scalars['UUID']['input']>;
    gt?: InputMaybe<Scalars['UUID']['input']>;
    gte?: InputMaybe<Scalars['UUID']['input']>;
    in?: InputMaybe<Array<InputMaybe<Scalars['UUID']['input']>>>;
    lt?: InputMaybe<Scalars['UUID']['input']>;
    lte?: InputMaybe<Scalars['UUID']['input']>;
    neq?: InputMaybe<Scalars['UUID']['input']>;
    ngt?: InputMaybe<Scalars['UUID']['input']>;
    ngte?: InputMaybe<Scalars['UUID']['input']>;
    nin?: InputMaybe<Array<InputMaybe<Scalars['UUID']['input']>>>;
    nlt?: InputMaybe<Scalars['UUID']['input']>;
    nlte?: InputMaybe<Scalars['UUID']['input']>;
};

export type CloseBankDayMutationVariables = Exact<{
    days: Scalars['Int']['input'];
}>;

export type CloseBankDayMutation = {
    __typename?: 'Mutations';
    closeBankDay: boolean;
};

export type GetAccountsQueryVariables = Exact<{ [key: string]: never }>;

export type GetAccountsQuery = {
    __typename?: 'Queries';
    bankAccounts: Array<{
        __typename?: 'BankAccount';
        id: any;
        amount: number;
        accountType: AccountType;
        typeOfAccount: TypeOfAccount;
        ibanNumber: string;
        debit: number;
        credit: number;
        currency: { __typename?: 'Currency'; id: number; name: string };
        depositContract?: {
            __typename?: 'DepositContract';
            number: string;
        } | null;
        creditContract?: {
            __typename?: 'CreditContract';
            number: string;
        } | null;
    }>;
};

export type OpenCardMutationVariables = Exact<{
    bankAccountId: Scalars['UUID']['input'];
}>;

export type OpenCardMutation = {
    __typename?: 'Mutations';
    openCard: {
        __typename?: 'CardDto';
        id: number;
        cardNumber: string;
        pin: number;
    };
};

export type GetCardsQueryVariables = Exact<{ [key: string]: never }>;

export type GetCardsQuery = {
    __typename?: 'Queries';
    cards: Array<{
        __typename?: 'CardDto';
        id: number;
        cardNumber: string;
        pin: number;
        bankAccount: { __typename?: 'BankAccount'; ibanNumber: string };
        client: {
            __typename?: 'Client';
            firstName: string;
            lastName: string;
            patronymic: string;
        };
    }>;
};

export type Get_CitizenshipQueryVariables = Exact<{ [key: string]: never }>;

export type Get_CitizenshipQuery = {
    __typename?: 'Queries';
    citizenship: Array<{
        __typename?: 'Citizenship';
        id: number;
        name: string;
    }>;
};

export type Get_CitiesQueryVariables = Exact<{ [key: string]: never }>;

export type Get_CitiesQuery = {
    __typename?: 'Queries';
    cities: Array<{ __typename?: 'City'; id: number; name: string }>;
};

export type Get_ClientsQueryVariables = Exact<{ [key: string]: never }>;

export type Get_ClientsQuery = {
    __typename?: 'Queries';
    clients: Array<{
        __typename?: 'Client';
        birthDate: any;
        birthPlace: string;
        disabilityGroup: DisabilityGroup;
        email?: string | null;
        firstName: string;
        gender: GenderType;
        homePhoneNumber?: string | null;
        id: any;
        identificationNumber: string;
        isLiableForMilitaryService: boolean;
        isRetired: boolean;
        lastName: string;
        livingAddress: string;
        maritalStatus: MaritalStatus;
        passportIssueDate: any;
        passportIssuer: string;
        passportNumber: string;
        passportSeries: string;
        patronymic: string;
        phoneNumber?: string | null;
        position?: string | null;
        registrationAddress: string;
        salary?: number | null;
        workPlace?: string | null;
        citizenship: { __typename?: 'Citizenship'; id: number; name: string };
        livingCity: { __typename?: 'City'; id: number; name: string };
        registrationCity: { __typename?: 'City'; id: number; name: string };
    }>;
};

export type CreateClientMutationVariables = Exact<{
    client: CreateClientInput;
}>;

export type CreateClientMutation = {
    __typename?: 'Mutations';
    createClient: { __typename?: 'Client'; id: any };
};

export type PutClientMutationVariables = Exact<{
    client: UpdateClientInput;
}>;

export type PutClientMutation = {
    __typename?: 'Mutations';
    putClient?: { __typename?: 'Client'; id: any } | null;
};

export type GetCreditPlansQueryVariables = Exact<{ [key: string]: never }>;

export type GetCreditPlansQuery = {
    __typename?: 'Queries';
    credits: Array<{
        __typename?: 'Credit';
        id: number;
        name: string;
        interest: number;
        isAnnuity: boolean;
        period: number;
        currency: { __typename?: 'Currency'; id: number; name: string };
    }>;
};

export type CreateCreditPlanMutationVariables = Exact<{
    credit: CreateCreditInput;
}>;

export type CreateCreditPlanMutation = {
    __typename?: 'Mutations';
    createCredit: { __typename?: 'Credit'; id: number };
};

export type GetActiveCreditsQueryVariables = Exact<{ [key: string]: never }>;

export type GetActiveCreditsQuery = {
    __typename?: 'Queries';
    creditContracts: Array<{
        __typename?: 'CreditContract';
        id: number;
        amount: number;
        number: string;
        credit: {
            __typename?: 'Credit';
            id: number;
            name: string;
            isAnnuity: boolean;
            period: number;
            interest: number;
            currency: { __typename?: 'Currency'; id: number; name: string };
        };
        client: {
            __typename?: 'Client';
            id: any;
            firstName: string;
            lastName: string;
            patronymic: string;
        };
    }>;
};

export type CreateCreditMutationVariables = Exact<{
    credit: CreateCreditContractInput;
}>;

export type CreateCreditMutation = {
    __typename?: 'Mutations';
    createCreditContract: { __typename?: 'CreditContract'; id: number };
};

export type GetCurrenciesQueryVariables = Exact<{ [key: string]: never }>;

export type GetCurrenciesQuery = {
    __typename?: 'Queries';
    currencies: Array<{ __typename?: 'Currency'; id: number; name: string }>;
};

export type GetDepositPlansQueryVariables = Exact<{ [key: string]: never }>;

export type GetDepositPlansQuery = {
    __typename?: 'Queries';
    deposits: Array<{
        __typename?: 'Deposit';
        id: number;
        name: string;
        interest: number;
        isRevocable: boolean;
        period: number;
        currency: { __typename?: 'Currency'; id: number; name: string };
    }>;
};

export type CreateDepositPlanMutationVariables = Exact<{
    deposit: CreateDepositInput;
}>;

export type CreateDepositPlanMutation = {
    __typename?: 'Mutations';
    createDeposit: { __typename?: 'Deposit'; id: number };
};

export type GetActiveDepositsQueryVariables = Exact<{ [key: string]: never }>;

export type GetActiveDepositsQuery = {
    __typename?: 'Queries';
    depositContracts: Array<{
        __typename?: 'DepositContract';
        id: number;
        amount: number;
        number: string;
        deposit: {
            __typename?: 'Deposit';
            id: number;
            name: string;
            isRevocable: boolean;
            currency: { __typename?: 'Currency'; id: number; name: string };
        };
        client: {
            __typename?: 'Client';
            id: any;
            firstName: string;
            lastName: string;
            patronymic: string;
        };
    }>;
};

export type CreateDepositMutationVariables = Exact<{
    deposit: CreateDepositContractInput;
}>;

export type CreateDepositMutation = {
    __typename?: 'Mutations';
    createDepositContract: { __typename?: 'DepositContract'; id: number };
};

export type WithdrawDepositMutationVariables = Exact<{
    id: Scalars['Int']['input'];
}>;

export type WithdrawDepositMutation = {
    __typename?: 'Mutations';
    closeDepositContract: boolean;
};

export type GetTransactionsQueryVariables = Exact<{ [key: string]: never }>;

export type GetTransactionsQuery = {
    __typename?: 'Queries';
    transitLogs: Array<{
        __typename?: 'TransitLog';
        id: any;
        amount: number;
        date: any;
        source?: {
            __typename?: 'BankAccount';
            typeOfAccount: TypeOfAccount;
            ibanNumber: string;
        } | null;
        target?: {
            __typename?: 'BankAccount';
            typeOfAccount: TypeOfAccount;
            ibanNumber: string;
        } | null;
    }>;
};

export interface PossibleTypesResultData {
    possibleTypes: {
        [key: string]: string[];
    };
}
const result: PossibleTypesResultData = {
    possibleTypes: {}
};
export default result;

export const CloseBankDayDocument = gql`
    mutation closeBankDay($days: Int!) {
        closeBankDay(days: $days)
    }
`;

@Injectable({
    providedIn: 'root'
})
export class CloseBankDayGQL extends Apollo.Mutation<
    CloseBankDayMutation,
    CloseBankDayMutationVariables
> {
    override document = CloseBankDayDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetAccountsDocument = gql`
    query getAccounts {
        bankAccounts {
            id
            amount
            accountType
            typeOfAccount
            ibanNumber
            debit
            credit
            currency {
                id
                name
            }
            depositContract {
                number
            }
            creditContract {
                number
            }
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetAccountsGQL extends Apollo.Query<
    GetAccountsQuery,
    GetAccountsQueryVariables
> {
    override document = GetAccountsDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const OpenCardDocument = gql`
    mutation openCard($bankAccountId: UUID!) {
        openCard(bankAccountId: $bankAccountId) {
            id
            cardNumber
            pin
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class OpenCardGQL extends Apollo.Mutation<
    OpenCardMutation,
    OpenCardMutationVariables
> {
    override document = OpenCardDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetCardsDocument = gql`
    query getCards {
        cards {
            id
            cardNumber
            bankAccount {
                ibanNumber
            }
            pin
            client {
                firstName
                lastName
                patronymic
            }
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetCardsGQL extends Apollo.Query<
    GetCardsQuery,
    GetCardsQueryVariables
> {
    override document = GetCardsDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const Get_CitizenshipDocument = gql`
    query GET_CITIZENSHIP {
        citizenship {
            id
            name
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class Get_CitizenshipGQL extends Apollo.Query<
    Get_CitizenshipQuery,
    Get_CitizenshipQueryVariables
> {
    override document = Get_CitizenshipDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const Get_CitiesDocument = gql`
    query GET_CITIES {
        cities {
            id
            name
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class Get_CitiesGQL extends Apollo.Query<
    Get_CitiesQuery,
    Get_CitiesQueryVariables
> {
    override document = Get_CitiesDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const Get_ClientsDocument = gql`
    query GET_CLIENTS {
        clients {
            birthDate
            birthPlace
            citizenship {
                id
                name
            }
            disabilityGroup
            email
            firstName
            gender
            homePhoneNumber
            id
            identificationNumber
            isLiableForMilitaryService
            isRetired
            lastName
            livingAddress
            livingCity {
                id
                name
            }
            maritalStatus
            passportIssueDate
            passportIssuer
            passportNumber
            passportSeries
            patronymic
            phoneNumber
            position
            registrationAddress
            registrationCity {
                id
                name
            }
            salary
            workPlace
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class Get_ClientsGQL extends Apollo.Query<
    Get_ClientsQuery,
    Get_ClientsQueryVariables
> {
    override document = Get_ClientsDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const CreateClientDocument = gql`
    mutation createClient($client: CreateClientInput!) {
        createClient(client: $client) {
            id
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class CreateClientGQL extends Apollo.Mutation<
    CreateClientMutation,
    CreateClientMutationVariables
> {
    override document = CreateClientDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const PutClientDocument = gql`
    mutation putClient($client: UpdateClientInput!) {
        putClient(client: $client) {
            id
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class PutClientGQL extends Apollo.Mutation<
    PutClientMutation,
    PutClientMutationVariables
> {
    override document = PutClientDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetCreditPlansDocument = gql`
    query getCreditPlans {
        credits {
            id
            name
            currency {
                id
                name
            }
            interest
            isAnnuity
            period
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetCreditPlansGQL extends Apollo.Query<
    GetCreditPlansQuery,
    GetCreditPlansQueryVariables
> {
    override document = GetCreditPlansDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const CreateCreditPlanDocument = gql`
    mutation createCreditPlan($credit: CreateCreditInput!) {
        createCredit(credit: $credit) {
            id
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class CreateCreditPlanGQL extends Apollo.Mutation<
    CreateCreditPlanMutation,
    CreateCreditPlanMutationVariables
> {
    override document = CreateCreditPlanDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetActiveCreditsDocument = gql`
    query getActiveCredits {
        creditContracts(where: { isActive: { eq: true } }) {
            id
            credit {
                id
                name
                currency {
                    id
                    name
                }
                isAnnuity
                period
                interest
            }
            amount
            number
            client {
                id
                firstName
                lastName
                patronymic
            }
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetActiveCreditsGQL extends Apollo.Query<
    GetActiveCreditsQuery,
    GetActiveCreditsQueryVariables
> {
    override document = GetActiveCreditsDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const CreateCreditDocument = gql`
    mutation createCredit($credit: CreateCreditContractInput!) {
        createCreditContract(creditContract: $credit) {
            id
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class CreateCreditGQL extends Apollo.Mutation<
    CreateCreditMutation,
    CreateCreditMutationVariables
> {
    override document = CreateCreditDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetCurrenciesDocument = gql`
    query getCurrencies {
        currencies {
            id
            name
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetCurrenciesGQL extends Apollo.Query<
    GetCurrenciesQuery,
    GetCurrenciesQueryVariables
> {
    override document = GetCurrenciesDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetDepositPlansDocument = gql`
    query getDepositPlans {
        deposits {
            id
            name
            currency {
                id
                name
            }
            interest
            isRevocable
            period
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetDepositPlansGQL extends Apollo.Query<
    GetDepositPlansQuery,
    GetDepositPlansQueryVariables
> {
    override document = GetDepositPlansDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const CreateDepositPlanDocument = gql`
    mutation createDepositPlan($deposit: CreateDepositInput!) {
        createDeposit(deposit: $deposit) {
            id
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class CreateDepositPlanGQL extends Apollo.Mutation<
    CreateDepositPlanMutation,
    CreateDepositPlanMutationVariables
> {
    override document = CreateDepositPlanDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetActiveDepositsDocument = gql`
    query getActiveDeposits {
        depositContracts(where: { isActive: { eq: true } }) {
            id
            deposit {
                id
                name
                currency {
                    id
                    name
                }
                isRevocable
            }
            amount
            number
            client {
                id
                firstName
                lastName
                patronymic
            }
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetActiveDepositsGQL extends Apollo.Query<
    GetActiveDepositsQuery,
    GetActiveDepositsQueryVariables
> {
    override document = GetActiveDepositsDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const CreateDepositDocument = gql`
    mutation createDEPOSIT($deposit: CreateDepositContractInput!) {
        createDepositContract(depositContract: $deposit) {
            id
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class CreateDepositGQL extends Apollo.Mutation<
    CreateDepositMutation,
    CreateDepositMutationVariables
> {
    override document = CreateDepositDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const WithdrawDepositDocument = gql`
    mutation withdrawDeposit($id: Int!) {
        closeDepositContract(id: $id)
    }
`;

@Injectable({
    providedIn: 'root'
})
export class WithdrawDepositGQL extends Apollo.Mutation<
    WithdrawDepositMutation,
    WithdrawDepositMutationVariables
> {
    override document = WithdrawDepositDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
export const GetTransactionsDocument = gql`
    query getTransactions {
        transitLogs {
            id
            amount
            date
            source {
                typeOfAccount
                ibanNumber
            }
            target {
                typeOfAccount
                ibanNumber
            }
        }
    }
`;

@Injectable({
    providedIn: 'root'
})
export class GetTransactionsGQL extends Apollo.Query<
    GetTransactionsQuery,
    GetTransactionsQueryVariables
> {
    override document = GetTransactionsDocument;

    constructor(apollo: Apollo.Apollo) {
        super(apollo);
    }
}
