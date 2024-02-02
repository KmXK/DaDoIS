import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Client } from '../models/client.model';
import { CreateClientModel } from '../models/crud/create-client.model';
import { ApiService } from './api.service';

@Injectable({
    providedIn: 'root'
})
export class ClientService {
    private readonly apiService = inject(ApiService);
    private _clients = new BehaviorSubject<Client[]>([]);

    public clients = this._clients.asObservable();

    public updateClients(): void {
        this.apiService.get<Client[]>('/api/clients').subscribe(clients => {
            this._clients.next(clients);
        });
    }

    public createClient(client: CreateClientModel): Observable<void> {
        return this.apiService
            .post<void>('/api/clients', client)
            .pipe(tap(() => this.updateClients()));
    }

    public delete(id: string): Observable<void> {
        return this.apiService
            .delete(`/api/clients/${id}`)
            .pipe(tap(() => this.updateClients()));
    }

    public edit(
        id: string,
        client: CreateClientModel
    ): Observable<CreateClientModel> {
        return this.apiService
            .put(`/api/clients`, { ...client, id })
            .pipe(tap(() => this.updateClients()));
    }
}
