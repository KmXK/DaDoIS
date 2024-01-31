import { Component, OnInit, inject } from '@angular/core';
import { ClientService } from './services/client.service';
import { ClientListComponent } from './components/client-list/client-list.component';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: 'app.component.html',
    styles: [],
    imports: [ClientListComponent]
})
export class AppComponent implements OnInit {
    private readonly clientService = inject(ClientService);

    ngOnInit(): void {
        this.clientService.updateClients();
    }
}
