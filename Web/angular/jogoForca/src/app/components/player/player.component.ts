import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  public input = "";
  public descricaoNovaTarefa = '';
  constructor(public svc: GameService) { }

  ngOnInit(): void {
  }

}
