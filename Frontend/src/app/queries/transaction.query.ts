import { gql } from 'apollo-angular';

export const GET_TRANSACTIONS = gql`
    query getTransactions {
        transitLogs {
            id
            amount
            date
            source {
                typeOfAccount
                ibanNumber
                depositContract {
                    client {
                        firstName
                        lastName
                        patronymic
                    }
                }
                creditContract {
                    client {
                        firstName
                        lastName
                        patronymic
                    }
                }
            }
            target {
                typeOfAccount
                ibanNumber
                depositContract {
                    client {
                        firstName
                        lastName
                        patronymic
                    }
                }
                creditContract {
                    client {
                        firstName
                        lastName
                        patronymic
                    }
                }
            }
        }
    }
`;
