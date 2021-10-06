import { Component, OnInit } from '@angular/core';
import { ItemModel } from '../item/item-model';


@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html',
  styleUrls: ['./experiences.component.css']
})
export class ExperiencesComponent implements OnInit {
  public listItens: Array<ItemModel>;

  constructor() {
    this.listItens = [];

    const item = new ItemModel();

    item.title = 'GRÊMIO ESTUDANTIL';
    item.period =
    'SECRETÁRIA DO GRÊMIO | 2014 - 2018';
    item.description =
      'Execução de diretrizes propostas pela administração, intermediações de aquisições.';
    this.listItens.push(item);

    const item2 = new ItemModel();
    item2.title = 'ENSINO MÉDIO';
    item2.period =
      'LIDER DE PROJETO | 2012 - 2013';
    item2.description =
      'Participação na criação de estratégias de administração de serviços, promovendo aprimoramento.';
    this.listItens.push(item2);


    const item3 = new ItemModel();
    item3.title = 'PARTICIPAÇÃO EM EMPRESA JUNIOR';
    item3.period =      'LIDER DE PROJETO | 2010 - 2012';
    item3.description =
      'Experiência no desenvolvimento de estratégias de mercado, auxiliando na análise de metas.';
    this.listItens.push(item3);
  }

  ngOnInit(): void {

  }

}
