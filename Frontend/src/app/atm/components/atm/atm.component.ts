import { Component } from '@angular/core';
import { AtmStateSelectorComponent } from './atm-state-selector/atm-state-selector.component';

@Component({
    selector: 'app-atm',
    standalone: true,
    imports: [AtmStateSelectorComponent],
    templateUrl: './atm.component.html',
    styleUrl: './atm.component.scss'
})
export class AtmComponent {}
