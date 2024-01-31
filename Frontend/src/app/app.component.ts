import { Component, inject, OnInit } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { ClientListComponent } from './components/client-list/client-list.component';
import { ClientService } from './services/client.service';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: 'app.component.html',
    styles: [],
    imports: [ClientListComponent, MatCard]
})
export class AppComponent implements OnInit {
    private readonly clientService = inject(ClientService);

    public ngOnInit(): void {
        this.clientService.updateClients();
    }
}
