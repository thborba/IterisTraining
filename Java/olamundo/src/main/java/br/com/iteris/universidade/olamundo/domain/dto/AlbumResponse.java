package br.com.iteris.universidade.olamundo.domain.dto;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class AlbumResponse {
    private int idAlbum;
    private String nome;
    private String artista;
    private double avaliacao;
}
