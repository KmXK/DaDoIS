import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import {
    CreateDepositInput,
    CreateDepositPlanGQL,
    GetDepositPlansGQL,
    GetDepositPlansQuery
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';

@Injectable({
    providedIn: 'root'
})
export class DepositPlanService {
    private readonly _getDepositPlansGQL = inject(GetDepositPlansGQL);
    private readonly _createDepositPlanGQL = inject(CreateDepositPlanGQL);

    private _plans = new BehaviorSubject<GetDepositPlansQuery['deposits']>([]);

    public plans = this._plans.asObservable();

    updatePlans() {
        this._getDepositPlansGQL
            .fetch()
            .subscribe(result => this._plans.next(result.data?.deposits));
    }

    createPlan(deposit: CreateDepositInput) {
        return this._createDepositPlanGQL.mutate({ deposit }).pipe(
            mapMutationResult(data => data?.createDeposit),
            tap(() => this.updatePlans())
        );
    }
}
