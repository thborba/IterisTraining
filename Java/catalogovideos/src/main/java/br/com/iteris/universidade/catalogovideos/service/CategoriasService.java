package br.com.iteris.universidade.catalogovideos.service;

import br.com.iteris.universidade.catalogovideos.domain.dto.CategoriaCreateRequest;
import br.com.iteris.universidade.catalogovideos.domain.dto.CategoriaResponse;
import br.com.iteris.universidade.catalogovideos.domain.entity.Categoria;
import br.com.iteris.universidade.catalogovideos.repository.CategoriasRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CategoriasService {

    private final CategoriasRepository repository;

    public CategoriasService(CategoriasRepository repository) {
        this.repository = repository;
    }

    public CategoriaResponse criarCategoria(CategoriaCreateRequest tarefaCreateRequest) {

        var novoCategoria = new Categoria();

        novoCategoria.setNome(tarefaCreateRequest.getNome());

        var tarefaSalvo = repository.save(novoCategoria);

        return new CategoriaResponse(
            tarefaSalvo.getIdCategoria(), tarefaSalvo.getNome()

        );
    }

    public List<CategoriaResponse> listar() {

        var resultado = repository.findAll();


        return resultado.stream().map(categoria -> {
            return new CategoriaResponse(
                    categoria.getIdCategoria(),
                    categoria.getNome()
            );

        }).collect(Collectors.toList());
    }
}
