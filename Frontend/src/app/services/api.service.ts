import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private readonly httpClient = inject(HttpClient);

    public get<T>(url: string): Observable<T> {
        return this.httpClient.get<T>(url);
    }

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    public post<T>(url: string, body: any): Observable<T> {
        return this.httpClient.post<T>(url, body);
    }
}
