import { DisabilityGroup } from '../../graphql';

export function getDisabilityGroupName(disabilityGroup: DisabilityGroup) {
    const map = {
        [DisabilityGroup.None]: { text: 'Нет', order: 0 },
        [DisabilityGroup.First]: { text: 'I', order: 1 },
        [DisabilityGroup.Second]: { text: 'II', order: 2 },
        [DisabilityGroup.Third]: { text: 'III', order: 3 }
    };

    return map[disabilityGroup];
}
export { DisabilityGroup };
