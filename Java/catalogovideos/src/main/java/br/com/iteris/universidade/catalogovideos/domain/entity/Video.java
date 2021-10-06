package br.com.iteris.universidade.catalogovideos.domain.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.List;

@Data
@Entity
@NoArgsConstructor
@AllArgsConstructor
public class Video {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idVideo;
    public String titulo;
    public String url;

    @OneToMany(mappedBy = "video", fetch=FetchType.LAZY)
    private List<VideoCategoria> videoCategorias;

    @OneToOne(fetch=FetchType.LAZY)
    @JoinColumn(name="idResponsavel")
    private Responsavel responsavel;

}
