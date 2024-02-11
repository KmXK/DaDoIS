import { gql } from 'apollo-angular';

export const GET_CREDIT_PLANS = gql`
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

export const CREATE_CREDIT_PLAN = gql`
    mutation createCreditPlan($credit: CreateCreditInput!) {
        createCredit(credit: $credit) {
            id
        }
    }
`;

export const GET_ACTIVE_CREDITS = gql`
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

export const CREATE_CREDIT = gql`
    mutation createCredit($credit: CreateCreditContractInput!) {
        createCreditContract(creditContract: $credit) {
            id
        }
    }
`;
