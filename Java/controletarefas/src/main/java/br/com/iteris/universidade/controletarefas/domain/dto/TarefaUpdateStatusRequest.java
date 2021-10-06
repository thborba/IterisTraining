package br.com.iteris.universidade.controletarefas.domain.dto;

import lombok.Data;

import javax.validation.constraints.NotNull;

@Data
public class TarefaUpdateStatusRequest {
    @NotNull(message = "O boolean concluido é obrigatório")
    public boolean concluido;
}
