package br.com.iteris.universidade.catalogovideos.controller;

import br.com.iteris.universidade.catalogovideos.domain.dto.CategoriaCreateRequest;
import br.com.iteris.universidade.catalogovideos.domain.dto.CategoriaResponse;
import br.com.iteris.universidade.catalogovideos.service.CategoriasService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController
public class CategoriasController {
    private final CategoriasService service;

    public CategoriasController(CategoriasService service) {
        this.service = service;
    }

    @GetMapping(value = "api/categorias/listar")
    public ResponseEntity<List<CategoriaResponse>> listar() {
        var listaDeCategorias = service.listar();
        return ResponseEntity.ok(listaDeCategorias);
    }
    
    @PostMapping(value = "api/categorias")
    public ResponseEntity<CategoriaResponse> criarCategoria(@RequestBody @Valid CategoriaCreateRequest categoria) {
        var categoriaResponse = service.criarCategoria(categoria);
        return ResponseEntity.ok(categoriaResponse);
    }

}
