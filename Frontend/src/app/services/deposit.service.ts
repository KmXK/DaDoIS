import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import {
    CreateDepositContractInput,
    CreateDepositGQL,
    GetActiveDepositsGQL
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';

@Injectable({
    providedIn: 'root'
})
export class DepositService {
    private readonly _getActiveDepositsGQL = inject(GetActiveDepositsGQL);
    private readonly _createDepositGQL = inject(CreateDepositGQL);

    getActiveDeposits() {
        return this._getActiveDepositsGQL
            .fetch()
            .pipe(map(result => result.data.depositContracts));
    }

    public createDeposit(deposit: CreateDepositContractInput) {
        return this._createDepositGQL
            .mutate({ deposit })
            .pipe(mapMutationResult(data => data?.createDepositContract.id));
    }
}
