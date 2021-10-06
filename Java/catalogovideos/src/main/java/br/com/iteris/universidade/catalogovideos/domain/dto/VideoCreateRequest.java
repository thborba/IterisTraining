package br.com.iteris.universidade.catalogovideos.domain.dto;

import lombok.Data;

import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;

@Data
public class VideoCreateRequest {

    @NotNull(message = "O responsável é obrigatório")
    public int idResponsavel;
    @NotNull(message = "A categoria é obrigatória")
    public int[] categoriaIds;
    @NotEmpty (message = "O título é obrigatória")
    public String titulo;
    @NotEmpty(message = "A url é obrigatória")
    public String url;
}
