import { gql } from 'apollo-angular';

export const CLOSE_BANK_BY_DAYS = gql`
    mutation closeBankDay($days: Int!) {
        closeBankDay(days: $days)
    }
`;
