import { Injectable } from '@angular/core';
import { CellModel } from '../models/cell-model';

@Injectable({
  providedIn: 'root'
})

export class CellListService {
  public list: Array<CellModel> = [];
  private player = "X";
  private winner = "";
  private draw = false;

  constructor() {
    for (let i = 0; i < 9; i++) {
      let cell = new CellModel();
      cell.id = i;
      this.list.push(cell);
    }
  }

  public onClick(id: number) : void {
    if (this.winner || this.draw)
      this.reload();
    else if (!this.list[id].value) {
        this.list[id].value = this.player;
        this.list[id].color = ( this.player == "X" ? "red" : "white")
        this.player = ( this.player == "X" ? "O" : "X");
        this.checkEnd();
    }
  }

  public checkEquals(n1: number, n2: number, n3: number): boolean {
    if (this.list[n1].value == "X" && this.list[n2].value == "X" && this.list[n3].value == "X") {
      this.winner = "X";
      return true;
    } else if (this.list[n1].value == "O" && this.list[n2].value == "O" && this.list[n3].value == "O") {
      this.winner = "O";
      return true;
    } else
      return false;
  }

  public isFull(): boolean {
    for (var cell of this.list)
      if (!cell.value)
        return false;

    return true;
  }

  public checkEnd(): void {
    if (this.checkEquals(0, 1, 2) || this.checkEquals(3, 4, 5) || this.checkEquals(6, 7, 8) ||
      this.checkEquals(0, 3, 6) || this.checkEquals(1, 4, 7) || this.checkEquals(2, 5, 8) ||
      this.checkEquals(0, 4, 8) || this.checkEquals(2, 4, 6)) {
      alert(this.winner + " venceu");
    }
    else if (this.isFull()) {
      alert("empatou");
      this.draw = true;
    }
  }

  public reload(): void {
    for (var cell of this.list) {
      cell.value = "";
      cell.color = "";
    }
    this.winner = "";
    this.draw = false;
    this.player = "X";
  }

}
