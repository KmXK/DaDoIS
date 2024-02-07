import { DecimalPipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { DepositService } from '../../services/deposit.service';
import { DialogService } from '../../services/dialog.service';
import { SortableObservable } from '../../shared/sortable-observable';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [MatTableModule, MatSortModule, MatButtonModule, DecimalPipe],
    templateUrl: './deposit-list.component.html',
    styleUrl: './deposit-list.component.scss'
})
export class DepositListComponent implements OnInit {
    private readonly depositService = inject(DepositService);
    private readonly dialogService = inject(DialogService);

    public readonly displayedColumns = ['number', 'fullName', 'plan', 'amount'];

    public readonly deposits = new SortableObservable(
        this.depositService.activeDeposits
    );

    public ngOnInit(): void {
        this.depositService.updateActiveDeposits();
    }

    public createDeposit(): void {
        this.dialogService.openCreateDepositDialog();
    }

    public getClientFullName(client: {
        patronymic: string;
        firstName: string;
        lastName: string;
    }): string {
        return `${client.firstName} ${client.lastName} ${client.patronymic}`;
    }
}
