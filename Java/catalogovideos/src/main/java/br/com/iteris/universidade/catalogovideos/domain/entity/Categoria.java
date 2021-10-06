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
public class Categoria {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idCategoria;
    private String nome;

    @OneToMany(mappedBy = "categoria", fetch=FetchType.LAZY)
    private List<VideoCategoria> videoCategorias;
}
