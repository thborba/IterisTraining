import { Component, OnInit } from '@angular/core';
import { ItemModel } from '../item/item-model';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {
  public listItens: Array<ItemModel>;

  constructor() {
    this.listItens = [];

    const item = new ItemModel();

    item.title = 'TÉCNICO EM INFORMÁTICA';
    item.period =
    '2014 - 2018';
    item.description =
      'Gestão de sistemas computacionais visando suporte ao usuário';
    this.listItens.push(item);

    const item2 = new ItemModel();
    item2.title = 'ENSINO MÉDIO';
    item2.period =
      'LIDER DE PROJETO | 2012 - 2013';
    item2.description =
      'Aluno destaque em dois anos subsequentes, em feira de ciências. Participante do Grêmio Estudantil. Bolsista integral por mérito sobre desempenho';
    this.listItens.push(item2);

  }

  ngOnInit(): void {
  }

}
