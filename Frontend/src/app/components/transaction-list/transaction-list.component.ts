import { DatePipe, DecimalPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { map } from 'rxjs';
import { AccountType } from '../../../graphql';
import { TransactionService } from '../../services/transaction.service';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [
        MatTableModule,
        MatSortModule,
        MatButtonModule,
        DecimalPipe,
        DatePipe
    ],
    templateUrl: './transaction-list.component.html',
    styleUrl: './transaction-list.component.scss'
})
export class TransactionListComponent {
    private readonly transactionService = inject(TransactionService);

    public readonly displayedColumns = ['source', 'target', 'amount', 'date'];

    public readonly transactions = this.transactionService
        .getTransactions()
        .pipe(
            map(transactions =>
                [...transactions].sort((a, b) => a.date - b.date)
            )
        );

    protected readonly AccountType = AccountType;
}
