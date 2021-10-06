package br.com.iteris.universidade.adocaoanimais.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(code = HttpStatus.NOT_FOUND)
public class AnimalNaoEncontradoException extends RuntimeException{
    public AnimalNaoEncontradoException(){
        super("O animal não foi encontrado");
    }

}


