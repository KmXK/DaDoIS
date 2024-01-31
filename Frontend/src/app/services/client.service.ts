import { Injectable, inject } from '@angular/core';
import { ApiService } from './api.service';
import { BehaviorSubject } from 'rxjs';
import { Client } from '../model/client.model';

@Injectable({
    providedIn: 'root'
})
export class ClientService {
    private readonly apiService = inject(ApiService);
    private _clients = new BehaviorSubject<Client[]>([]);

    public clients = this._clients.asObservable();

    public updateClients(): void {
        this.apiService
            .get<Client[]>('/api/clients')
            .subscribe(clients => {
                this._clients.next(clients);
            })
    }
}
