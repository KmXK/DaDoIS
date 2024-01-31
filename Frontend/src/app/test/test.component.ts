import { Component, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-test',
  standalone: true,
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  value = signal(120);

  ngOnInit(): void {
    setInterval(() => {
      this.value.update(value => value + 1);
    }, 500);
  }
}
