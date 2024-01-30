import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TestComponent } from "./test/test.component";

@Component({
    selector: 'app-root',
    standalone: true,
    template: `
    <h1>HELLO WORLD</h1>

    <app-test/>

    <router-outlet />
  `,
    styles: [],
    imports: [RouterOutlet, TestComponent]
})
export class AppComponent {
  title = 'DaDoIS.Frontend';
}
