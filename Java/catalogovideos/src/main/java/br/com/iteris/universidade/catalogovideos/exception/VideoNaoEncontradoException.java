package br.com.iteris.universidade.catalogovideos.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(code = HttpStatus.BAD_REQUEST)
public class VideoNaoEncontradoException  extends RuntimeException {
    public VideoNaoEncontradoException() {
        super("Video não encontrado");
    }
}
