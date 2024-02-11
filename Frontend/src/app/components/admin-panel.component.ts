import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';

@Component({
    selector: 'app-admin-panel',
    standalone: true,
    imports: [RouterOutlet, NavigationComponent],
    template: `
        <div class="container">
            <div class="wrapper">
                <app-navigation />
                <router-outlet></router-outlet>
            </div>
        </div>
    `,
    styleUrl: './admin-panel.component.scss'
})
export class AdminPanelComponent {}
