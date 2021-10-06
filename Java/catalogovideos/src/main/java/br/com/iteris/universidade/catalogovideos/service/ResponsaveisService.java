package br.com.iteris.universidade.catalogovideos.service;

import br.com.iteris.universidade.catalogovideos.domain.dto.ResponsavelCreateRequest;
import br.com.iteris.universidade.catalogovideos.domain.dto.ResponsavelResponse;
import br.com.iteris.universidade.catalogovideos.domain.entity.Responsavel;
import br.com.iteris.universidade.catalogovideos.repository.ResponsaveisRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class ResponsaveisService {

    private final ResponsaveisRepository repository;

    public ResponsaveisService(ResponsaveisRepository repository) {
        this.repository = repository;
    }

    public ResponsavelResponse criarResponsavel(ResponsavelCreateRequest tarefaCreateRequest) {

        var novoResponsavel = new Responsavel();

        novoResponsavel.setNome(tarefaCreateRequest.getNome());

        var tarefaSalvo = repository.save(novoResponsavel);

        return new ResponsavelResponse(
                tarefaSalvo.getIdResponsavel(), tarefaSalvo.getNome()

        );
    }

    public List<ResponsavelResponse> listar() {

        var resultado = repository.findAll();


        return resultado.stream().map(responsavel -> {
            return new ResponsavelResponse(
                    responsavel.getIdResponsavel(),
                    responsavel.getNome()
            );

        }).collect(Collectors.toList());
    }
}
