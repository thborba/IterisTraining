
package br.com.iteris.universidade.adocaoanimais.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(code = HttpStatus.BAD_REQUEST)
public class AnimalEspecieInvalidaException extends RuntimeException {
    public AnimalEspecieInvalidaException() {
        super("A especie deve ser: Cachorro, Gato, Coelho ou Capivara");
    }

}
