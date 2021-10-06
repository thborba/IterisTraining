import { Component, Input, OnInit } from '@angular/core';
import { LetterModel } from 'src/app/letter-model';

@Component({
  selector: 'app-letter',
  templateUrl: './letter.component.html',
  styleUrls: ['./letter.component.css']
})
export class LetterComponent implements OnInit {
  @Input()
  public letter: LetterModel = new LetterModel();
  constructor() { }

  ngOnInit(): void {
  }

}
