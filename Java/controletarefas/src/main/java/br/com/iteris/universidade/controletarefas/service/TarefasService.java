package br.com.iteris.universidade.controletarefas.service;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaCreateRequest;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaResponse;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaUpdatePrioridadeRequest;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaUpdateStatusRequest;
import br.com.iteris.universidade.controletarefas.domain.entity.Tarefa;
import br.com.iteris.universidade.controletarefas.exception.TarefaNaoEncontradaException;
import br.com.iteris.universidade.controletarefas.repository.TarefasRepository;
import org.springframework.stereotype.Service;


import java.util.List;
import java.util.stream.Collectors;

@Service
public class TarefasService {


    private final TarefasRepository repository;

    public TarefasService(TarefasRepository repository) {
        this.repository = repository;
    }

    public TarefaResponse criarTarefa(TarefaCreateRequest tarefaCreateRequest) {

        var novoTarefa = new Tarefa();

        novoTarefa.setTitulo(tarefaCreateRequest.getTitulo());
        novoTarefa.setDescricao(tarefaCreateRequest.getDescricao());
        novoTarefa.setPrioridade(tarefaCreateRequest.getPrioridade());
        novoTarefa.setConcluido(false);

        var tarefaSalvo = repository.save(novoTarefa);

        return new TarefaResponse(
                tarefaSalvo.getIdTarefa(),
                tarefaSalvo.getTitulo(),
                tarefaSalvo.getDescricao(),
                false,
                tarefaSalvo.getPrioridade()

        );
    }

    public List<TarefaResponse> listar() {

        var resultado = repository.findAll();

        return resultado.stream().map(tarefa -> {
            return new TarefaResponse(
                    tarefa.getIdTarefa(),
                    tarefa.getTitulo(),
                    tarefa.getDescricao(),
                    tarefa.isConcluido(),
                    tarefa.getPrioridade()
            );

        }).collect(Collectors.toList());
    }

    public TarefaResponse buscarPorId(Integer idTarefa) {
        var tarefaEncontrado = repository.findById(idTarefa);

        if (tarefaEncontrado.isEmpty()) {
            throw new TarefaNaoEncontradaException();
        }

        var tarefaSalvo = tarefaEncontrado.get();

        return new TarefaResponse(
                tarefaSalvo.getIdTarefa(),
                tarefaSalvo.getTitulo(),
                tarefaSalvo.getDescricao(),
                tarefaSalvo.isConcluido(),
                tarefaSalvo.getPrioridade()
        );
    }

    public TarefaResponse atualizarStatus(Integer idTarefa, TarefaUpdateStatusRequest tarefaUpdateStatusRequest) {
        var tarefaEncontrado = repository.findById(idTarefa);

        if (tarefaEncontrado.isEmpty()) {
            throw new TarefaNaoEncontradaException();
        }

        var tarefa = tarefaEncontrado.get();
        tarefa.setConcluido(tarefaUpdateStatusRequest.isConcluido());

        var tarefaSalvo = repository.save(tarefa);

        return new TarefaResponse(
                tarefaSalvo.getIdTarefa(),
                tarefaSalvo.getTitulo(),
                tarefaSalvo.getDescricao(),
                tarefaSalvo.isConcluido(),
                tarefaSalvo.getPrioridade()
        );
    }

    public TarefaResponse atualizarPrioridade(Integer idTarefa, TarefaUpdatePrioridadeRequest tarefaUpdatePrioridadeRequest) {
        var tarefaEncontrado = repository.findById(idTarefa);

        if (tarefaEncontrado.isEmpty()) {
            throw new TarefaNaoEncontradaException();
        }

        var tarefa = tarefaEncontrado.get();
        tarefa.setPrioridade(tarefaUpdatePrioridadeRequest.getPrioridade());

        var tarefaSalvo = repository.save(tarefa);

        return new TarefaResponse(
                tarefaSalvo.getIdTarefa(),
                tarefaSalvo.getTitulo(),
                tarefaSalvo.getDescricao(),
                tarefaSalvo.isConcluido(),
                tarefaSalvo.getPrioridade()
        );
    }

    public TarefaResponse deletarTarefa(Integer idTarefa) {
        var tarefaEncontrado = repository.findById(idTarefa);

        if (tarefaEncontrado.isEmpty()) {
            throw new TarefaNaoEncontradaException();
        }

        var tarefa = tarefaEncontrado.get();
        repository.delete(tarefa);

        return new TarefaResponse(
                tarefa.getIdTarefa(),
                tarefa.getTitulo(),
                tarefa.getDescricao(),
                tarefa.isConcluido(),
                tarefa.getPrioridade()
        );
    }

}
