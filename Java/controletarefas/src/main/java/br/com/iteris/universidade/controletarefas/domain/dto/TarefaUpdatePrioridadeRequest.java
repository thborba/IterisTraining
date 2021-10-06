package br.com.iteris.universidade.controletarefas.domain.dto;

import lombok.Data;

import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import javax.validation.constraints.NotNull;

@Data
public class TarefaUpdatePrioridadeRequest {
    @NotNull(message = "A prioridade deve ser um número de 1 a 5")
    @Min(value = 1, message = "A prioridade deve ser um número de 1 a 5")
    @Max(value = 5, message = "A prioridade deve ser um número de 1 a 5")
    public int prioridade;
}
