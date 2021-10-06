package br.com.iteris.universidade.controletarefas.domain.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class TarefaResponse {

    public int id;
    public String titulo;
    public String descricao;
    public Boolean concluido;
    public int prioridade;
}
