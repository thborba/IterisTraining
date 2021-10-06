package br.com.iteris.universidade.controletarefas.exception;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(code = HttpStatus.BAD_REQUEST)
public class TarefaNaoEncontradaException extends RuntimeException {
    public TarefaNaoEncontradaException() {
        super("Tarefa não encontrada");
    }
}
