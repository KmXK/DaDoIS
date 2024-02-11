import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { Router } from '@angular/router';
import { CloseBankDayGQL } from '../../../graphql';
import { NavigationComponent } from '../navigation/navigation.component';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [MatButton, NavigationComponent],
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss'
})
export class HomeComponent {
    private readonly router = inject(Router);
    private readonly _closeBankDayGQL = inject(CloseBankDayGQL);
    private _timer: number = 0;

    public hidden = true;
    public message: string | null = '1231241';

    public closeBankDays(dayCount: number): void {
        this._closeBankDayGQL.mutate({ days: dayCount }).subscribe(() => {
            this.message =
                dayCount === 1
                    ? 'Банковский день был закрыт'
                    : `${dayCount} банковских дней было закрыто.`;

            this.hidden = false;

            clearTimeout(this._timer);
            this._timer = setTimeout(() => {
                this.hidden = true;
            }, 3000);
        });
    }

    public openAtm(): void {
        this.router.navigateByUrl('atm');
    }
}
