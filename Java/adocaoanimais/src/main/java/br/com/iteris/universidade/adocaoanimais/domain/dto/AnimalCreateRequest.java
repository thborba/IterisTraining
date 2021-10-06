package br.com.iteris.universidade.adocaoanimais.domain.dto;
import lombok.Data;

import javax.validation.constraints.*;
import java.time.LocalDate;


@Data
public class AnimalCreateRequest {

    @NotEmpty(message = "Nome deve ser definido")
    private String nome;

    @NotNull(message = "A idade deve ser definida")
    private int idade;

    @NotEmpty(message = "Espécie deve ser definida")
    private String especie;

    private LocalDate dataNasimcento;

    @Min(value = 1, message = "O nível de fofura deve ser um número entre 1 e 5")
    @Max(value = 5, message = "O nível de fofura deve ser um número entre 1 e 5")
    @NotNull(message = "O nível de fofura deve ser um número entre 1 e 5")
    private int fofura;

    @Min(value = 1, message = "O nível de carinho deve ser um número entre 1 e 5")
    @Max(value = 5, message = "O nível de carinho deve ser um número entre 1 e 5")
    @NotNull(message = "O nível de carinho deve ser um número entre 1 e 5")
    private int carinho;

    @Email
    private String email;
}
