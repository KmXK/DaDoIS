import { Component, inject, OnInit, signal } from '@angular/core';
import {
    FormControl,
    FormGroup,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { MatSelect } from '@angular/material/select';
import { TypeOfAccount } from '../../../../../graphql';
import { TextDialog } from '../../../../components/dialogs/text-dialog/text-dialog.component';
import { AccountService } from '../../../../services/account.service';
import { DialogService } from '../../../../services/dialog.service';
import { AtmService } from '../../../services/atm.service';

@Component({
    selector: 'app-atm-mobile',
    standalone: true,
    imports: [
        MatProgressSpinner,
        MatButton,
        ReactiveFormsModule,
        MatFormField,
        MatInput,
        MatSelect,
        MatOptionModule,
        MatLabel
    ],
    templateUrl: './atm-mobile.component.html',
    styleUrl: './atm-mobile.component.scss'
})
export class AtmMobileComponent implements OnInit {
    private readonly service = inject(AtmService);
    private readonly accountService = inject(AccountService);
    private readonly dialogService = inject(DialogService);

    public readonly loading = signal(2);
    public currency = '';
    public error = '';

    public accountsIds: Record<TypeOfAccount, string> = undefined!;

    public readonly formGroup = new FormGroup({
        phoneNumber: new FormControl('', [
            Validators.required,
            Validators.pattern(/\+?[0-9]{12}/)
        ]),
        operator: new FormControl<TypeOfAccount.A1 | TypeOfAccount.Mts>(
            undefined!,
            [Validators.required]
        ),
        amount: new FormControl<number>(undefined!, [
            Validators.required,
            Validators.pattern(/^[0-9]+(\.[0-9]{1,2})?$/)
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
                this.loading.update(l => l - 1);
            },
            error: error => {
                this.error = error.errorMessage;
                this.loading.update(l => l - 1);
            }
        });

        this.accountService
            .getAccountsByType([TypeOfAccount.Mts, TypeOfAccount.A1])
            .subscribe(accounts => {
                this.accountsIds = accounts.reduce(
                    (acc, account) => ({
                        ...acc,
                        [account.typeOfAccount]: account.id
                    }),
                    {} as Record<TypeOfAccount, string>
                );

                this.loading.update(l => l - 1);
            });

        this.formGroup.valueChanges.subscribe(() => (this.error = ''));
    }

    exit() {
        this.service.backToMenu();
    }

    public action(): void {
        if (this.formGroup.invalid) {
            return;
        }

        const value = {
            amount: +this.formGroup.value.amount!,
            phone: this.formGroup.value.phoneNumber!,
            operatorId: this.accountsIds[this.formGroup.value.operator!]!
        };

        this.service.transferMobile(value).subscribe({
            error: error => {
                this.error = error.errorMessage;
            },
            next: () =>
                this.dialogService.open(TextDialog, {
                    text: `Указанный номер мобильного телефона был пополнен на ${value.amount} ${this.currency}.`,
                    title: 'Успех',
                    button: 'Вернуться в меню',
                    action: () => this.service.backToMenu()
                })
        });
    }
}
