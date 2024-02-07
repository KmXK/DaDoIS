import { DecimalPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { map } from 'rxjs';
import { AccountType } from '../../../graphql';
import { AccountService } from '../../services/account.service';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [MatTableModule, MatSortModule, MatButtonModule, DecimalPipe],
    templateUrl: './account-list.component.html',
    styleUrl: './account-list.component.scss'
})
export class AccountListComponent {
    private readonly accountService = inject(AccountService);

    public readonly displayedColumns = [
        'iban',
        'accountType',
        'debit',
        'credit',
        'amount',
        'contractNumber'
    ];

    public readonly deposits = this.accountService.getAccounts().pipe(
        map(accounts => {
            return [...accounts].sort(x =>
                ['MAIN', 'CASH'].some(y => y === x.typeOfAccount) ? -1 : 1
            );
        })
    );
    protected readonly AccountType = AccountType;
}
