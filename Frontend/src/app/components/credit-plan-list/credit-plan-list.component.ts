import { DecimalPipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CreditPlanService } from '../../services/credit-plan.service';
import { DialogService } from '../../services/dialog.service';
import { SortableObservable } from '../../shared/sortable-observable';
import { CreditPlanCreateDialog } from '../dialogs/credit-plan-create-dialog/credit-plan-create-dialog.component';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [MatTableModule, MatSortModule, MatButtonModule, DecimalPipe],
    templateUrl: './credit-plan-list.component.html',
    styleUrl: './credit-plan-list.component.scss'
})
export class CreditPlanListComponent implements OnInit {
    private readonly creditPlanService = inject(CreditPlanService);
    private readonly dialogService = inject(DialogService);

    public readonly displayedColumns = [
        'name',
        'interest',
        'currency',
        'period',
        'isAnnuity'
    ];
    public readonly plans = new SortableObservable(
        this.creditPlanService.plans
    );

    ngOnInit() {
        this.creditPlanService.updatePlans();
    }

    public createPlan(): void {
        this.dialogService.open(CreditPlanCreateDialog).subscribe(() => {});
    }
}
