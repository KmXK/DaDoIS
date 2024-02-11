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
