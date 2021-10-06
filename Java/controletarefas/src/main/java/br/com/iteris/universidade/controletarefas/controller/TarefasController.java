package br.com.iteris.universidade.controletarefas.controller;


import br.com.iteris.universidade.controletarefas.domain.dto.TarefaCreateRequest;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaResponse;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaUpdatePrioridadeRequest;
import br.com.iteris.universidade.controletarefas.domain.dto.TarefaUpdateStatusRequest;
import br.com.iteris.universidade.controletarefas.service.TarefasService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;


@RestController
public class TarefasController {

    private final TarefasService service;

    public TarefasController(TarefasService service) {
        this.service = service;
    }

    @GetMapping(value = "api/tarefas")
    public ResponseEntity<List<TarefaResponse>> listar() {
        var listaDeTarefas = service.listar();
        return ResponseEntity.ok(listaDeTarefas);
    }

    @GetMapping(value = "api/tarefas/{id}")
    public ResponseEntity<TarefaResponse> buscarPorId(@PathVariable Integer id) {
        var tarefaResponse = service.buscarPorId(id);
        return ResponseEntity.ok(tarefaResponse);
    }
    @PostMapping(value = "api/tarefas")
    public ResponseEntity<TarefaResponse> criarTarefa(@RequestBody @Valid TarefaCreateRequest tarefa) {
        var tarefaResponse = service.criarTarefa(tarefa);
        return ResponseEntity.ok(tarefaResponse);
    }

    @PutMapping(value = "api/tarefas/{idTarefa}/atualizarStatus")
    public ResponseEntity<TarefaResponse> atualizarStatus(
            @PathVariable Integer idTarefa,
            @RequestBody @Valid TarefaUpdateStatusRequest tarefaUpdateStatusRequest) {
        var tarefa = service.atualizarStatus(idTarefa, tarefaUpdateStatusRequest);
        return ResponseEntity.ok(tarefa);
    }

    @PutMapping(value = "api/tarefas/{idTarefa}/atualizarPrioridade")
    public ResponseEntity<TarefaResponse> atualizarPrioridade(
            @PathVariable Integer idTarefa,
            @RequestBody @Valid TarefaUpdatePrioridadeRequest tarefaUpdateRequest) {
        var tarefa = service.atualizarPrioridade(idTarefa, tarefaUpdateRequest);
        return ResponseEntity.ok(tarefa);
    }

    @DeleteMapping(value = "api/tarefas/{idTarefa}")
    public ResponseEntity<TarefaResponse> deletarTarefa(@PathVariable Integer idTarefa) {
        var tarefa = service.deletarTarefa(idTarefa);
        return ResponseEntity.ok(tarefa);
    }
}
