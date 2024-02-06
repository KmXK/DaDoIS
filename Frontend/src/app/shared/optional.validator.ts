import {
    AbstractControl,
    ValidationErrors,
    ValidatorFn,
    Validators
} from '@angular/forms';
import { Optional } from './types';

function hasValue(value: unknown): boolean {
    return value !== null && value !== undefined;
}

export function optionalValidator(
    validators?: Optional<ValidatorFn>[]
): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        if (hasValue(control.value) && validators) {
            return Validators.compose(validators)?.(control) ?? null;
        }
        return null;
    };
}
