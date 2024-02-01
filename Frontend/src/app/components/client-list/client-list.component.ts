import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatSort, MatSortHeader } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { Client } from '../../models/client.model';
import { ClientService } from '../../services/client.service';
import { DialogService } from '../../services/dialog.service';

@Component({
    standalone: true,
    selector: 'app-client-list',
    templateUrl: './client-list.component.html',
    styleUrl: './client-list.component.css',
    imports: [AsyncPipe, MatTableModule, MatSortHeader, MatSort, MatButton]
})
export class ClientListComponent {
    private readonly clientService = inject(ClientService);
    private readonly dialogService = inject(DialogService);

    public readonly clients = this.clientService.clients;
    public readonly displayedColumns = ['lastName', 'firstName', 'patronymic'];

    public clientClick(client: Client): void {
        this.dialogService.openClientDialog(client);
    }

    public createClient(): void {
        this.dialogService.openCreateClientDialog().subscribe(() => {
            this.clientService.updateClients();
        });
    }
}
