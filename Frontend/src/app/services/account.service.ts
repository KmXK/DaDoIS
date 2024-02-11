import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import {
    GetAccountsFilterGQL,
    GetAccountsGQL,
    TypeOfAccount
} from '../../graphql';

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    private readonly _getAccountsGQL = inject(GetAccountsGQL);
    private readonly _getAccountsFilterGQL = inject(GetAccountsFilterGQL);

    getAccounts() {
        return this._getAccountsGQL
            .fetch()
            .pipe(map(result => result.data.bankAccounts));
    }

    getAccountsByType(types: TypeOfAccount[]) {
        return this._getAccountsFilterGQL
            .fetch({ type: types })
            .pipe(map(result => result.data.bankAccounts));
    }
}
