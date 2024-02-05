export function getEnumMap(
    enumObj: unknown,
    nameFunc: (x: number) => string
): { name: string; value: number }[] {
    return Object.keys(enumObj as NonNullable<unknown>)
        .filter(x => Number.isInteger(+x))
        .map(x => ({
            name: nameFunc(+x),
            value: +x
        }));
}
