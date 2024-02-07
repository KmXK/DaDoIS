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

export const GET_ACTIVE_DEPOSITS = gql`
    query getActiveDeposits {
        depositContracts(where: { isActive: { eq: true } }) {
            id
            deposit {
                id
                name
                currency {
                    id
                    name
                }
                isRevocable
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

export const CREATE_DEPOSIT = gql`
    mutation createDEPOSIT($deposit: CreateDepositContractInput!) {
        createDepositContract(depositContract: $deposit) {
            id
        }
    }
`;

export const WITHDRAW_DEPOSIT = gql`
    mutation withdrawDeposit($id: Int!) {
        closeDepositContract(id: $id)
    }
`;
