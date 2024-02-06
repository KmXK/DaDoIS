export function getEnumMap<T>(
    enumObj: unknown,
    nameFunc: (x: T) => { text: string; order: number }
): { name: string; value: T }[] {
    const a = Object.entries(enumObj as NonNullable<unknown>)
        .sort((a, b) => nameFunc(a[1] as T).order - nameFunc(b[1] as T).order)
        .map(([key, value]) => ({
            name: nameFunc(value as T).text,
            value: value as T
        }));
    return a;
}
