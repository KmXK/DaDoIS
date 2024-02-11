import { Component, inject, OnInit, signal } from '@angular/core';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { TextDialog } from '../../../../components/dialogs/text-dialog/text-dialog.component';
import { DialogService } from '../../../../services/dialog.service';
import { AtmService } from '../../../services/atm.service';

@Component({
    selector: 'app-atm-withdraw',
    standalone: true,
    imports: [
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        MatButton,
        ReactiveFormsModule,
        MatProgressSpinner
    ],
    templateUrl: './atm-withdraw.component.html',
    styleUrl: './atm-withdraw.component.scss'
})
export class AtmWithdraw implements OnInit {
    private readonly service = inject(AtmService);
    private readonly dialogService = inject(DialogService);
    public error = '';
    public readonly loading = signal(true);
    public currency = '';

    public readonly formGroup = new FormGroup({
        amount: new FormControl<number | undefined>(undefined, [
            Validators.required,
            Validators.min(0),
            Validators.pattern(/[0-9]{1,9}/)
        ])
    });

    ngOnInit(): void {
        this.service.loadBalance().subscribe({
            next: value => {
                if (value) {
                    this.currency = value.currency;
                } else {
                    this.error = 'Invalid currency';
                }
                this.loading.set(false);
            },
            error: error => {
                this.error = error.errorMessage;
                this.loading.set(false);
            }
        });
    }

    withdraw() {
        if (this.formGroup.invalid) {
            return;
        }

        this.error = '';

        const amount = +this.formGroup.value.amount!;

        this.service.withdraw(amount).subscribe({
            error: error => {
                this.error = error.errorMessage;
            },
            next: data => {
                this.dialogService.open(TextDialog, {
                    title: 'Успех',
                    text: `Вы успешно сняли ${amount} ${data?.card.bankAccount.currency.name}.
                    Остаток на балансе: ${data?.amount} ${data?.card.bankAccount.currency.name}`,
                    button: 'Вернуться в меню',
                    action: () => this.service.backToMenu()
                });
            }
        });
    }
}
