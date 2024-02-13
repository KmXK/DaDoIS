import { DatePipe, DecimalPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { map } from 'rxjs';
import { AccountType, TypeOfAccount } from '../../../graphql';
import { TransactionService } from '../../services/transaction.service';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [
        MatTableModule,
        MatSortModule,
        MatButtonModule,
        DecimalPipe,
        DatePipe,
        MatIcon
    ],
    templateUrl: './transaction-list.component.html',
    styleUrl: './transaction-list.component.scss'
})
export class TransactionListComponent {
    private readonly transactionService = inject(TransactionService);

    public readonly displayedColumns = [
        'source',
        'arrow',
        'target',
        'amount',
        'date'
    ];

    public readonly transactions = this.transactionService
        .getTransactions()
        .pipe(
            map(transactions =>
                [...transactions].sort((a, b) => {
                    return Date.parse(b.date) - Date.parse(a.date);
                })
            )
        );

    public getClientFullName(client: {
        patronymic: string;
        firstName: string;
        lastName: string;
    }): string {
        return `${client.firstName} ${client.lastName} ${client.patronymic}`;
    }

    public isMobileOperator(element: {
        typeOfAccount: TypeOfAccount;
    }): boolean {
        return [TypeOfAccount.A1, TypeOfAccount.Mts].includes(
            element.typeOfAccount
        );
    }

    protected readonly AccountType = AccountType;
    protected readonly TypeOfAccount = TypeOfAccount;
}
