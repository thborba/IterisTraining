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
public class Responsavel {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idResponsavel;
    private String nome;

    @OneToMany(mappedBy = "responsavel", fetch=FetchType.LAZY)
    private List<Video> videos;
}
