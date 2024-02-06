import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, tap } from 'rxjs';
import {
    Client,
    CreateClientGQL,
    CreateClientInput,
    Get_ClientsGQL,
    PutClientGQL,
    PutClientMutation
} from '../../graphql';
import { mapMutationResult } from '../shared/map-mutation-result.operator';
import { Optional } from '../shared/types';

@Injectable({
    providedIn: 'root'
})
export class ClientService {
    private readonly _createClientGQL = inject(CreateClientGQL);
    private readonly _putClientGQL = inject(PutClientGQL);
    private readonly _getClientGQL = inject(Get_ClientsGQL);
    private _clients = new BehaviorSubject<Client[]>([]);

    public clients = this._clients.asObservable();

    public createClient(client: CreateClientInput): Observable<string | null> {
        return this._createClientGQL
            .mutate({
                client
            })
            .pipe(
                mapMutationResult(data => data?.createClient.id),
                tap(() => {
                    this.updateClients();
                })
            );
    }

    public updateClients(): void {
        this._getClientGQL.fetch().subscribe(result => {
            this._clients.next(result.data.clients);
        });
    }

    public delete(id: string): Observable<void> {
        return of();
        // return this.apiService
        //     .delete(`/api/clients/${id}`)
        //     .pipe(tap(() => this.updateClients()));
    }

    public edit(
        id: string,
        client: CreateClientInput
    ): Observable<Optional<PutClientMutation>> {
        return this._putClientGQL.mutate({ client: { ...client, id } }).pipe(
            mapMutationResult(data => data),
            tap(() => this.updateClients())
        );
        // return this.apiService
        //     .put(`/api/clients`, { ...client, id })
        //     .pipe(tap(() => this.updateClients()));
    }
}
