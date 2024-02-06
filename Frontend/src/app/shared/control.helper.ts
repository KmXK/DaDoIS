import { AbstractControl } from '@angular/forms';

export function removeError(control: AbstractControl, errorName: string): void {
    if (control.errors === null) return;

    const errorCount = Object.keys(control.errors).length;

    if (errorCount === 1 && control.hasError(errorName)) {
        control.setErrors(null);
        return;
    }

    if (control.hasError(errorName)) {
        const { ...errors } = control.errors;
        delete errors[errorName];
        control.setErrors(errors);
    }
}
