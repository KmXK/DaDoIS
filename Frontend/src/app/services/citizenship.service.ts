import { inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Citizenship, Get_CitizenshipGQL } from '../../graphql';

@Injectable({ providedIn: 'root' })
export class CitizenshipService {
    private readonly _citizenshipGQL = inject(Get_CitizenshipGQL);
    private readonly _citizenship = new BehaviorSubject<Citizenship[]>([]);

    public readonly citizenship$ = this._citizenship.asObservable();

    public updateCities(): void {
        this._citizenshipGQL.fetch().subscribe(result => {
            this._citizenship.next(result.data.citizenship);
        });
    }
}
