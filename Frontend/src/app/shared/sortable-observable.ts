import { Sort } from '@angular/material/sort';
import { map, Observable } from 'rxjs';

export class SortableObservable<T> {
    private sortedObservable: Observable<T[]>;

    constructor(private readonly observable: Observable<T[]>) {
        this.sortedObservable = observable;
    }

    public get(): Observable<T[]> {
        return this.sortedObservable;
    }

    sort(sortOptions: Sort) {
        const compareFn = (a: any, b: any) => {
            if (a[sortOptions.active] < b[sortOptions.active]) {
                return sortOptions.direction === 'asc' ? -1 : 1;
            }
            if (a[sortOptions.active] > b[sortOptions.active]) {
                return sortOptions.direction === 'asc' ? 1 : -1;
            }
            return 0;
        };
        this.sortedObservable = this.observable.pipe(
            map((values: T[]) => {
                const [...items] = values;
                return items.sort(compareFn);
            })
        );
    }
}
