import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import { GetTransactionsGQL } from '../../graphql';

@Injectable({
    providedIn: 'root'
})
export class TransactionService {
    private readonly _getTransactionsGQL = inject(GetTransactionsGQL);

    getTransactions() {
        return this._getTransactionsGQL
            .fetch()
            .pipe(map(result => result.data.transitLogs));
    }
}
