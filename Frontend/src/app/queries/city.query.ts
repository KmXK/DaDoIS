import { gql } from 'apollo-angular';

export const GET_CITIES = gql`
    query GET_CITIES {
        cities {
            id
            name
        }
    }
`;
