package br.com.iteris.universidade.catalogovideos.domain.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class ResponsavelResponse {
    public int idResponsavel;
    public String nome;
}
