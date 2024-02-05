export enum MaritalStatus {
    Single = 0,
    Married = 1,
    Divorced = 2,
    Widowed = 3
}

export function getMaritalStatusName(maritalStatus: MaritalStatus): string {
    const map = {
        [MaritalStatus.Single]: 'Холост/Не замужем',
        [MaritalStatus.Married]: 'Женат/Замужем',
        [MaritalStatus.Divorced]: 'Разведён/Разведена',
        [MaritalStatus.Widowed]: 'Вдовец/Вдова'
    };

    return map[maritalStatus];
}
