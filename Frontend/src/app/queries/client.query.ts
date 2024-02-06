import { gql } from 'apollo-angular';

export const GET_CLIENTS = gql`
    query GET_CLIENTS {
        clients {
            birthDate
            birthPlace
            citizenship {
                id
                name
            }
            disabilityGroup
            email
            firstName
            gender
            homePhoneNumber
            id
            identificationNumber
            isLiableForMilitaryService
            isRetired
            lastName
            livingAddress
            livingCity {
                id
                name
            }
            maritalStatus
            passportIssueDate
            passportIssuer
            passportNumber
            passportSeries
            patronymic
            phoneNumber
            position
            registrationAddress
            registrationCity {
                id
                name
            }
            salary
            workPlace
        }
    }
`;

export const CREATE_CLIENT = gql`
    mutation createClient($client: CreateClientInput!) {
        createClient(client: $client) {
            id
        }
    }
`;

export const PUT_CLIENT = gql`
    mutation putClient($client: UpdateClientInput!) {
        putClient(client: $client) {
            id
        }
    }
`;
