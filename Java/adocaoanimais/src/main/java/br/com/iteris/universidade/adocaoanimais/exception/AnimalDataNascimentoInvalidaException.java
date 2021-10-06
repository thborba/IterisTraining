package br.com.iteris.universidade.adocaoanimais.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(code = HttpStatus.BAD_REQUEST)
public class AnimalDataNascimentoInvalidaException extends RuntimeException {
    public AnimalDataNascimentoInvalidaException() {
        super("A data de nascimento não pode ser no futuro");
    }

}
