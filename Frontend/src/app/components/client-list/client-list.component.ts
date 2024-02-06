import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatSort, MatSortHeader, Sort } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { map } from 'rxjs';
import { Client } from '../../../graphql';
import { ClientService } from '../../services/client.service';
import { DialogService } from '../../services/dialog.service';

@Component({
    standalone: true,
    selector: 'app-client-list',
    templateUrl: './client-list.component.html',
    styleUrl: './client-list.component.scss',
    imports: [AsyncPipe, MatTableModule, MatSortHeader, MatSort, MatButton]
})
export class ClientListComponent {
    private readonly clientService = inject(ClientService);
    private readonly dialogService = inject(DialogService);

    public clients = this.clientService.clients;
    public readonly displayedColumns = [
        'lastName',
        'firstName',
        'patronymic',
        'actions'
    ];

    public clientClick(client: Client): void {
        this.dialogService.openClientDialog(client);
    }

    public createClient(): void {
        this.dialogService.openCreateClientDialog().subscribe(() => {
            this.clientService.updateClients();
        });
    }

    public delete(id: string, event: MouseEvent): void {
        this.clientService.delete(id).subscribe(() => {});
        event.stopPropagation();
    }

    public sortData(event: Sort): void {
        this.clients = this.clientService.clients.pipe(
            map(clients => {
                const [...copy] = clients;
                return copy.sort((a: any, b: any) => {
                    if (a[event.active] < b[event.active]) {
                        return event.direction === 'asc' ? -1 : 1;
                    }
                    if (a[event.active] > b[event.active]) {
                        return event.direction === 'asc' ? 1 : -1;
                    }
                    return 0;
                });
            })
        );
    }

    public edit(client: Client, event: MouseEvent): void {
        this.dialogService.openCreateClientDialog(client);
        event.stopPropagation();
    }
}
