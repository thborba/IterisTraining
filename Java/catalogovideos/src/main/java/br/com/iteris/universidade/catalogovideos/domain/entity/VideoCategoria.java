package br.com.iteris.universidade.catalogovideos.domain.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@Entity
@NoArgsConstructor
@AllArgsConstructor
public class VideoCategoria {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idVideoCategoria;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name="idVideo")
    private Video video;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name="idCategoria")
    private Categoria categoria;

}
