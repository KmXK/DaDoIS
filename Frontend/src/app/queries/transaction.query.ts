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
            }
            target {
                typeOfAccount
                ibanNumber
            }
        }
    }
`;
