import { inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { City } from '../models/city.model';
import { ApiService } from './api.service';

@Injectable({ providedIn: 'root' })
export class CityService {
    private readonly apiService = inject(ApiService);
    private _cities = new BehaviorSubject<City[]>([]);

    public readonly cities$ = this._cities.asObservable();

    public updateCities(): void {
        this.apiService.get<City[]>('/api/cities').subscribe(cities => {
            this._cities.next(cities);
        });
    }
}
