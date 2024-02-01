import { inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { City } from '../models/city.model';
import { ApiService } from './api.service';

@Injectable({ providedIn: 'root' })
export class CitizenshipService {
    private readonly apiService = inject(ApiService);
    private _citizenship = new BehaviorSubject<City[]>([]);

    public readonly citizenship$ = this._citizenship.asObservable();

    public updateCities(): void {
        this.apiService.get<City[]>('/api/citizenship').subscribe(cities => {
            this._citizenship.next(cities);
        });
    }
}
