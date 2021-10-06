package br.com.iteris.universidade.olamundo.domain.dto;

import lombok.Data;

import javax.validation.constraints.NotNull;

@Data
public class AlbumFilterRequest {
    private String artista;

    private String nome;

    @NotNull(message = "Tamanho da página deve ser definido")
    private Integer tamanho;

    @NotNull(message = "Página deve ser definido")
    private Integer pagina;
}
