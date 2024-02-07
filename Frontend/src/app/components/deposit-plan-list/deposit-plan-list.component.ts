import { DecimalPipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { DepositPlanService } from '../../services/deposit-plan.service';
import { DialogService } from '../../services/dialog.service';
import { SortableObservable } from '../../shared/sortable-observable';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [MatTableModule, MatSortModule, MatButtonModule, DecimalPipe],
    templateUrl: './deposit-plan-list.component.html',
    styleUrl: './deposit-plan-list.component.scss'
})
export class DepositPlanListComponent implements OnInit {
    private readonly depositPlanService = inject(DepositPlanService);
    private readonly dialogService = inject(DialogService);

    public readonly displayedColumns = [
        'name',
        'interest',
        'currency',
        'period',
        'isRevocable'
    ];
    public readonly plans = new SortableObservable(
        this.depositPlanService.plans
    );

    ngOnInit() {
        this.depositPlanService.updatePlans();
    }

    public createPlan(): void {
        this.dialogService.openCreateDepositPlanDialog();
    }
}
