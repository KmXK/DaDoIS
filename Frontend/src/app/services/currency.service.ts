import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import { GetCurrenciesGQL } from '../../graphql';

@Injectable({
    providedIn: 'root'
})
export class CurrencyService {
    private readonly _getCurrenciesGQL = inject(GetCurrenciesGQL);

    getCurrencies() {
        return this._getCurrenciesGQL.fetch().pipe(
            map(result => {
                return result.data.currencies;
            })
        );
    }
}
