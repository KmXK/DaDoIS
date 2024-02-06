import { inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import {
    CreateDepositInput,
    CreateDepositPlanGQL,
    GetDepositPlansGQL
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';

@Injectable({
    providedIn: 'root'
})
export class DepositPlanService {
    private readonly _getDepositPlansGQL = inject(GetDepositPlansGQL);
    private readonly _createDepositPlanGQL = inject(CreateDepositPlanGQL);

    getPlans() {
        return this._getDepositPlansGQL.fetch().pipe(
            map(result => {
                return result.data.deposits;
            })
        );
    }

    createPlan(deposit: CreateDepositInput) {
        return this._createDepositPlanGQL
            .mutate({ deposit })
            .pipe(mapMutationResult(data => data?.createDeposit));
    }
}
