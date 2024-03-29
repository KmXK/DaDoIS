import { inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ClientCreateDialog } from '../components/dialogs/client-create-dialog/client-create-dialog.component';
import { ClientViewDialog } from '../components/dialogs/client-view-dialog/client-view-dialog.component';
import { Client } from '../models/client.model';

@Injectable({
    providedIn: 'root'
})
export class DialogService {
    private readonly matDialog = inject(MatDialog);

    public openClientDialog(client: Client): Observable<void> {
        const dialog = this.matDialog.open(ClientViewDialog, {
            data: client
        });

        return dialog.afterOpened();
    }

    public openCreateClientDialog(): Observable<void> {
        const dialog = this.matDialog.open(ClientCreateDialog, {
            data: null
        });

        return dialog.afterOpened();
    }
}
