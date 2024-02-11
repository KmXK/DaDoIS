import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { Router } from '@angular/router';
import { AtmService } from '../../../services/atm.service';

@Component({
    selector: 'app-initial-menu-atm',
    standalone: true,
    imports: [MatButton],
    templateUrl: './initial-menu-atm.component.html'
})
export class InitialMenuAtmComponent {
    private readonly service = inject(AtmService);
    private readonly router = inject(Router);

    public enterCard(): void {
        this.service.startEnteringCard();
    }

    public exit(): void {
        this.router.navigateByUrl('/');
    }
}
