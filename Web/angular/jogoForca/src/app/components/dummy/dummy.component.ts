import { Component, Input, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-dummy',
  templateUrl: './dummy.component.html',
  styleUrls: ['./dummy.component.css']
})
export class DummyComponent implements OnInit {

  constructor(public svc: GameService) { }

  ngOnInit(): void {
  }

}
