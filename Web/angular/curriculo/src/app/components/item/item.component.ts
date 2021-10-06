import { Component, Input, OnInit } from '@angular/core';
import { ItemModel } from './item-model';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  @Input()
  public item: ItemModel = new ItemModel();
  constructor() { }

  ngOnInit(): void {

  }

}
