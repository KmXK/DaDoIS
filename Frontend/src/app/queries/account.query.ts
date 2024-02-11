import { gql } from 'apollo-angular';

export const GET_ACCOUNTS = gql`
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

export const GET_ACCOUNTS_FILTER = gql`
    query getAccountsFilter($type: [TypeOfAccount!]!) {
        bankAccounts(where: { typeOfAccount: { in: $type } }) {
            id
            ibanNumber
            typeOfAccount
        }
    }
`;
