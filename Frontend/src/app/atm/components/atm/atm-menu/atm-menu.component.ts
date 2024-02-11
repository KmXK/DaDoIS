import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { AtmService } from '../../../services/atm.service';

@Component({
    selector: 'app-atm-menu',
    standalone: true,
    imports: [MatButton],
    templateUrl: './atm-menu.component.html',
    styleUrl: './atm-menu.component.scss'
})
export class AtmMenuComponent {
    private readonly service = inject(AtmService);

    public checkBalance(): void {
        this.service.checkBalance();
    }

    public withdraw(): void {
        this.service.goToWithdraw();
    }

    public topUpMobileBalance(): void {
        this.service.goToMobile();
    }

    public exit(): void {
        this.service.takeCard();
    }
}
