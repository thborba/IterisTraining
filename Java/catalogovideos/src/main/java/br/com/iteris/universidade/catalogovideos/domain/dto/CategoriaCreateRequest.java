package br.com.iteris.universidade.catalogovideos.domain.dto;

import lombok.Data;

import javax.validation.constraints.NotNull;

@Data
public class CategoriaCreateRequest {
    @NotNull(message = "O nome é obrigatório")
    public String nome;
}
