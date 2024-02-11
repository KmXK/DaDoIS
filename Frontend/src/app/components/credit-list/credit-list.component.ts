import { DecimalPipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CreditService } from '../../services/credit.service';
import { DialogService } from '../../services/dialog.service';
import { SortableObservable } from '../../shared/sortable-observable';
import { CreditCreateDialog } from '../dialogs/credit-create-dialog/credit-create-dialog.component';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [MatTableModule, MatSortModule, MatButtonModule, DecimalPipe],
    templateUrl: './credit-list.component.html',
    styleUrl: './credit-list.component.scss'
})
export class CreditListComponent implements OnInit {
    private readonly creditService = inject(CreditService);
    private readonly dialogService = inject(DialogService);

    public readonly displayedColumns = ['number', 'fullName', 'plan', 'amount'];

    public readonly deposits = new SortableObservable(
        this.creditService.activeCredits
    );

    public ngOnInit(): void {
        this.creditService.updateActiveCredits();
    }

    public createCredit(): void {
        this.dialogService.open(CreditCreateDialog);
    }

    public getClientFullName(client: {
        patronymic: string;
        firstName: string;
        lastName: string;
    }): string {
        return `${client.firstName} ${client.lastName} ${client.patronymic}`;
    }
}
