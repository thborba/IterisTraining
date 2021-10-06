package br.com.iteris.universidade.catalogovideos.domain.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class CategoriaResponse {
    public int idCategoria;
    public String nome;

}
