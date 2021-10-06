package br.com.iteris.universidade.adocaoanimais.domain.entity;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.time.LocalDate;
import java.util.Date;

@Data
@AllArgsConstructor
public class Animal {
    private int id;
    private String nome;
    private int idade;
    private String especie;
    private LocalDate dataNasimcento;
    private int fofura;
    private int carinho;
    private String email;

}

