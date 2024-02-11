import { ComponentType } from '@angular/cdk/overlay';
import { inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Client } from '../../graphql';
import { ClientCreateDialog } from '../components/dialogs/client-create-dialog/client-create-dialog.component';
import { ClientViewDialog } from '../components/dialogs/client-view-dialog/client-view-dialog.component';
import { DepositCreateDialog } from '../components/dialogs/deposit-create-dialog/deposit-create-dialog.component';
import { DepositPlanCreateDialog } from '../components/dialogs/deposit-plan-create-dialog/deposit-plan-create-dialog.component';

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

    public openCreateDepositDialog(): Observable<void> {
        const dialog = this.matDialog.open(DepositCreateDialog);
        return dialog.afterOpened();
    }

    public open(
        dialog: ComponentType<any>,
        data: any = undefined
    ): Observable<void> {
        return this.matDialog.open(dialog, { data }).afterClosed();
    }
}
