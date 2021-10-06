import { Component, OnInit } from '@angular/core';
import { ListaTarefasService } from 'src/app/services/lista-tarefas.service';

@Component({
  selector: 'app-lista-tarefas',
  templateUrl: './lista-tarefas.component.html',
  styleUrls: ['./lista-tarefas.component.css'],
})
export class ListaTarefasComponent implements OnInit {
  public descricaoNovaTarefa = '';
  constructor(public svc: ListaTarefasService) {}

  ngOnInit(): void {}

  public adicionar(): void {
    if (
      this.descricaoNovaTarefa &&
      this.descricaoNovaTarefa.trim().length > 0
    ) {
      this.svc.adicionar(this.descricaoNovaTarefa);
      this.descricaoNovaTarefa = ''; // limpar valor após o cadastros
    }
  }
}
