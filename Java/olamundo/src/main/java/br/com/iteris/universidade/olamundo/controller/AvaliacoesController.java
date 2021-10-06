package br.com.iteris.universidade.olamundo.controller;

import br.com.iteris.universidade.olamundo.domain.dto.AvaliacaoCreateRequest;
import br.com.iteris.universidade.olamundo.domain.dto.AvaliacaoResponse;
import br.com.iteris.universidade.olamundo.service.AvaliacoesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;

@RestController
public class AvaliacoesController {

    private final AvaliacoesService service;

    @Autowired
    public AvaliacoesController(AvaliacoesService service) {
        this.service = service;
    }

    @PostMapping("api/avaliacao")
    public ResponseEntity<AvaliacaoResponse> avaliar(@RequestBody @Valid AvaliacaoCreateRequest createRequest) {
        var avaliacao = service.avaliar(createRequest);
        return ResponseEntity.ok(avaliacao);
    }
}
