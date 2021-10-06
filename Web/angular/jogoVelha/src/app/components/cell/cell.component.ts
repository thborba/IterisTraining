import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { CellModel } from 'src/app/models/cell-model';
import { CellListService } from 'src/app/services/cell-list.service';


@Component({
  selector: 'app-cell',
  templateUrl: './cell.component.html',
  styleUrls: ['./cell.component.css']
})
export class CellComponent implements OnInit {
  @Input()
  public cell: CellModel = new CellModel();

  constructor(public service: CellListService) { }
  public onClick(){
    this.cell.value = "TESTE";
  }
  ngOnInit(): void {

  }
}
