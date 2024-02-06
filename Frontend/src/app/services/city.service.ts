import { inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { City, Get_CitiesGQL } from '../../graphql';

@Injectable({ providedIn: 'root' })
export class CityService {
    private readonly _citiesGQL = inject(Get_CitiesGQL);
    private readonly _cities = new BehaviorSubject<City[]>([]);

    public readonly cities$ = this._cities.asObservable();

    public updateCities(): void {
        this._citiesGQL.fetch().subscribe(result => {
            this._cities.next(result.data.cities);
        });
    }
}
