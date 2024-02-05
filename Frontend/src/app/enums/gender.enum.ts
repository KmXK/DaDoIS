export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export function getGenderName(gender: Gender): string {
    console.log(typeof gender);

    const map = {
        [Gender.Undefined]: 'Неизвестно',
        [Gender.Male]: 'Мужской',
        [Gender.Female]: 'Женский'
    };

    return map[gender];
}
