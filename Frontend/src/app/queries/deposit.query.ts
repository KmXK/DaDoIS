import { gql } from 'apollo-angular';

export const GET_DEPOSIT_PLANS = gql`
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

export const CREATE_DEPOSIT_PLAN = gql`
    mutation createDepositPlan($deposit: CreateDepositInput!) {
        createDeposit(deposit: $deposit) {
            id
        }
    }
`;
