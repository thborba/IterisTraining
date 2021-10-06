package br.com.iteris.universidade.olamundo.domain.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.List;

@Data
@Entity
@NoArgsConstructor
@AllArgsConstructor
public class Album {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int idAlbum;

    private String nome;

    private String artista;

    private int anoLancamento;

    @OneToMany(mappedBy = "album", fetch=FetchType.LAZY)
    private List<Avaliacao> avaliacoes;
}