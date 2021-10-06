package br.com.iteris.universidade.olamundo.domain.dto;

import lombok.Data;

import javax.validation.constraints.NotNull;

@Data
public class AvaliacaoCreateRequest {
    @NotNull(message = "Id do Album deve ser definido")
    private Integer IdAlbum;

    @NotNull(message = "Nota deve ser definido")
    private Integer Nota;

    private String Comentario;
}
