import { DecimalPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
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
export class DepositListComponent {
    private readonly depositService = inject(DepositService);
    private readonly dialogService = inject(DialogService);

    public readonly displayedColumns = ['number', 'fullName', 'plan', 'amount'];

    public readonly deposits = new SortableObservable(
        this.depositService.getActiveDeposits()
    );

    ngOnInit() {
        this.deposits.get().subscribe(console.log);
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
