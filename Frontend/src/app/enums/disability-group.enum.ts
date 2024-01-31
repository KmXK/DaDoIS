export enum DisabilityGroup {
    None = 0,
    First = 1,
    Second = 2,
    Third = 3
}

export function getDisabilityGroupName(
    disabilityGroup: DisabilityGroup
): string {
    const map = {
        [DisabilityGroup.None]: 'Нет',
        [DisabilityGroup.First]: 'I',
        [DisabilityGroup.Second]: 'II',
        [DisabilityGroup.Third]: 'III'
    };

    return map[disabilityGroup];
}
