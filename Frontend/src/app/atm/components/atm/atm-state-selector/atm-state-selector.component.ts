import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AtmStateEnum } from '../../../enums/atm-state.enum';
import { AtmService } from '../../../services/atm.service';
import { AtmBalanceComponent } from '../atm-balance/atm-balance.component';
import { AtmEnterCardComponent } from '../atm-enter-card/atm-enter-card.component';
import { AtmMenuComponent } from '../atm-menu/atm-menu.component';
import { AtmMobileComponent } from '../atm-mobile/atm-mobile.component';
import { AtmWithdraw } from '../atm-withdraw/atm-withdraw.component';
import { InitialMenuAtmComponent } from '../initial-menu-atm/initial-menu-atm.component';

@Component({
    selector: 'app-atm-state-selector',
    standalone: true,
    imports: [
        AsyncPipe,
        InitialMenuAtmComponent,
        AtmEnterCardComponent,
        AtmMenuComponent,
        AtmBalanceComponent,
        AtmWithdraw,
        AtmMobileComponent
    ],
    templateUrl: './atm-state-selector.component.html'
})
export class AtmStateSelectorComponent {
    private readonly service = inject(AtmService);

    public readonly AtmState = AtmStateEnum;

    public state = this.service.state;
}
