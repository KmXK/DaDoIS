import { DecimalPipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CardService } from '../../services/card.service';
import { DialogService } from '../../services/dialog.service';
import { SortableObservable } from '../../shared/sortable-observable';

@Component({
    selector: 'app-deposit-plan-list',
    standalone: true,
    imports: [MatTableModule, MatSortModule, MatButtonModule, DecimalPipe],
    templateUrl: './card-list.component.html',
    styleUrl: './card-list.component.scss'
})
export class CardListComponent implements OnInit {
    private readonly cardService = inject(CardService);
    private readonly dialogService = inject(DialogService);

    public readonly displayedColumns = ['cardNumber', 'iban', 'client', 'pin'];

    public readonly deposits = new SortableObservable(this.cardService.cards);

    public ngOnInit(): void {
        this.cardService.updateCards();
    }

    public getClientFullName(client: {
        patronymic: string;
        firstName: string;
        lastName: string;
    }): string {
        return `${client.firstName} ${client.lastName} ${client.patronymic}`;
    }
}
