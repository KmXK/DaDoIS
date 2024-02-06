import { GenderType } from '../../graphql';

export function getGenderName(gender: GenderType) {
    const map = {
        [GenderType.Undefined]: { text: 'Неизвестно', order: 0 },
        [GenderType.Male]: { text: 'Мужской', order: 1 },
        [GenderType.Female]: { text: 'Женский', order: 2 }
    };

    return map[gender];
}
