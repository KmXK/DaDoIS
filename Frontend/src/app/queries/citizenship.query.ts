import { gql } from 'apollo-angular';

export const GET_CITIZENSHIP = gql`
    query GET_CITIZENSHIP {
        citizenship {
            id
            name
        }
    }
`;
