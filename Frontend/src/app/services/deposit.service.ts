import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import {
    CreateDepositContractInput,
    CreateDepositGQL,
    GetActiveDepositsGQL,
    GetActiveDepositsQuery
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';

@Injectable({
    providedIn: 'root'
})
export class DepositService {
    private readonly _getActiveDepositsGQL = inject(GetActiveDepositsGQL);
    private readonly _createDepositGQL = inject(CreateDepositGQL);

    private _activeDeposits = new BehaviorSubject<
        GetActiveDepositsQuery['depositContracts']
    >([]);

    public activeDeposits = this._activeDeposits.asObservable();

    updateActiveDeposits() {
        this._getActiveDepositsGQL
            .fetch()
            .subscribe(result =>
                this._activeDeposits.next(result.data.depositContracts)
            );
    }

    public createDeposit(deposit: CreateDepositContractInput) {
        return this._createDepositGQL.mutate({ deposit }).pipe(
            mapMutationResult(data => data?.createDepositContract.id),
            tap(() => this.updateActiveDeposits())
        );
    }
}
