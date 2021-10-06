package br.com.iteris.universidade.catalogovideos.domain.dto;

import lombok.Data;

import javax.validation.constraints.NotEmpty;

@Data
public class VideoUpdateRequest {
    @NotEmpty(message = "A url é obrigatória")
    public String url;
}
