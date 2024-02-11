import { Component, inject, OnInit, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import {
    AbstractControl,
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
import { CreateCreditContractInput } from '../../../../graphql';
import { ClientService } from '../../../services/client.service';
import { CreditPlanService } from '../../../services/credit-plan.service';
import { CreditService } from '../../../services/credit.service';

@Component({
    selector: 'app-create-credit-dialog',
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
    templateUrl: './credit-create-dialog.component.html',
    styleUrl: './credit-create-dialog.component.scss'
})
export class CreditCreateDialog implements OnInit {
    private readonly dialogRef = inject(MatDialogRef<CreditCreateDialog>);
    private readonly clientService = inject(ClientService);
    private readonly creditPlanService = inject(CreditPlanService);
    private readonly creditService = inject(CreditService);

    public readonly clients = toSignal(this.clientService.clients);
    public readonly plans = toSignal(this.creditPlanService.plans);

    public inProcess = signal(false);

    public readonly form = new FormGroup({
        number: new FormControl('', [Validators.required]),
        clientId: new FormControl<string>(null!, [Validators.required]),
        plan: new FormControl<
            NonNullable<ReturnType<typeof this.plans>>[number]
        >(null!, [Validators.required]),
        amount: new FormControl<number>(0, [
            Validators.required,
            Validators.min(1)
        ])
    });
    public selectedPlan: any;

    public ngOnInit(): void {
        this.dialogRef.updateSize('600px');

        this.creditPlanService.updatePlans();
        this.clientService.updateClients();

        for (const controlsKey in this.form.controls) {
            const control: AbstractControl =
                this.form.controls[
                    controlsKey as keyof typeof this.form.controls
                ];

            control.valueChanges.subscribe(() => {
                control.setErrors(null);
                console.log(this.form.errors);
            });
        }
    }

    public close(): void {
        this.dialogRef.close();
    }

    public create(): void {
        if (this.form.invalid) return;

        this.inProcess.set(true);

        const value = this.form.value;

        const credit: CreateCreditContractInput = {
            number: value.number!,
            clientId: value.clientId!,
            creditId: value.plan!.id,
            amount: value.amount!
        };

        this.creditService.createCredit(credit).subscribe({
            next: () => this.dialogRef.close(),
            error: error => this.showErrors(error)
        });
    }

    private showErrors(
        errors: { propertyName: string; errorMessage: string }[]
    ): void {
        const controlsMap: Record<string, keyof typeof this.form.controls> = {
            depositId: 'plan'
        };

        this.inProcess.set(false);

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
