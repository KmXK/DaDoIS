import { inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Client } from '../models/client.model';
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
}
