import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import {
    CardBalanceGQL,
    CardTransferGQL,
    CardWithdrawGQL,
    InsertCardGQL,
    TransferToMobileGQL
} from '../../../graphql';
import { mapMutationResult } from '../../shared/map-mutation-result.operator';
import { AtmStateEnum } from '../enums/atm-state.enum';
import { AtmState } from '../models/atm.state';

@Injectable({
    providedIn: 'root'
})
export class AtmService {
    private readonly insertCardGQL = inject(InsertCardGQL);
    private readonly cardBalanceGQL = inject(CardBalanceGQL);
    private readonly cardTransferGQL = inject(CardTransferGQL);
    private readonly withdrawGQL = inject(CardWithdrawGQL);
    private readonly mobileGQL = inject(TransferToMobileGQL);

    private readonly _state = new BehaviorSubject<AtmState>({
        state: AtmStateEnum.LOGGED_OUT
    });

    public state = this._state.asObservable();

    public startEnteringCard(): void {
        this._state.next({ state: AtmStateEnum.ENTERING_CARD });
    }

    public enterCard(value: {
        pin: number;
        cardNumber: string;
    }): Observable<void> {
        return this.insertCardGQL.mutate(value).pipe(
            mapMutationResult(data => data?.insertCard),
            tap((data: any) => {
                this._state.next({ state: AtmStateEnum.MENU, id: data });
            })
        );
    }

    public takeCard(): void {
        this._state.next({ state: AtmStateEnum.LOGGED_OUT });
    }

    public checkBalance(): void {
        if (this.data.state !== AtmStateEnum.MENU) {
            throw Error('Invalid action.');
        }

        this._state.next({
            state: AtmStateEnum.BALANCE,
            id: this.data.id
        });
    }

    public goToWithdraw(): void {
        if (this.data.state !== AtmStateEnum.MENU) {
            throw Error('Invalid action.');
        }

        this._state.next({
            state: AtmStateEnum.WITHDRAW,
            id: this.data.id
        });
    }

    public withdraw(amount: number) {
        if (this.data.state !== AtmStateEnum.WITHDRAW) {
            throw Error('Invalid action.');
        }

        return this.withdrawGQL
            .mutate({
                token: this.data.id,
                amount
            })
            .pipe(mapMutationResult(data => data?.withdrawMoney));
    }

    public goToMobile(): void {
        if (this.data.state !== AtmStateEnum.MENU) {
            throw Error('Invalid action.');
        }

        this._state.next({
            state: AtmStateEnum.MOBILE,
            id: this.data.id
        });
    }

    public transferMobile(value: {
        amount: number;
        phone: string;
        operatorId: string;
    }) {
        if (this.data.state !== AtmStateEnum.MOBILE) {
            throw Error('Invalid action.');
        }

        return this.mobileGQL
            .mutate({
                amount: value.amount,
                operatorId: value.operatorId,
                token: this.data.id
            })
            .pipe(mapMutationResult(data => data?.puttingMoneyOnPhone.amount));
    }

    private get data() {
        return this._state.value;
    }

    public loadBalance(): Observable<
        { amount: number; currency: string } | undefined
    > {
        if (
            this.data.state !== AtmStateEnum.BALANCE &&
            this.data.state !== AtmStateEnum.WITHDRAW &&
            this.data.state !== AtmStateEnum.MOBILE
        ) {
            throw Error('Invalid action.');
        }

        return this.cardBalanceGQL.mutate({ token: this.data.id }).pipe(
            mapMutationResult(data => {
                if (data) {
                    return {
                        amount: data.cardInfo.amount,
                        currency: data.cardInfo.card.bankAccount.currency.name
                    };
                }

                return undefined;
            })
        );
    }

    public backToMenu() {
        if (this.data.state < 2) throw Error('Invalid action.');

        this._state.next({
            state: AtmStateEnum.MENU,
            id: (this.data as any).id
        });
    }
}
