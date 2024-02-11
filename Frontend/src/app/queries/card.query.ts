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

export const INSERT_CARD = gql`
    mutation insertCard($cardNumber: String!, $pin: Int!) {
        insertCard(pin: $pin, cardNumber: $cardNumber)
    }
`;

export const CARD_BALANCE = gql`
    mutation cardBalance($token: UUID!) {
        cardInfo(token: $token) {
            amount
            card {
                bankAccount {
                    currency {
                        name
                    }
                }
            }
        }
    }
`;

export const CARD_TRANSFER = gql`
    mutation cardTransfer($token: UUID!) {
        cardInfo(token: $token) {
            transitLogs {
                date
                source {
                    ibanNumber
                }
                target {
                    ibanNumber
                }
                amount
            }
        }
    }
`;

export const CARD_WITHDRAW = gql`
    mutation cardWithdraw($token: UUID!, $amount: Float!) {
        withdrawMoney(token: $token, amount: $amount) {
            amount
            card {
                bankAccount {
                    currency {
                        name
                    }
                }
            }
        }
    }
`;

export const TransferToMobile = gql`
    mutation transferToMobile(
        $token: UUID!
        $amount: Float!
        $operatorId: UUID!
    ) {
        puttingMoneyOnPhone(
            amount: $amount
            accountId: $operatorId
            token: $token
        ) {
            amount
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
