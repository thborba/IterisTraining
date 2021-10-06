package br.com.iteris.universidade.catalogovideos.controller;

import br.com.iteris.universidade.catalogovideos.domain.dto.ResponsavelCreateRequest;
import br.com.iteris.universidade.catalogovideos.domain.dto.ResponsavelResponse;
import br.com.iteris.universidade.catalogovideos.service.ResponsaveisService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;
import java.util.List;

@RestController
public class ResponsaveisController {

    private final ResponsaveisService service;

    public ResponsaveisController(ResponsaveisService service) {
        this.service = service;
    }

    @GetMapping(value = "api/responsaveis/listar")
    public ResponseEntity<List<ResponsavelResponse>> listar() {
        var listaDeResponsaveis = service.listar();
        return ResponseEntity.ok(listaDeResponsaveis);
    }

    @PostMapping(value = "api/responsaveis")
    public ResponseEntity<ResponsavelResponse> criarResponsavel(@RequestBody @Valid ResponsavelCreateRequest responsavel) {
        var responsavelResponse = service.criarResponsavel(responsavel);
        return ResponseEntity.ok(responsavelResponse);
    }
}
