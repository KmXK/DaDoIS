import { Component, inject, OnInit } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { RouterOutlet } from '@angular/router';
import { ClientListComponent } from './components/client-list/client-list.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { CitizenshipService } from './services/citizenship.service';
import { CityService } from './services/city.service';
import { ClientService } from './services/client.service';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: 'app.component.html',
    styleUrl: './app.component.scss',
    imports: [ClientListComponent, MatCard, RouterOutlet, NavigationComponent]
})
export class AppComponent implements OnInit {
    private readonly clientService = inject(ClientService);
    private readonly cityService = inject(CityService);
    private readonly citizenshipService = inject(CitizenshipService);

    public ngOnInit(): void {
        this.clientService.updateClients();
        this.cityService.updateCities();
        this.citizenshipService.updateCities();
    }
}
