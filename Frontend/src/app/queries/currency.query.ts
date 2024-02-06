import { gql } from 'apollo-angular';

export const GET_CURRENCIES = gql`
    query getCurrencies {
        currencies {
            id
            name
        }
    }
`;
