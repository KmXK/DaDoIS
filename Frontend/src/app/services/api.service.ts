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

    public post<T>(url: string, body: unknown): Observable<T> {
        return this.httpClient.post<T>(url, body);
    }

    public delete(url: string): Observable<void> {
        return this.httpClient.delete(url) as unknown as Observable<void>;
    }

    public put<T>(url: string, data: T): Observable<T> {
        return this.httpClient.put<T>(url, data);
    }
}
