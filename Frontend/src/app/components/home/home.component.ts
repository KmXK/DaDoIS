import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { CloseBankDayGQL } from '../../../graphql';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [MatButton],
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss'
})
export class HomeComponent {
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
}
