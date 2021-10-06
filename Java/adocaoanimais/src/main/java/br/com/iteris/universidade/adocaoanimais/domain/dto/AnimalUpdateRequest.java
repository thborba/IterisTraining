
package br.com.iteris.universidade.adocaoanimais.domain.dto;

import lombok.Data;

import javax.validation.constraints.*;

@Data
public class AnimalUpdateRequest {

    @Min(value = 1, message = "O nível de fofura deve ser um número entre 1 e 5")
    @Max(value = 5, message = "O nível de fofura deve ser um número entre 1 e 5")
    @NotNull(message = "O nível de fofura deve ser um número entre 1 e 5")
    private int fofura;

    @Min(value = 1, message = "O nível de carinho deve ser um número entre 1 e 5")
    @Max(value = 5, message = "O nível de carinho deve ser um número entre 1 e 5")
    @NotNull(message = "O nível de carinho deve ser um número entre 1 e 5")
    private int carinho;
}
