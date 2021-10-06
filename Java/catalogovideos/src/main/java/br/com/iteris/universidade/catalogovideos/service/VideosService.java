package br.com.iteris.universidade.catalogovideos.service;

import br.com.iteris.universidade.catalogovideos.domain.dto.CategoriaResponse;
import br.com.iteris.universidade.catalogovideos.domain.dto.VideoCreateRequest;
import br.com.iteris.universidade.catalogovideos.domain.dto.VideoResponse;
import br.com.iteris.universidade.catalogovideos.domain.dto.VideoUpdateRequest;
import br.com.iteris.universidade.catalogovideos.domain.entity.Categoria;
import br.com.iteris.universidade.catalogovideos.domain.entity.Responsavel;
import br.com.iteris.universidade.catalogovideos.domain.entity.Video;
import br.com.iteris.universidade.catalogovideos.domain.entity.VideoCategoria;
import br.com.iteris.universidade.catalogovideos.exception.VideoNaoEncontradoException;
import br.com.iteris.universidade.catalogovideos.repository.VideosCategoriaRepository;
import br.com.iteris.universidade.catalogovideos.repository.VideosRepository;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class VideosService {

    private final VideosRepository repository;
    private final VideosCategoriaRepository videosCategoriaRepository;
    public VideosService(VideosRepository repository, VideosCategoriaRepository videosCategoriaRepository) {
        this.repository = repository;
        this.videosCategoriaRepository = videosCategoriaRepository;
    }

    public VideoResponse criarVideo(VideoCreateRequest videoCreateRequest) {

        var responsavel = new Responsavel();
        responsavel.setIdResponsavel(videoCreateRequest.idResponsavel);

        var novoVideo = new Video();
        novoVideo.setTitulo(videoCreateRequest.getTitulo());
        novoVideo.setUrl(videoCreateRequest.getUrl());
        novoVideo.setResponsavel(responsavel);

        var videoSalvo = repository.save(novoVideo);

        for (int s: videoCreateRequest.getCategoriaIds()) {
            var videoCategoria = new VideoCategoria();
            var novaCategoria = new Categoria();
            novaCategoria.setIdCategoria(s);
            videoCategoria.setCategoria(novaCategoria);
            videoCategoria.setVideo(videoSalvo);
            videosCategoriaRepository.save(videoCategoria);
        }

        List<CategoriaResponse> listaCategorias = listarCategorias(videoSalvo);

        return new VideoResponse(
                videoSalvo.getIdVideo(),
                videoSalvo.getResponsavel().getIdResponsavel(),
                videoSalvo.getTitulo(),
                videoSalvo.getUrl(),
                listaCategorias
        );
    }

    public List<VideoResponse> listar() {

        var resultado = repository.findAll();

        return resultado.stream().map(video -> {
            List<CategoriaResponse> listaCategorias = listarCategorias(video);

            return new VideoResponse(
                    video.getIdVideo(),
                    video.getResponsavel().getIdResponsavel(),
                    video.getTitulo(),
                    video.getUrl(),
                    listaCategorias

            );

        }).collect(Collectors.toList());
    }

    public VideoResponse buscarPorId(Integer idVideo) {
        var videoEncontrado = repository.findById(idVideo);

        if (videoEncontrado.isEmpty()) {
            throw new VideoNaoEncontradoException();
        }

        var videoSalvo = videoEncontrado.get();

        List<CategoriaResponse> listaCategorias = listarCategorias(videoSalvo);

        return new VideoResponse(
                videoSalvo.getIdVideo(),
                videoSalvo.getResponsavel().getIdResponsavel(),
                videoSalvo.getTitulo(),
                videoSalvo.getUrl(),
                listaCategorias
        );
    }

    public VideoResponse atualizarUrl(Integer idVideo, VideoUpdateRequest videoUpdateRequest) {
        var videoEncontrado = repository.findById(idVideo);

        if (videoEncontrado.isEmpty()) {
            throw new VideoNaoEncontradoException();
        }

        var video = videoEncontrado.get();
        video.setUrl(videoUpdateRequest.getUrl());

        var videoSalvo = repository.save(video);

        List<CategoriaResponse> listaCategorias = listarCategorias(videoSalvo);

        return new VideoResponse(
                videoSalvo.getIdVideo(),
                videoSalvo.getResponsavel().getIdResponsavel(),
                videoSalvo.getTitulo(),
                videoSalvo.getUrl(),
                listaCategorias
        );
    }

    public List<CategoriaResponse> listarCategorias (Video video){
        List<CategoriaResponse> listaCategorias = new ArrayList<>();
        listaCategorias = video.getVideoCategorias().stream().map(videoCategoria ->{
            return new CategoriaResponse(
                    videoCategoria.getCategoria().getIdCategoria(),
                    videoCategoria.getCategoria().getNome()
            );

        }).collect(Collectors.toList());

        return listaCategorias;
    }

}
