package br.com.iteris.universidade.olamundo.service;

import br.com.iteris.universidade.olamundo.domain.dto.AlbumCreateRequest;
import br.com.iteris.universidade.olamundo.domain.dto.AlbumFilterRequest;
import br.com.iteris.universidade.olamundo.domain.dto.AlbumResponse;
import br.com.iteris.universidade.olamundo.domain.dto.AlbumUpdateRequest;
import br.com.iteris.universidade.olamundo.domain.entity.Album;
import br.com.iteris.universidade.olamundo.domain.entity.Avaliacao;
import br.com.iteris.universidade.olamundo.exception.AlbumInvalidoException;
import br.com.iteris.universidade.olamundo.exception.AlbumNaoEncontradoException;
import br.com.iteris.universidade.olamundo.repository.AlbunsRepository;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;

import java.util.Calendar;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class AlbunsService {

    private final AlbunsRepository repository;

    public AlbunsService(AlbunsRepository repository) {
        this.repository = repository;
    }

    public AlbumResponse criarAlbum(AlbumCreateRequest albumCreateRequest) {
        // Regra
        // Somente albums lançados entre 1950 e o ano atual.
        if (albumCreateRequest.getAnoLancamento() < 1950 || albumCreateRequest.getAnoLancamento() > Calendar.getInstance().get(Calendar.YEAR)) {
            throw new AlbumInvalidoException("Album não se encaixa nas regras de anos: maior que 1950 e menor que hoje");
        }

        // tudo certo, só cadastrar
        var novoAlbum = new Album();
        novoAlbum.setNome(albumCreateRequest.getNome());
        novoAlbum.setArtista(albumCreateRequest.getArtista());
        novoAlbum.setAnoLancamento(albumCreateRequest.getAnoLancamento());

        var albumSalvo = repository.save(novoAlbum);

        return new AlbumResponse(
                albumSalvo.getIdAlbum(),
                albumSalvo.getNome(),
                albumSalvo.getArtista(),
                0
        );
    }

    public Page<AlbumResponse> listar(AlbumFilterRequest filter) {
        var resultado = repository.listarComFiltroNativo(filter.getNome(), filter.getArtista(), PageRequest.of(
                filter.getPagina(),
                filter.getTamanho()
        ));


        var lista = resultado.get().map(album -> {
            // consulta a lista de notas
            var notas = album.getAvaliacoes().stream()
                    // 'Avaliacao::getNota' é a mesma coisa que 'a -> a.getNota()'
                    .map(Avaliacao::getNota)
                    .collect(Collectors.toList());

            return new AlbumResponse(
                    album.getIdAlbum(),
                    album.getNome(),
                    album.getArtista(),
                    calculaMedia(notas)
            );
        }).collect(Collectors.toList());

        return new PageImpl<>(lista, resultado.getPageable(), resultado.getTotalElements());
    }

    public AlbumResponse buscarPorId(Integer idAlbum) {
        var albumEncontrado = repository.findById(idAlbum);

        if (albumEncontrado.isEmpty()) {
            throw new AlbumNaoEncontradoException();
        }

        var albumSalvo = albumEncontrado.get();
        // consulta a lista de notas
        var notas = albumSalvo.getAvaliacoes().stream()
                .map(Avaliacao::getNota)
                .collect(Collectors.toList());

        return new AlbumResponse(
                albumSalvo.getIdAlbum(),
                albumSalvo.getNome(),
                albumSalvo.getArtista(),
                calculaMedia(notas)
        );
    }

    public AlbumResponse buscarPorNome(String nome) {
        var albumEncontrado = repository.findByNomeContaining(nome);

        if (albumEncontrado.isEmpty()) {
            throw new AlbumNaoEncontradoException();
        }

        var albumSalvo = albumEncontrado.get();
        // consulta a lista de notas
        var notas = albumSalvo.getAvaliacoes().stream()
                .map(Avaliacao::getNota)
                .collect(Collectors.toList());


        return new AlbumResponse(
                albumSalvo.getIdAlbum(),
                albumSalvo.getNome(),
                albumSalvo.getArtista(),
                calculaMedia(notas)
        );
    }

    public AlbumResponse atualizarAlbum(Integer idAlbum, AlbumUpdateRequest albumUpdateRequest) {
        var albumEncontrado = repository.findById(idAlbum);

        if (albumEncontrado.isEmpty()) {
            throw new AlbumNaoEncontradoException();
        }

        var album = albumEncontrado.get();
        album.setArtista(albumUpdateRequest.getArtista());

        var albumSalvo = repository.save(album);
        // consulta a lista de notas
        var notas = albumSalvo.getAvaliacoes().stream()
                .map(Avaliacao::getNota)
                .collect(Collectors.toList());


        return new AlbumResponse(
                albumSalvo.getIdAlbum(),
                albumSalvo.getNome(),
                albumSalvo.getArtista(),
                calculaMedia(notas)
        );
    }

    public AlbumResponse deletarAlbum(Integer idAlbum) {
        var albumEncontrado = repository.findById(idAlbum);

        if (albumEncontrado.isEmpty()) {
            throw new AlbumNaoEncontradoException();
        }

        var album = albumEncontrado.get();
        repository.delete(album);

        return new AlbumResponse(
                album.getIdAlbum(),
                album.getNome(),
                album.getArtista(),
                0
        );
    }

    private double calculaMedia(List<Integer> avaliacoes) {
        return avaliacoes.stream().mapToDouble(d -> d).average().orElse(0);
    }
}
