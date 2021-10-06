package br.com.iteris.universidade.adocaoanimais.controller;

import br.com.iteris.universidade.adocaoanimais.domain.dto.AnimalCreateRequest;
import br.com.iteris.universidade.adocaoanimais.domain.dto.AnimalUpdateRequest;
import br.com.iteris.universidade.adocaoanimais.domain.entity.Animal;
import br.com.iteris.universidade.adocaoanimais.service.AnimaisService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController
public class AnimaisController {

    private final AnimaisService service;

    public AnimaisController(AnimaisService service) {
        this.service = service;
    }

    @GetMapping(value = "api/animais")
    public ResponseEntity<List<Animal>> listar() {
        var listaDeAnimais = service.listar();
        return ResponseEntity.ok(listaDeAnimais);
    }

    @GetMapping(value = "api/animais/{id}")
    public ResponseEntity<Animal> buscarPorId(@PathVariable Integer id) {
        var animalResponse = service.buscarPorId(id);
        return ResponseEntity.ok(animalResponse);
    }

    @GetMapping(value = "api/animais/nome/{nomeParam}")
    public ResponseEntity<Animal> buscarPorNome(@PathVariable String nomeParam) {
        var animalResponse = service.buscarPorNome(nomeParam);
        return ResponseEntity.ok(animalResponse);
    }

    @PostMapping(value = "api/animais")
    public ResponseEntity<Animal> criarAnimal(@RequestBody @Valid AnimalCreateRequest model) {
        var animalResponse = service.criarAnimal(model);
        return ResponseEntity.ok(animalResponse);
    }

    @PutMapping(value = "api/animais/{idAnimal}")
    public ResponseEntity<Animal> atualizarAnimal(
            @PathVariable Integer idAnimal,
            @RequestBody @Valid AnimalUpdateRequest animalUpdateRequest) {
        var animal = service.atualizarAnimal(idAnimal, animalUpdateRequest);
        return ResponseEntity.ok(animal);
    }

    @DeleteMapping(value = "api/animais/{idAnimal}")
    public ResponseEntity<Animal> deletarAnimal(@PathVariable Integer idAnimal) {
        var animal = service.deletarAnimal(idAnimal);
        return ResponseEntity.ok(animal);
    }
}
