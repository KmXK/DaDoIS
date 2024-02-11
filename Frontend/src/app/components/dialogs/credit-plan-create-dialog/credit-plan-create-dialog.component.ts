import { Component, inject, OnInit, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule } from '@angular/material/core';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CreateCreditInput } from '../../../../graphql';
import { CreditPlanService } from '../../../services/credit-plan.service';
import { CurrencyService } from '../../../services/currency.service';

@Component({
    selector: 'app-create-credit-plan-dialog',
    standalone: true,
    imports: [
        MatDialogModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatOptionModule,
        MatCheckboxModule
    ],
    templateUrl: './credit-plan-create-dialog.component.html',
    styleUrl: './credit-plan-create-dialog.component.scss'
})
export class CreditPlanCreateDialog implements OnInit {
    private readonly dialogRef = inject(MatDialogRef<CreditPlanCreateDialog>);
    private readonly currencyService = inject(CurrencyService);
    private readonly creditPlanService = inject(CreditPlanService);

    public readonly currencies = toSignal(this.currencyService.getCurrencies());

    public inProcess = signal(false);

    public readonly form = new FormGroup({
        name: new FormControl('', [Validators.required]),
        isAnnuity: new FormControl(false),
        currencyId: new FormControl<number>(null!, [Validators.required]),
        period: new FormControl<number>(30, [
            Validators.required,
            (control: any) =>
                control.value % 30 === 0 ? null : { invalid: true }
        ]),
        interest: new FormControl<number>(undefined!, [
            Validators.required,
            Validators.min(0),
            Validators.max(100)
        ])
    });

    public ngOnInit(): void {
        this.dialogRef.updateSize('600px');
    }

    public close(): void {
        this.dialogRef.close();
    }

    public create(): void {
        if (this.form.invalid) return;

        this.inProcess.set(true);

        const value = this.form.value as CreateCreditInput;

        this.creditPlanService
            .createPlan({ ...value, interest: value.interest / 100 })
            .subscribe({
                next: () => this.dialogRef.close(),
                error: error => this.showErrors(error)
            });
    }

    private showErrors(
        errors: { propertyName: string; errorMessage: string }[]
    ): void {
        const controlsMap: Record<string, keyof typeof this.form.controls> = {};

        if (Array.isArray(errors) && errors.length > 0) {
            const formErrors: Record<string, boolean> = {};

            for (const error of errors) {
                const propertyName = (error.propertyName[0].toLowerCase() +
                    error.propertyName.slice(
                        1
                    )) as keyof typeof this.form.controls;

                const controlName = controlsMap[propertyName] || propertyName;

                this.form.controls[controlName]?.setErrors({
                    serverError: true
                });
                formErrors[controlName] = true;
            }

            this.form.setErrors(formErrors);
            this.form.markAllAsTouched();
        }
    }
}
