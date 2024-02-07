import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import { GetAccountsGQL } from '../../graphql';

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    private readonly _getAccountsGQL = inject(GetAccountsGQL);

    getAccounts() {
        return this._getAccountsGQL
            .fetch()
            .pipe(map(result => result.data.bankAccounts));
    }
}
