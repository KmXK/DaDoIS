import { AsyncPipe } from '@angular/common';
import { ClientService } from './../../services/client.service';
import { Component, OnInit, inject } from '@angular/core';

@Component({
    standalone: true,
    selector: 'app-client-list',
    templateUrl: './client-list.component.html',
    styleUrl: './client-list.component.css',
    imports: [AsyncPipe]
})
export class ClientListComponent {
    private readonly clientService = inject(ClientService);

    public readonly clients = this.clientService.clients;
}
