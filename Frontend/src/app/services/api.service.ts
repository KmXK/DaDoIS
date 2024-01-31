import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private readonly httpClient = inject(HttpClient);

    public get<T>(url: string): Observable<T> {
        return this.httpClient.get<T>(url);
    }
}
