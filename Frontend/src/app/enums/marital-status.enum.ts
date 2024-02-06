import { MaritalStatus } from '../../graphql';

export function getMaritalStatusName(maritalStatus: MaritalStatus): {
    text: string;
    order: number;
} {
    const map = {
        [MaritalStatus.Single]: { text: 'Холост/Не замужем', order: 0 },
        [MaritalStatus.Married]: { text: 'Женат/Замужем', order: 1 },
        [MaritalStatus.Divorced]: { text: 'Разведён/Разведена', order: 2 },
        [MaritalStatus.Widower]: { text: 'Вдовец/Вдова', order: 3 }
    };

    return map[maritalStatus];
}
export { MaritalStatus };
