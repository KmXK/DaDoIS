import { Component, inject, OnInit, signal } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { AtmService } from '../../../services/atm.service';

@Component({
    selector: 'app-atm-balance',
    standalone: true,
    imports: [MatProgressSpinner, MatButton],
    templateUrl: './atm-balance.component.html',
    styleUrl: './atm-balance.component.scss'
})
export class AtmBalanceComponent implements OnInit {
    private readonly service = inject(AtmService);

    public readonly loading = signal(true);
    public balance = 0;
    public currency = '';
    public error = '';

    ngOnInit(): void {
        this.service.loadBalance().subscribe({
            next: value => {
                if (value) {
                    this.balance = value.amount;
                    this.currency = value.currency;
                } else {
                    this.error = 'Invalid balance';
                }
                this.loading.set(false);
            },
            error: error => {
                this.error = error.errorMessage;
                this.loading.set(false);
            }
        });
    }

    exit() {
        this.service.backToMenu();
    }
}
