import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import {
    CreateCreditContractInput,
    CreateCreditGQL,
    GetActiveCreditsGQL,
    GetActiveCreditsQuery
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';

@Injectable({
    providedIn: 'root'
})
export class CreditService {
    private readonly _getActiveCreditsGQL = inject(GetActiveCreditsGQL);
    private readonly _createCreditGQL = inject(CreateCreditGQL);

    private _activeDeposits = new BehaviorSubject<
        GetActiveCreditsQuery['creditContracts']
    >([]);

    public activeCredits = this._activeDeposits.asObservable();

    updateActiveCredits() {
        this._getActiveCreditsGQL
            .fetch()
            .subscribe(result =>
                this._activeDeposits.next(result.data.creditContracts)
            );
    }

    public createDeposit(credit: CreateCreditContractInput) {
        return this._createCreditGQL.mutate({ credit }).pipe(
            mapMutationResult(data => data?.createCreditContract.id),
            tap(() => this.updateActiveCredits())
        );
    }
}
