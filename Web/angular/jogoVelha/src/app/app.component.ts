import { Component } from '@angular/core';
import { CellListService } from './services/cell-list.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'jogoVelha';
  constructor(public service: CellListService) {}
}
