import { gql } from 'apollo-angular';

export const OPEN_CARD = gql`
    mutation openCard($bankAccountId: UUID!) {
        openCard(bankAccountId: $bankAccountId) {
            id
            cardNumber
            pin
        }
    }
`;

export const GET_CARDS = gql`
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
