import { DateFilterFn } from '@angular/material/datepicker';

export function maxDateFilter(max: Date | number): DateFilterFn<Date | null> {
    return function (d: Date | null) {
        return !d || d <= max;
    };
}
