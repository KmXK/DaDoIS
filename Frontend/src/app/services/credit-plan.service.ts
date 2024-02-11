import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import {
    CreateCreditInput,
    CreateCreditPlanGQL,
    GetCreditPlansGQL,
    GetCreditPlansQuery
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';

@Injectable({
    providedIn: 'root'
})
export class CreditPlanService {
    private readonly _getCreditPlansGQL = inject(GetCreditPlansGQL);
    private readonly _createCreditPlanGQL = inject(CreateCreditPlanGQL);

    private _plans = new BehaviorSubject<GetCreditPlansQuery['credits']>([]);

    public plans = this._plans.asObservable();

    updatePlans() {
        this._getCreditPlansGQL
            .fetch()
            .subscribe(result => this._plans.next(result.data?.credits));
    }

    createPlan(credit: CreateCreditInput) {
        return this._createCreditPlanGQL.mutate({ credit }).pipe(
            mapMutationResult(data => data?.createCredit),
            tap(() => this.updatePlans())
        );
    }
}
