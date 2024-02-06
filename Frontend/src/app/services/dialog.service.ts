import { inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Client } from '../../graphql';
import { ClientCreateDialog } from '../components/dialogs/client-create-dialog/client-create-dialog.component';
import { ClientViewDialog } from '../components/dialogs/client-view-dialog/client-view-dialog.component';
import { DepositPlanCreateDialog } from '../components/dialogs/dialog-plan-create-dialog/deposit-plan-create-dialog.component';

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

    public openCreateClientDialog(client?: Client): Observable<void> {
        const dialog = this.matDialog.open(ClientCreateDialog, {
            data: client
        });

        return dialog.afterOpened();
    }

    public openCreateDepositPlanDialog(): Observable<void> {
        const dialog = this.matDialog.open(DepositPlanCreateDialog);
        return dialog.afterOpened();
    }
}
