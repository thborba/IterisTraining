package br.com.iteris.universidade.catalogovideos.domain.dto;

import br.com.iteris.universidade.catalogovideos.domain.entity.VideoCategoria;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.List;

@Data
@AllArgsConstructor
public class VideoResponse {
    public int idVideo;
    public int idReponsavel;

    public String titulo;
    public String url;

    public List<CategoriaResponse> listaCategorias;
}
