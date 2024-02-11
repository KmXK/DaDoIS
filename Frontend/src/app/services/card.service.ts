import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { GetCardsGQL, GetCardsQuery, OpenCardGQL } from '../../graphql';

@Injectable({
    providedIn: 'root'
})
export class CardService {
    private readonly _getCardsGQL = inject(GetCardsGQL);
    private readonly _openCardGQL = inject(OpenCardGQL);

    private _cards = new BehaviorSubject<GetCardsQuery['cards']>([]);

    public cards = this._cards.asObservable();

    updateCards() {
        this._getCardsGQL
            .fetch()
            .subscribe(result => this._cards.next(result.data.cards));
    }

    public createCard(bankAccountId: string): Observable<number | undefined> {
        return this._openCardGQL
            .mutate({ bankAccountId })
            .pipe(map(result => result.data?.openCard.id));
    }
}
